﻿using System;
using System.IO;
using Newtonsoft.Json;

namespace PHRMS.Data
{
    public class PhexonConfig
    {
        public string Host { get; set; }
        public string Password { get; set; }
        public string User { get; set; }
        public string Database { get; set; }
        public int Port { get; set; }
    }

    public static class PhexonConfigurationManager
    {
        public static PhexonConfig Configuration { get; set; }

        public static void Initialize()
        {
            //TODO:replace with safe
            try
            {
                var json = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Data\db_config.json"));
                Configuration = JsonConvert.DeserializeObject<PhexonConfig>(json);
            }
            catch
            {
            }
        }
    }
}