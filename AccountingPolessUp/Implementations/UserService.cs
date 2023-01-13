﻿using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.Implementations
{
    public class UserService
    {
        public List<Individuals> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetIndividuals";
                var json = web.DownloadString(url);
                List<Individuals> Info = JsonConvert.DeserializeObject<List<Individuals>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Update(string name, int count)
        {
            using (WebClient web = new WebClient())
            {
                string url = $"https://localhost:7058/Buy/UpdateDrug?name={name}&count={count}";
                web.UploadString(url, "PUT");
            }
        }
    }
}
