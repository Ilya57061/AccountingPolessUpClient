using AccountingPolessUp.Configurations;
using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace AccountingPolessUp.Implementations
{
    public class FinalProjectService
    {
        private readonly WebClient _webClient;
        public FinalProjectService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<FinalProject> Get()
        {
            var json = _webClient.DownloadString("GetFinalProject");
            var finalProject = JsonConvert.DeserializeObject<List<FinalProject>>(json);
            if (finalProject == null) throw new Exception("FinalProject - null");
            return finalProject;
        }

        public List<FinalProject> GetByEmployment(int employmentId)
        {
            var request = new NameValueCollection { ["id"] = $"{employmentId}" };
            var response = _webClient.UploadValues("GetFinalProjectForEmploymentId", "PUT", request);
            var responseString = Encoding.Default.GetString(response);
            var finalProject = JsonConvert.DeserializeObject<List<FinalProject>>(responseString);
            if (finalProject == null) throw new Exception("FinalProject - null");
            return finalProject;

        }

        public void Create(FinalProject model)
        {
            var request = new NameValueCollection
            {
                ["Name"] = $"{model.Name}",
                ["Description"] = $"{model.Description}",
                ["GitHub"] = $"{model.GitHub}",
                ["Links"] = $"{model.Links}",
                ["DateStart"] = $"{model.DateStart}",
                ["DateEnd"] = $"{model.DateEnd}",
                ["EmploymentId"] = $"{model.EmploymentId}"
            };
            _webClient.UploadValues("CreateFinalProject", "POST", request);
        }

        public void Update(FinalProject model)
        {
            var request = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["Name"] = $"{model.Name}",
                ["Description"] = $"{model.Description}",
                ["GitHub"] = $"{model.GitHub}",
                ["Links"] = $"{model.Links}",
                ["DateStart"] = $"{model.DateStart}",
                ["DateEnd"] = $"{model.DateEnd}",
                ["EmploymentId"] = $"{model.EmploymentId}"
            };
            _webClient.UploadValues("UpdateFinalProject", "PUT", request);
        }

        public void Delete(int id)
        {
            var request = new NameValueCollection { ["id"] = $"{id}" };
            _webClient.UploadValues("DeleteFinalProject", "DELETE", request);
        }
    }
}