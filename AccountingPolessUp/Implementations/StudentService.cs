
using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AccountingPolessUp.Implementations
{
    public class StudentService
    {
        public List<Student> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetStudents";
                var json = web.DownloadString(url);
                List<Student> Info = JsonConvert.DeserializeObject<List<Student>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public Student GetByIndividuals(int individualsId)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("individualsId", $"{individualsId}");
                var response = web.UploadValues("https://localhost:7273/StudentByIndividuals", "POST", reqparm);
                var responseString = Encoding.Default.GetString(response);
                Student student = JsonConvert.DeserializeObject<Student>(responseString);
                return student;
            }
        }
        public void Create(Student model)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("StudentCard", $"{model.StudentCard}");
                reqparm.Add("Group", $"{model.Group}");
                reqparm.Add("CourseNumber", $"{model.CourseNumber}");
                reqparm.Add("University", $"{model.University}");
                reqparm.Add("IndividualsId", $"{model.IndividualsId}");
             

                web.UploadValues("https://localhost:7273/CreateStudent", "POST", reqparm);

            }
        }
        public void Update(Student model)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("StudentCard", $"{model.StudentCard}");
                reqparm.Add("Group", $"{model.Group}");
                reqparm.Add("CourseNumber", $"{model.CourseNumber}");
                reqparm.Add("University", $"{model.University}");
                reqparm.Add("IndividualsId", $"{model.IndividualsId}");

                web.UploadValues("https://localhost:7273/UpdateStudent", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("https://localhost:7273/DeleteStudent", "DELETE", reqparm);

            }
        }
    }
}
