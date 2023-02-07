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
    public class RegulationService
    {
        private readonly WebClient _webClient;
        public RegulationService()
        {
            _webClient = new WebClient
            {
                BaseAddress = "https://polessu.by/polessup/",
                Headers = { ["Authorization"] = "Bearer " + TokenManager.AccessToken }
            };
            _webClient.Encoding = System.Text.Encoding.UTF8;
        }

        public List<Regulation> Get()
        {
            var json = _webClient.DownloadString("GetRegulation");
            var Info = JsonConvert.DeserializeObject<List<Regulation>>(json);
            if (Info is null) throw new Exception("info - null");
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
