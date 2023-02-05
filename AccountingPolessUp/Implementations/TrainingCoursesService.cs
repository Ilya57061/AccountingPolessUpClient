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
    public class TrainingCoursesService
    {
        public List<TrainingCourses> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetTrainingCourses";
                var json = web.DownloadString(url);
                List<TrainingCourses> Info = JsonConvert.DeserializeObject<List<TrainingCourses>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(TrainingCourses model)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Name", $"{model.Name}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("Link", $"{model.Link}");

                web.UploadValues("https://localhost:7273/CreateTrainingCourses", "POST", reqparm);

            }
        }
        public void Update(TrainingCourses model)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("Name", $"{model.Name}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("Link", $"{model.Link}");
                web.UploadValues("https://localhost:7273/UpdateTrainingCourses", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("https://localhost:7273/DeleteTrainingCourses", "DELETE", reqparm);

            }
        }
    }
}
