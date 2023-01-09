using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;


namespace AccountingPolessUp.Implementations
{
    public class IndividualsService
    {
        public List<Individuals> Get()
        {
            using (WebClient web = new WebClient())
            {
                string url = $"https://192.168.1.5:7273/GetIndividuals";
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
