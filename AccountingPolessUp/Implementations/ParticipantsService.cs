using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace AccountingPolessUp.Implementations
{
    public class ParticipantsService // участники
    {

        public List<Participants> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetParticipants";
                var json = web.DownloadString(url);
                List<Participants> Info = JsonConvert.DeserializeObject<List<Participants>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public List<Participants> Get(int id)
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/Get?id={id}";
                var json = web.DownloadString(url);
                List<Participants> Info = JsonConvert.DeserializeObject<List<Participants>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(Participants model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("IndividualsId", $"{model.IndividualsId}");
                reqparm.Add("UserId", $"{model.UserId}");
                reqparm.Add("DateEntry", $"{model.DateEntry}");
                reqparm.Add("DateExit", $"{model.DateExit}");
                reqparm.Add("Mmr", $"{model.Mmr}");
                reqparm.Add("status", $"{model.Status}");
                reqparm.Add("GitHub", $"{model.GitHub}");
                web.UploadValues("https://localhost:7273/CreateParticipant", "POST", reqparm);
            
            }
        }
        public void Update(Participants model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("IndividualsId", $"{model.IndividualsId}");
                reqparm.Add("UserId", $"{model.UserId}");
                reqparm.Add("DateEntry", $"{model.DateEntry}");
                reqparm.Add("DateExit", $"{model.DateExit}");
                reqparm.Add("Mmr", $"{model.Mmr}");
                reqparm.Add("status", $"{model.Status}");
                reqparm.Add("GitHub", $"{model.GitHub}");
                web.UploadValues("https://localhost:7273/UpdateParticipant", "PUT", reqparm);
         
            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("https://localhost:7273/DeleteParticipant", "DELETE", reqparm);
           
            }
        }
    }
}
