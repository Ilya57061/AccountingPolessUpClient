﻿using AccountingPolessUp.Configurations;
using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace AccountingPolessUp.Implementations
{
    public class OrganizationService
    {
        private readonly WebClient _webClient;

        public OrganizationService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<Organization> Get()
        {
            var json = _webClient.DownloadString("GetOrganization");
            var Info = JsonConvert.DeserializeObject<List<Organization>>(json);
            if (Info is null) throw new Exception("organizations - null");
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
