using AccountingPolessUp.Configurations;
using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace AccountingPolessUp.Implementations
{
    public class TrainingCoursesService
    {
        private readonly WebClient _webClient;
        public TrainingCoursesService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<TrainingCourses> Get()
        {
            var json = _webClient.DownloadString("GetTrainingCourses");
            var Info = JsonConvert.DeserializeObject<List<TrainingCourses>>(json);
            if (Info is null) throw new Exception("TrainingCourses - null");
            else return Info;
        }

        public void Create(TrainingCourses model)
        {
            var reqparm = new NameValueCollection
            {
                ["Name"] = $"{model.Name}",
                ["Description"] = $"{model.Description}",
                ["Link"] = $"{model.Link}",
                ["LectorFIO"] = $"{model.LectorFIO}",
                ["LectorDescription"] = $"{model.LectorDescription}",
                ["DateStart"] = $"{model.DateStart}",
                ["DateEnd"] = $"{model.DateEnd}",
                ["IsActive"] = $"{model.IsActive}"
            };
            _webClient.UploadValues("CreateTrainingCourses", "POST", reqparm);
        }

        public void Update(TrainingCourses model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["Name"] = $"{model.Name}",
                ["Description"] = $"{model.Description}",
                ["Link"] = $"{model.Link}",
                ["LectorFIO"] = $"{model.LectorFIO}",
                ["LectorDescription"] = $"{model.LectorDescription}",
                ["DateStart"] = $"{model.DateStart}",
                ["DateEnd"] = $"{model.DateEnd}",
                ["IsActive"] = $"{model.IsActive}"
            };
            _webClient.UploadValues("UpdateTrainingCourses", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            try
            {
                var reqparm = new NameValueCollection
                {
                    ["id"] = $"{id}"
                };
                _webClient.UploadValues("DeleteTrainingCourses", "DELETE", reqparm);
            }
            catch (Exception)
            {

            }
        }
    }
}
