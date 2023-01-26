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
    public class RegistrationForCoursesService
    {
        public List<RegistrationForCourses> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetRegistrationForCourses";
                var json = web.DownloadString(url);
                List<RegistrationForCourses> Info = JsonConvert.DeserializeObject<List<RegistrationForCourses>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(RegistrationForCourses model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("DateEntry", $"{model.DateEntry}");
                reqparm.Add("ParticipantsId", $"{model.ParticipantsId}");
                reqparm.Add("TrainingCoursesId", $"{model.TrainingCoursesId}");


                web.UploadValues("https://localhost:7273/CreateRegistrationForCoursest", "POST", reqparm);

            }
        }
        public void Update(RegistrationForCourses model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("DateEntry", $"{model.DateEntry}");
                reqparm.Add("ParticipantsId", $"{model.ParticipantsId}");
                reqparm.Add("TrainingCoursesId", $"{model.TrainingCoursesId}");

                web.UploadValues("https://localhost:7273/UpdateRegistrationForCourses", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Id", $"{id}");
                web.UploadValues("https://localhost:7273/DeleteRegistrationForCoursest", "DELETE", reqparm);

            }
        }
    }
}
