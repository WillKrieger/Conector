using System.Collections.Generic;
using System.Threading.Tasks;
using Formiik.Connector.Entities;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace Formiik.Connector.Data.Azure
{
    public class AzureTableStorage<T> where T : TableEntity, new()
    {
        private readonly string _tableName;
        private const string PARTITION_KEY = "PartitionKey";

        public AzureTableStorage(string tableName)
        {
            _tableName = tableName;
        }

        #region Insert

        public async Task Insert(T item)
        {
            //Table  
            CloudTable table = await GetTableAsync();

            //Operation  
            TableOperation operation = TableOperation.Insert(item);

            //Execute  
            await table.ExecuteAsync(operation);
        }

        public virtual async Task<IList<TableResult>> AddBatchRow(List<T> rows)
        { 
            CloudTable table = await GetTableAsync();

            var batchOperation = new TableBatchOperation();

            foreach (var entity in rows)
            {
                batchOperation.Insert(entity);
            }

            return await table.ExecuteBatchAsync(batchOperation);
        }

        #endregion

        #region Select

        public virtual async Task<List<T>> ExecuteQuery(string queryfilter, int? top)
        {
            CloudTable table = await GetTableAsync();

            var entities = new List<T>();

            var rangeQuery = new TableQuery<T>().Where(queryfilter).Take(top);

            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<T> resultSegment = await table.ExecuteQuerySegmentedAsync(rangeQuery, token);

                token = resultSegment.ContinuationToken;

                entities.AddRange(resultSegment.Results);
            } while (token != null);

            return entities;
        }

        public async Task<T> GetItem(string partitionKey, string rowKey)
        {
            T entity;
            
            CloudTable table = await GetTableAsync();

            //Operation  
            TableOperation operation = TableOperation.Retrieve<T>(partitionKey, rowKey);

            //Execute  
            TableResult result = await table.ExecuteAsync(operation);

            if (result.Result == null)
            {
                return null;
            }

            entity = (T)result.Result;

            return entity;
        }        
        
        public async Task<List<T>> GetItems(string partitionKey)
        {
            var entities = new List<T>();
            
            CloudTable table = await GetTableAsync();

            TableQuery<T> query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition(PARTITION_KEY, QueryComparisons.Equal, partitionKey));

            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<T> resultSegment = await table.ExecuteQuerySegmentedAsync(query, token);

                token = resultSegment.ContinuationToken;

                entities.AddRange(resultSegment.Results);
            } while (token != null);

            return entities;
        }

        #endregion

        #region Delete

        public async Task Delete(string partitionKey, string rowKey)
        {
            T item = await GetItem(partitionKey, rowKey);

            if (item != null)
            {
                CloudTable table = await GetTableAsync();

                TableOperation operation = TableOperation.Delete(item);

                await table.ExecuteAsync(operation);
            }
        }

        public async Task DeletePartitionRows(string partitionKey)
        {
            var queryResult = new List<T>();

            CloudTable table = await GetTableAsync();

            TableQuery<T> query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition(PARTITION_KEY, QueryComparisons.Equal, partitionKey));

            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<T> resultSegment = await table.ExecuteQuerySegmentedAsync(query, token);

                token = resultSegment.ContinuationToken;

                queryResult.AddRange(resultSegment.Results);
            } while (token != null);

            int itemsToDeleteCount = 0;
            TableBatchOperation batchOperation = null;

            if (queryResult.Count != 0)
            {
                batchOperation = new TableBatchOperation();

                foreach (var entity in queryResult)
                {
                    itemsToDeleteCount++;
                    batchOperation.Delete(entity);

                    if (itemsToDeleteCount == 100)
                    {
                        await table.ExecuteBatchAsync(batchOperation);
                        batchOperation = new TableBatchOperation();
                        itemsToDeleteCount = 0;
                    }
                }
            }

            if (itemsToDeleteCount > 0 && batchOperation != null)
            {
                await table.ExecuteBatchAsync(batchOperation);
            }
        }

        #endregion
        
        #region - Update -
        public async Task Update(T row)
        {
            CloudTable table = await GetTableAsync();
            
            var operation = TableOperation.Replace(row);
            
            await table.ExecuteAsync(operation);
        }
        #endregion

        private async Task<CloudTable> GetTableAsync()
        {
            //Contract.Ensures(Contract.Result<CloudTable>() != null);
            var credentials = new StorageCredentials(GeneralConstants.STORAGE_ACCOUNT_NAME, GeneralConstants.STORAGE_ACCOUNT_KEY);

            //Account  
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);

            //Client  
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            //Table  
            CloudTable table = tableClient.GetTableReference(_tableName);

            await table.CreateIfNotExistsAsync();

            return table;
        }      
    }
}