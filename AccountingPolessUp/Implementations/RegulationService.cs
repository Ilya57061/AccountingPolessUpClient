using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.Implementations
{
    public class RegulationService
    {
        public List<Regulation> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetRegulation";
                var json = web.DownloadString(url);
                List<Regulation> Info = JsonConvert.DeserializeObject<List<Regulation>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(Regulation model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Text", $"{model.Text}");
                reqparm.Add("Name", $"{model.Name}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("OrganizationId", $"{model.OrganizationId}");


                web.UploadValues("https://localhost:7273/CreateRegulation", "POST", reqparm);

            }
        }
        public void Update(Regulation model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("Text", $"{model.Text}");
                reqparm.Add("Name", $"{model.Name}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("OrganizationId", $"{model.OrganizationId}");
                web.UploadValues("https://localhost:7273/UpdateRegulation", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("https://localhost:7273/DeleteRegulation", "DELETE", reqparm);

            }
        }
    }
}
