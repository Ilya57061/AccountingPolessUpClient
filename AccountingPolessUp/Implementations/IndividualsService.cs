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
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"http://127.0.0.1:5000/GetIndividuals";
                var json = web.DownloadString(url);
                List<Individuals> Info = JsonConvert.DeserializeObject<List<Individuals>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }   
        }
        public void Create(Individuals model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("FIO", $"{model.FIO}");
                reqparm.Add("Phone", $"{model.Phone}");
                reqparm.Add("DateOfBirth", $"{model.DateOfBirth}");
                reqparm.Add("Mail", $"{model.Mail}");
                reqparm.Add("Gender", $"{model.Gender}");
                reqparm.Add("SocialNetwork", $"{model.SocialNetwork}");
                
                web.UploadValues("http://127.0.0.1:5000/CreateIndividual", "POST", reqparm);

            }
        }
        public void Update(Individuals model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("FIO", $"{model.FIO}");
                reqparm.Add("Phone", $"{model.Phone}");
                reqparm.Add("DateOfBirth", $"{model.DateOfBirth}");
                reqparm.Add("Mail", $"{model.Mail}");
                reqparm.Add("Gender", $"{model.Gender}");
                reqparm.Add("SocialNetwork", $"{model.SocialNetwork}");
                web.UploadValues("http://127.0.0.1:5000/UpdateIndividual", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("http://127.0.0.1:5000/DeletIndividual", "DELETE", reqparm);

            }
        }
    }
}
