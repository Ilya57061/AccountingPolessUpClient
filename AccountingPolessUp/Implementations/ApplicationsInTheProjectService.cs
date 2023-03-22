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
    public class ApplicationsInTheProjectService
    {
        private readonly WebClient _webClient;

        public ApplicationsInTheProjectService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<ApplicationsInTheProject> Get()
        {
            var json = _webClient.DownloadString("GetAppInTheProject");
            var applicationsInTheProject = JsonConvert.DeserializeObject<List<ApplicationsInTheProject>>(json);
            if (applicationsInTheProject is null) throw new Exception("applicationsInTheProject - null");
            return applicationsInTheProject;
        }
        public List<ApplicationsInTheProject> Get(int vacancyId)
        {
            var reqparm = new NameValueCollection
            {
                ["vacancyId"] = $"{vacancyId}"
            };
            var response = _webClient.UploadValues("GetAppInTheProjectForVacancyId", "PUT", reqparm);
            var responseString = Encoding.Default.GetString(response);
            var Info = JsonConvert.DeserializeObject<List<ApplicationsInTheProject>>(responseString);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }

        public void Create(ApplicationsInTheProject model)
        {
            var reqparm = new NameValueCollection
            {

                ["DateEntry"] = $"{model.DateEntry}",
                ["ParticipantsId"] = $"{model.ParticipantsId}",
                ["IsAccepted"] = $"{model.IsAccepted}",
                ["Status"] = $"{model.Status}",
                ["StatusDescription"] = $"{model.StatusDescription}",
                ["VacancyId"] = $"{model.VacancyId}"
            };
            _webClient.UploadValues("CreateAppInTheProject", "POST", reqparm);
        }

        public void Update(ApplicationsInTheProject model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",

                ["DateEntry"] = $"{model.DateEntry}",
                ["ParticipantsId"] = $"{model.ParticipantsId}",
                ["IsAccepted"] = $"{model.IsAccepted}",
                ["Status"] = $"{model.Status}",
                ["StatusDescription"] = $"{model.StatusDescription}",
                ["VacancyId"] = $"{model.VacancyId}"
            };
            _webClient.UploadValues("UpdateAppInTheProject", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{id}"
            };
            _webClient.UploadValues("DeleteAppInTheProject", "DELETE", reqparm);
        }
    }
}
