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
    public class ApplicationsInTheProjectService
    {
        private readonly WebClient _webClient;

        public ApplicationsInTheProjectService()
        {
            _webClient = new WebClient
            {
                BaseAddress = "https://localhost:7273/",
                Headers = { ["Authorization"] = "Bearer " + TokenManager.AccessToken }
            };
            _webClient.Encoding = System.Text.Encoding.UTF8;
        }

        public List<ApplicationsInTheProject> Get()
        {
            var json = _webClient.DownloadString("GetAppInTheProject");
            var Info = JsonConvert.DeserializeObject<List<ApplicationsInTheProject>>(json);
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
