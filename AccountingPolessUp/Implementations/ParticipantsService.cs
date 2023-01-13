using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                string url = $"https://localhost:7273/Get";
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
                string url = $"https://localhost:7058/Create?participantsDto={model}";
                web.UploadString(url, "POST");
            }
        }
        public void Update(Participants model)
        {
            using (WebClient web = new WebClient())
            {
                string url = $"https://localhost:7058/Update?participantsDto={model}";
                web.UploadString(url, "PUT");
            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                string url = $"https://localhost:7058/Delete?id={id}";
                web.UploadString(url, "DELETE");
            }
        }
    }
}
