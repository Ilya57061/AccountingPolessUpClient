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
    public class ApplicationsInTheProjectService
    {
        public List<ApplicationsInTheProject> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"http://127.0.0.1:5000/GetAppInTheProject";
                var json = web.DownloadString(url);
                List<ApplicationsInTheProject> Info = JsonConvert.DeserializeObject<List<ApplicationsInTheProject>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(ApplicationsInTheProject model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("WorkStatus", $"{model.WorkStatus}");
                reqparm.Add("DateEntry", $"{model.DateEntry}");
                reqparm.Add("ParticipantsId", $"{model.ParticipantsId}");
                reqparm.Add("VacancyId ", $"{model.VacancyId}");
            

                web.UploadValues("http://127.0.0.1:5000/CreateAppInTheProject", "POST", reqparm);

            }
        }
        public void Update(ApplicationsInTheProject model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("WorkStatus", $"{model.WorkStatus}");
                reqparm.Add("DateEntry", $"{model.DateEntry}");
                reqparm.Add("ParticipantsId", $"{model.ParticipantsId}");
                reqparm.Add("VacancyId ", $"{model.VacancyId}");

                web.UploadValues("http://127.0.0.1:5000/UpdateAppInTheProject", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("http://127.0.0.1:5000/DeleteAppInTheProject", "DELETE", reqparm);

            }
        }
    }
}
