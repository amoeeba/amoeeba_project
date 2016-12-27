﻿using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace JsonDeserialization
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("C:\\Users\\Raj\\Documents\\Visual Studio 2013\\Projects\\deserilization\\deserilization\\settings.txt");

            CastInfo castMember = new JavaScriptSerializer().Deserialize<CastInfo>(json);
        }
    }

    public class CastInfo
    {
        public List<CustomCastInfo> cast { get; set; }
    }
    public class CustomCastInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<string> characters { get; set; }

    }

}