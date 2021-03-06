﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaywApplication.Configuration;
using LaywApplication.Controllers.Services.PatientData;
using LaywApplication.Models.PatientData;
using Microsoft.AspNetCore.Mvc;

namespace LaywApplication.ViewComponents
{
    public class PatientPersonalDataViewComponent : BaseViewComponent
    {
        //private readonly ActivitySummaryController ActivitySummaryController;
        private readonly WeightController WeightController;

        public PatientPersonalDataViewComponent(ServerIP IPConfig, JsonStructure jsonStructureConfig)
            : base(IPConfig, jsonStructureConfig)
        {
            //ActivitySummaryController = new ActivitySummaryController(IPConfig, jsonStructureConfig);
            WeightController = new WeightController(IPConfig, jsonStructureConfig);
        }
        
        public async Task<IViewComponentResult> InvokeAsync(Models.Patient currentPatient)
        {
            //List<Models.PatientData.ActivitySummary> summariesMonth = await ActivitySummaryController.Read(currentPatient.Id, DateTimeNow.ToString(italianDateFormat), "1m");
            //List<Models.PatientData.ActivitySummary> summariesWeek = await ActivitySummaryController.Read(currentPatient.Id, DateTimeNow.ToString(italianDateFormat), "1w");

            var data = new PatientPersonalData
            {
                Patient = currentPatient
            };

            //data.TotalSteps.Month = (from s in summariesMonth select s.Steps).Sum();
            //data.TotalSteps.Week = (from s in summariesWeek select s.Steps).Sum();

            //data.TotalCalories.Month = (from s in summariesMonth select s.CaloriesCategory.OutCalories).Sum();
            //data.TotalCalories.Week = (from s in summariesWeek select s.CaloriesCategory.OutCalories).Sum();

            //data.AverageFloors.Month = (from s in summariesMonth select s.Floors).Average();
            //data.AverageFloors.Week = (from s in summariesWeek select s.Floors).Average();

            data.WeightComparison.Today = await WeightController.Read(currentPatient.Id, DateTimeNow.ToString(italianDateFormat));
            data.WeightComparison.Yesterday = await WeightController.Read(currentPatient.Id, DateTimeNow.Subtract(TimeSpan.FromDays(1)).ToString(italianDateFormat));

            return View(data);
        }
    }
}