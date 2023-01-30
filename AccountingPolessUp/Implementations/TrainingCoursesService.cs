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
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"http://127.0.0.1:5000/GetTrainingCourses";
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
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Name", $"{model.Name}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("Link", $"{model.Link}");

                web.UploadValues("http://127.0.0.1:5000/CreateTrainingCourses", "POST", reqparm);

            }
        }
        public void Update(TrainingCourses model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("Name", $"{model.Name}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("Link", $"{model.Link}");
                web.UploadValues("http://127.0.0.1:5000/UpdateTrainingCourses", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("http://127.0.0.1:5000/DeleteTrainingCourses", "DELETE", reqparm);

            }
        }
    }
}
