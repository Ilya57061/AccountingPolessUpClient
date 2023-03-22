using AccountingPolessUp.Configurations;
using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace AccountingPolessUp.Implementations
{
    public class RegulationService
    {
        private readonly WebClient _webClient;
        public RegulationService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<Regulation> Get()
        {
            var json = _webClient.DownloadString("GetRegulation");
            var Info = JsonConvert.DeserializeObject<List<Regulation>>(json);
            if (Info is null) throw new Exception("Regulation - null");
            else return Info;
        }

        public void Create(Regulation model)
        {
            var reqparm = new NameValueCollection
            {
                ["Text"] = $"{model.Text}",
                ["Name"] = $"{model.Name}",
                ["Description"] = $"{model.Description}",
                ["OrganizationId"] = $"{model.OrganizationId}"
            };
            _webClient.UploadValues("CreateRegulation", "POST", reqparm);
        }

        public void Update(Regulation model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["Text"] = $"{model.Text}",
                ["Name"] = $"{model.Name}",
                ["Description"] = $"{model.Description}",
                ["OrganizationId"] = $"{model.OrganizationId}"
            };
            _webClient.UploadValues("UpdateRegulation", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{id}"
            };
            _webClient.UploadValues("DeleteRegulation", "DELETE", reqparm);
        }
    }
}
