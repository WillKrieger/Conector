using System;
using System.Collections.Generic;
using System.Linq;
using Formiik.Connector.Entities.Engine.Dto;
using Formiik.Connector.Entities.Mobile.Dto.Android;
using Formiik.Connector.Processor.Utils;
using Newtonsoft.Json.Linq;

namespace Formiik.Connector.Processor.MobileProxy.Transformer
{
    public class JsonCommentsCreator
    {
        private readonly List<IncomeCommmentDto> _inputComments;

        private readonly JObject _objectBase;

        private JToken _token;

        private Dictionary<string, IEnumerable<AndroidCommentDto>> fields;

        public  bool ExistsComments { get; private set; }

        public JsonCommentsCreator(JObject objectBase, List<IncomeCommmentDto> comments)
        {
            ExistsComments = false;
            
            _inputComments = comments;

            _objectBase = (JObject)objectBase.DeepClone();
            
            fields = GroupComments();
        }

        public JObject CreateJson()
        {
            if (_inputComments != null && _inputComments.Count > 0)
            {
                foreach (var field in fields)
                {
                    _token = _objectBase.SelectToken(field.Key);

                    if (_token != null)
                    {
                        string comments = FormiikGenericParser.SerializeToJson(field.Value);
                        
                        _token.Replace(comments);

                        ExistsComments = true;
                    }
                }

                CleanJson();
            }

            return _objectBase;
        }

        private void CleanJson()
        {
            try
            {
                 var listOfKeysInFields = fields.Keys.ToList();
                 var values = _objectBase.ToObject<Dictionary<string, object>>();
 
                 foreach (var value in values)
                 {
                     if (!fields.ContainsKey(value.Key) && !listOfKeysInFields.Any(r => r.StartsWith(value.Key)))
                     {
                         _token = _objectBase.Remove(value.Key);          
                     }
                     else if (_objectBase.SelectToken(value.Key).HasValues)
                     {
                         CleanJsonFormEdits(value, listOfKeysInFields);
                     }
                 }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void CleanJsonFormEdits(KeyValuePair<string, object > value, List<string> listOfKeysInFields)
        {
            List<string> ruts = new List<string>();
                         
            listOfKeysInFields.RemoveAll(x => !x.Contains("."));
                         
            _token = _objectBase.SelectToken(value.Key);
                         
            foreach (var v in _token)
            {   
                foreach (var v2 in v)
                {   
                    if (!listOfKeysInFields.Contains(v2.Path))
                    {
                        ruts.Add(v2.Path); 
                    }
                }                
            }
            foreach (var v in ruts)
            {
                _objectBase.SelectToken(v).Parent.Remove();
            }
        }
        
        private Dictionary<string, IEnumerable<AndroidCommentDto>> GroupComments()
        {
            var fields = new Dictionary<string, IEnumerable<AndroidCommentDto>>();

            var uniqueFieldsPaths = _inputComments.Select(p => p.keyName).Distinct();

            foreach (var fieldId in uniqueFieldsPaths)
            {
                IEnumerable<AndroidCommentDto> fieldComments =
                    from p in _inputComments
                    where p.keyName == fieldId
                    select new AndroidCommentDto()
                    {
                        id= p.commentId,
                        text = p.description,
                        date = p.creation,
                        name = p.agent.Name,
                        status = p.status,
                        isInformative = p.isInformative
                    };

                fields.Add(fieldId, fieldComments);
            }

            return fields;
        }
    }
}