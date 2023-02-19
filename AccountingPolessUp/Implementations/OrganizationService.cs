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
    public class OrganizationService
    {
        private readonly WebClient _webClient;

        public OrganizationService()
        {
            _webClient = new WebClient
            {
                BaseAddress = "https://polessu.by/polessup/",
                Headers = { ["Authorization"] = "Bearer " + TokenManager.AccessToken }
            };
            _webClient.Encoding = System.Text.Encoding.UTF8;
        }

        public List<Organization> Get()
        {
            var json = _webClient.DownloadString("GetOrganization");
            var Info = JsonConvert.DeserializeObject<List<Organization>>(json);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }

        public void Create(Organization model)
        {
            var reqparm = new NameValueCollection
            {
                ["Fullname"] = $"{model.Fullname}",
                ["Address"] = $"{model.Address}",
                ["Contacts"] = $"{model.Contacts}",
                ["WebSite"] = $"{model.WebSite}",
                ["BSR"] = $"{model.BSR}",
                ["FoundationDate"] = $"{model.FoundationDate}"
            };
            _webClient.UploadValues("CreateOrganization", "POST", reqparm);
        }

        public void Update(Organization model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["Fullname"] = $"{model.Fullname}",
                ["Address"] = $"{model.Address}",
                ["Contacts"] = $"{model.Contacts}",
                ["WebSite"] = $"{model.WebSite}",
                ["BSR"] = $"{model.BSR}",
                ["FoundationDate"] = $"{model.FoundationDate}"
            };
            _webClient.UploadValues("UpdateOrganization", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{id}"
            };
            _webClient.UploadValues("DeleteOrganization", "DELETE", reqparm);
        }
    }

}
