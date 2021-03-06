﻿using System;
using System.Collections.Generic;

namespace LaywApplication.Models.PatientData
{
    public class Activity
    {
        public List<HeartBeat> HeartBeats { get; set; }
        public string ActivityName { get; set; }
        public DateTime Date { get; set; }
        public long Duration { get; set; }
        public int Calories { get; set; }
        public List<HeartRateZone> HeartRateZonesList { get; set; }
        public int AverageHeartRate { get; set; }
        public int Steps { get; set; }
        public int Speed { get; set; }
    }

    public class HeartBeat
    {
        public string HeartRateTime { get; set; }
        public int Value { get; set; }
    }

    public class HeartRateZone
    {
        public string Name { get; set; }
        public int Minutes { get; set; }
    }
}   
