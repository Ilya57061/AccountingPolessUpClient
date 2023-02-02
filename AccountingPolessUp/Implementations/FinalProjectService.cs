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
    public class FinalProjectService
    {
        public List<FinalProject> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetFinalProject";
                var json = web.DownloadString(url);
                List<FinalProject> Info = JsonConvert.DeserializeObject<List<FinalProject>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public List<FinalProject> GetByEmployment(int employmentId)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("EmploymentId", $"{employmentId}");
                var response = web.UploadValues("https://localhost:7273/GetByEmployment", "POST", reqparm);
                var responseString = Encoding.Default.GetString(response);
                List<FinalProject> list = JsonConvert.DeserializeObject<List<FinalProject>>(responseString);
                return list;
            }
        }
        public void Create(FinalProject model)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Name", $"{model.Name}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("GitHub", $"{model.GitHub}");
                reqparm.Add("Links", $"{model.Links}");
                reqparm.Add("DateStart", $"{model.DateStart}");
                reqparm.Add("DateEnd", $"{model.DateEnd}");
                reqparm.Add("EmploymentId", $"{model.EmploymentId}");


                web.UploadValues("https://localhost:7273/CreateFinalProject", "POST", reqparm);

            }
        }
        public void Update(FinalProject model)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("Name", $"{model.Name}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("GitHub", $"{model.GitHub}");
                reqparm.Add("Links", $"{model.Links}");
                reqparm.Add("DateStart", $"{model.DateStart}");
                reqparm.Add("DateEnd", $"{model.DateEnd}");
                reqparm.Add("EmploymentId", $"{model.EmploymentId}");
                web.UploadValues("https://localhost:7273/UpdateFinalProject", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("https://localhost:7273/DeleteFinalProject", "DELETE", reqparm);

            }
        }
    }
}
