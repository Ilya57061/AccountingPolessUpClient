using AccountingPolessUp.Configurations;
using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace AccountingPolessUp.Implementations
{
    public class RoleService
    {
        private readonly WebClient _webClient;
        public RoleService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<Role> Get()
        {
            var json = _webClient.DownloadString("GetRoles");
            var Info = JsonConvert.DeserializeObject<List<Role>>(json);
            if (Info is null) throw new Exception("Roles - null");
            else return Info;
        }
    }
}
