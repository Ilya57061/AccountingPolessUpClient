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
                BaseAddress = "https://polessu.by/polessup/",
                Headers = { ["Authorization"] = "Bearer " + TokenManager.AccessToken }
            };
            _webClient.Encoding = System.Text.Encoding.UTF8;
        }

        public List<Role> Get()
        {
            var json = _webClient.DownloadString("GetRoles");
            var Info = JsonConvert.DeserializeObject<List<Role>>(json);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }
    }
}
