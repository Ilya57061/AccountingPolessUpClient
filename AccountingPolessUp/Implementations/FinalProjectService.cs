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
    public class FinalProjectService
    {
        private readonly WebClient _webClient;
        public FinalProjectService()
        {
            _webClient = new WebClient
            {
                BaseAddress = "https://localhost:5001/",
                Headers = { ["Authorization"] = "Bearer " + TokenManager.AccessToken }
            };
            _webClient.Encoding = System.Text.Encoding.UTF8;
        }

        public List<FinalProject> Get()
        {
            var json = _webClient.DownloadString("GetFinalProject");
            List<FinalProject> Info = JsonConvert.DeserializeObject<List<FinalProject>>(json);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }

        public List<FinalProject> GetByEmployment(int employmentId)
        {
            var request = new NameValueCollection { ["id"] = $"{employmentId}" };
            var response = _webClient.UploadValues("GetFinalProjectForEmploymentId", "PUT", request);
            var responseString = Encoding.Default.GetString(response);
            List<FinalProject> list = JsonConvert.DeserializeObject<List<FinalProject>>(responseString);
            return list;
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