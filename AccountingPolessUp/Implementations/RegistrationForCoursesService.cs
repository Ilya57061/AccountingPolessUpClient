using AccountingPolessUp.Configurations;
using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.Implementations
{
    public class RegistrationForCoursesService
    {
        private readonly WebClient _webClient;
        public RegistrationForCoursesService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<RegistrationForCourses> Get()
        {
            var json = _webClient.DownloadString("GetRegistrationForCourses");
            var Info = JsonConvert.DeserializeObject<List<RegistrationForCourses>>(json);
            if (Info is null) throw new Exception("RegistrationForCourses - null");
            else return Info;
        }

        public void Create(RegistrationForCourses model)
        {
            var reqparm = new NameValueCollection
            {
                ["DateEntry"] = $"{model.DateEntry}",
                ["ParticipantsId"] = $"{model.ParticipantsId}",
                ["TrainingCoursesId"] = $"{model.TrainingCoursesId}"
            };
            _webClient.UploadValues("CreateRegistrationForCourses", "POST", reqparm);
        }

        public void Update(RegistrationForCourses model)
        {
            var reqparm = new NameValueCollection
            {
                ["Id"] = $"{model.Id}",
                ["DateEntry"] = $"{model.DateEntry}",
                ["ParticipantsId"] = $"{model.ParticipantsId}",
                ["TrainingCoursesId"] = $"{model.TrainingCoursesId}"
            };
            _webClient.UploadValues("UpdateRegistrationForCourses", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            try
            {
                var reqparm = new NameValueCollection
                {
                    ["id"] = $"{id}"
                };
                _webClient.UploadValues("DeleteRegistrationForCourses", "DELETE", reqparm);
            }
            catch (Exception)
            {

            }
            
        }
    }
}
