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
    public class EducationalPortalsService
    {
        public List<EducationalPortals> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetEducationalPortals";
                var json = web.DownloadString(url);
                List<EducationalPortals> Info = JsonConvert.DeserializeObject<List<EducationalPortals>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(EducationalPortals model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Name", $"{model.Name}");
                reqparm.Add("DepartmentId", $"{model.DepartmentId}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("Link", $"{model.Link}");


                web.UploadValues("https://localhost:7273/CreateEducationalPortals", "POST", reqparm);

            }
        }
        public void Update(EducationalPortals model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("Name", $"{model.Name}");
                reqparm.Add("DepartmentId", $"{model.DepartmentId}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("Link", $"{model.Link}");

                web.UploadValues("https://localhost:7273/UpdateEducationalPortals", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Id", $"{id}");
                web.UploadValues("https://localhost:7273/DeleteEducationalPortals", "DELETE", reqparm);

            }
        }
    }
}
