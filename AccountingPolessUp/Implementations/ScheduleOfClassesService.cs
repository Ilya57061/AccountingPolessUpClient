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
    public class ScheduleOfClassesService
    {
        public List<ScheduleOfСlasses> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"http://127.0.0.1:5000/GetScheduleOfСlasses";
                var json = web.DownloadString(url);
                List<ScheduleOfСlasses> Info = JsonConvert.DeserializeObject<List<ScheduleOfСlasses>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(ScheduleOfСlasses model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("DateStart", $"{model.DateStart}");
                reqparm.Add("DateEnd", $"{model.DateEnd}");
                reqparm.Add("WorkSpaceLink", $"{model.WorkSpaceLink}");
                reqparm.Add("TrainingCoursesId", $"{model.TrainingCoursesId}");


                web.UploadValues("http://127.0.0.1:5000/CreateScheduleOfСlasses", "POST", reqparm);

            }
        }
        public void Update(ScheduleOfСlasses model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("DateStart", $"{model.DateStart}");
                reqparm.Add("DateEnd", $"{model.DateEnd}");
                reqparm.Add("WorkSpaceLink", $"{model.WorkSpaceLink}");
                reqparm.Add("TrainingCoursesId", $"{model.TrainingCoursesId}");

                web.UploadValues("http://127.0.0.1:5000/UpdateScheduleOfСlasses", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Id", $"{id}");
                web.UploadValues("http://127.0.0.1:5000/DeleteScheduleOfСlasses","DELETE", reqparm);

            }
        }
    }
}
