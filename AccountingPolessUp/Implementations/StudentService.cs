
using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace AccountingPolessUp.Implementations
{
    public class StudentService
    {
        public List<Student> Get()
        {
            using (WebClient web = new WebClient())
            {
                string url = $"https://localhost:7058/Buy/GetCategory";
                var json = web.DownloadString(url);
                List<Student> Info = JsonConvert.DeserializeObject<List<Student>>(json);
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
