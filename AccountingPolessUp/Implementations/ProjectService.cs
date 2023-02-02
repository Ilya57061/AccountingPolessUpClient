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
    public class ProjectService
    {
        public List<Project> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetProject";
                var json = web.DownloadString(url);
                List<Project> Info = JsonConvert.DeserializeObject<List<Project>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(Project model)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Fullname", $"{model.Fullname}");
                reqparm.Add("Status", $"{model.Status}");
                reqparm.Add("DateStart", $"{model.DateStart}");
                reqparm.Add("DateEnd", $"{model.DateEnd}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("TechnicalSpecification", $"{model.TechnicalSpecification}");
                reqparm.Add("CustomerId", $"{model.CustomerId}");
                reqparm.Add("idLocalPM", $"{model.idLocalPM}");

                web.UploadValues("https://localhost:7273/CreateProject", "POST", reqparm);

            }
        }
        public void Update(Project model)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("Fullname", $"{model.Fullname}");
                reqparm.Add("Status", $"{model.Status}");
                reqparm.Add("DateStart", $"{model.DateStart}");
                reqparm.Add("DateEnd", $"{model.DateEnd}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("TechnicalSpecification", $"{model.TechnicalSpecification}");
                reqparm.Add("CustomerId", $"{model.CustomerId}");
                reqparm.Add("idLocalPM", $"{model.idLocalPM}");
                web.UploadValues("https://localhost:7273/UpdateProject", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("https://localhost:7273/DeleteProject", "DELETE", reqparm);
            }
        }
    }
}
