﻿using System.Threading.Tasks;
using LaywApplication.Configuration;
using LaywApplication.Controllers.Utils;
using LaywApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace LaywApplication.Controllers.PatientController
{
    public class WeightController : BaseJsonController
    {
        public WeightController(ServerIP IPConfig, JsonStructure jsonStructureConfig) 
            : base(IPConfig, jsonStructureConfig, jsonStructureConfig.Weight) { }

        [HttpGet("~/dashboard/patients/{id}/[controller]")]
        public async Task<PatientWeight> Read(int id, string date)
        {
            JObject weightJson = await APIUtils.GetAsync(IPConfig.GetTotalUrlUser() + id + JsonDataConfig.Url +
                EndUrlDate(Request, "23-06-2018")); //todo sistemare data
            return ((JObject)weightJson[JsonDataConfig.Root]).GetObject<PatientWeight>();
        }
    }
}