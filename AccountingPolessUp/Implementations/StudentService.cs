
using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace AccountingPolessUp.Implementations
{
    public class StudentService
    {
        private readonly WebClient _webClient;
        public StudentService()
        {
            _webClient = new WebClient
            {
                BaseAddress = "https://polessu.by/polessup/",
                Headers = { ["Authorization"] = "Bearer " + TokenManager.AccessToken }
            };
            _webClient.Encoding = System.Text.Encoding.UTF8;
        }

        public List<Student> Get()
        {
            var json = _webClient.DownloadString("GetStudents");
            var Info = JsonConvert.DeserializeObject<List<Student>>(json);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }

        public Student GetByIndividuals(int individualsId)
        {
            var reqparm = new NameValueCollection
            {
                ["individualsId"] = $"{individualsId}"
            };
            var response = _webClient.UploadValues("StudentByIndividuals", "POST", reqparm);
            var responseString = Encoding.Default.GetString(response);
            var student = JsonConvert.DeserializeObject<Student>(responseString);
            return student;
        }

        public void Create(Student model)
        {
            var reqparm = new NameValueCollection
            {
                ["StudentCard"] = $"{model.StudentCard}",
                ["Group"] = $"{model.Group}",
                ["CourseNumber"] = $"{model.CourseNumber}",
                ["University"] = $"{model.University}",
                ["IndividualsId"] = $"{model.IndividualsId}"
            };

            _webClient.UploadValues("CreateStudent", "POST", reqparm);
        }

        public void Update(Student model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["StudentCard"] = $"{model.StudentCard}",
                ["Group"] = $"{model.Group}",
                ["CourseNumber"] = $"{model.CourseNumber}",
                ["University"] = $"{model.University}",
                ["IndividualsId"] = $"{model.IndividualsId}"
            };
            _webClient.UploadValues("UpdateStudent", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            try
            {
                var reqparm = new NameValueCollection
                {
                    ["id"] = $"{id}"
                };
                _webClient.UploadValues("DeleteStudent", "DELETE", reqparm);
            }
            catch (Exception)
            {

            }
        }
    }
}
