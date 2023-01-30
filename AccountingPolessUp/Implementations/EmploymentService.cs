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
    public class EmploymentService
    {
        public List<Employment> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://polessu.by/polessup/GetEmployments";
                var json = web.DownloadString(url);
                List<Employment> Info = JsonConvert.DeserializeObject<List<Employment>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public Employment GetByParticipants(int participantsId)
        {
            using (WebClient web = new WebClient())
            {

                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("ParticipantsId", $"{participantsId}");
                var response = web.UploadValues("https://polessu.by/polessup/GetByParticipants", "POST", reqparm);
                var responseString = Encoding.Default.GetString(response);
                Employment employment = JsonConvert.DeserializeObject<Employment>(responseString);
                return employment;
            }
        }
        public void Create(Employment model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("DateStart", $"{model.DateStart}");
                reqparm.Add("DateEnd", $"{model.DateEnd}");
                reqparm.Add("Status", $"{model.Status}");
                reqparm.Add("StatusDescription", $"{model.StatusDescription}");
                reqparm.Add("IdMentor", $"{model.IdMentor}");
                reqparm.Add("ParticipantsId", $"{model.ParticipantsId}");
                reqparm.Add("PositionId", $"{model.PositionId}");

                web.UploadValues("https://polessu.by/polessup/CreateEmployment", "POST", reqparm);

            }
        }
        public void Update(Employment model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("DateStart", $"{model.DateStart}");
                reqparm.Add("DateEnd", $"{model.DateEnd}");
                reqparm.Add("Status", $"{model.Status}");
                reqparm.Add("StatusDescription", $"{model.StatusDescription}");
                reqparm.Add("IdMentor", $"{model.IdMentor}");
                reqparm.Add("ParticipantsId", $"{model.ParticipantsId}");
                reqparm.Add("PositionId", $"{model.PositionId}");
                web.UploadValues("https://polessu.by/polessup/UpdateEmployment", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("https://polessu.by/polessup/DeleteEmployment", "DELETE", reqparm);

            }
        }
    }
}
