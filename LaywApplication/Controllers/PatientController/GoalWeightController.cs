﻿using System.Threading.Tasks;
using LaywApplication.Configuration;
using LaywApplication.Controllers.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LaywApplication.Controllers.PatientController
{
    [Route("~/dashboard/patients/{id}/[controller]")]
    public class GoalWeightController : BaseJsonReadController<Models.GoalWeight>
    {
        public GoalWeightController(ServerIP IPConfig, JsonStructure jsonStructureConfig) 
            : base(IPConfig, jsonStructureConfig, jsonStructureConfig.GoalsWeight) { }

        [HttpPost("~/dashboard/patients/{id}/[controller]/update")]
        public async Task<object> Update(int id, [FromBody]Models.GoalWeight item)
        {
            item.StartDate = DateTimeNow;
            item.StartWeight = (await new WeightController(IPConfig, JsonStructureConfig).
                Read(id, DateTimeNow.ToString(italianDateFormat))).Weight;

            var jsonGoalWeight = new JObject
            {
                { JsonDataConfig.Root , JObject.Parse(JsonConvert.SerializeObject(item, serializerSettings)) }
            };

            await APIUtils.PostAsync(IPConfig.GetTotalUrlUser() + id + JsonDataConfig.Url, jsonGoalWeight.ToString());
            return Empty;
        }
    }
}