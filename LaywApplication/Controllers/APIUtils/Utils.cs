﻿using System.Net;
using System.Net.Http;

namespace LaywApplication.Controllers.APIUtils
{
    public static class Utils
    {
        private static readonly HttpClient client = new HttpClient();

        public static string Get(string uri)
        {
            string result;
            using (var client = new WebClient())
                result = client.DownloadString(uri);
            return result;
        }

        public static string Post(string uri, string body)
        {
            string result;
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                result = client.UploadString(uri, "POST", body);
            }
            return result;
        }
    }
}
