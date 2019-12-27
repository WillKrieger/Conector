using System;
using System.Threading.Tasks;
using Formiik.Connector.Data.Azure;
using Formiik.Connector.Entities;
using Formiik.Connector.Entities.TsEntity;

namespace Formiik.Connector.Processor.ConnectorStorage
{
    public static class TransformationRulesStorage
    {
        #region - Engine to mobile-

        public static async Task<TsRequirementTranformRule> GetRuleEngineToMobile(string ruleId, string definitionId)
        {
            var rules = GetConnection();

            TsRequirementTranformRule rulesWithContainerId = await rules.GetItem(ruleId, definitionId);

            return rulesWithContainerId;
        }

        public static async Task SaveRuleEngineToMobile(string containerId, TsRequirementTranformRule rule)
        {
            var rules = GetConnection();

            rule.PartitionKey = containerId;
            //Al momento de agregar el RuleId siempre se agregara el RowKey.
            //Esto por alguna extraña libreria de Entidades del Connector.
            rule.RuleId = rule.DefinitionId;
            
            await rules.Delete(rule.PartitionKey, rule.RowKey);

            await rules.Insert(rule);
        }

        #endregion

        #region - Mobile to engine  -

        public static async Task<TsRequirementTranformRule> GetRuleMobileToEngine(Guid idWorkOrderType, string sectionId)
        {
            var rules = GetConnection();

            TsRequirementTranformRule rulesWithContainerId = await rules.GetItem(idWorkOrderType.ToString().ToLower(), sectionId);

            return rulesWithContainerId;
        }
        
        public static async Task SaveRuleMobileToEngine(Guid idWorkOrderType, string sectionId, TsRequirementTranformRule rule)
        {
            var rules = GetConnection();

            rule.PartitionKey = idWorkOrderType.ToString().ToLower();
            rule.RuleId = sectionId;
            
            await rules.Delete(rule.PartitionKey, rule.RowKey);

            await rules.Insert(rule);
        }

        #endregion

        private static AzureTableStorage<TsRequirementTranformRule> GetConnection()
        {
            string tableNameRules = GeneralConstants.TS_XSLT_REQUIREMENTS_RULES;

            var rules = new AzureTableStorage<TsRequirementTranformRule>(tableNameRules);

            return rules;
        }
    }
}