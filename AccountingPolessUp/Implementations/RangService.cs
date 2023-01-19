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
    public class RangService
    {
        public List<Rang> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetRang";
                var json = web.DownloadString(url);
                List<Rang> Info = JsonConvert.DeserializeObject<List<Rang>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(Rang model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("RangName", $"{model.RangName}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("OrganizationId", $"{model.OrganizationId}");


                web.UploadValues("https://localhost:7273/CreateRang", "POST", reqparm);

            }
        }
        public void Update(Rang model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("RangName", $"{model.RangName}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("OrganizationId", $"{model.OrganizationId}");
                web.UploadValues("https://localhost:7273/UpdateRang", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("https://localhost:7273/DeleteRang", "DELETE", reqparm);

            }
        }
    }
}
