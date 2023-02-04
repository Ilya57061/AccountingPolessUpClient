using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace AccountingPolessUp.Implementations
{
    public class RoleService
    {
        public List<Role> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetRoles";
                var json = web.DownloadString(url);
                List<Role> Info = JsonConvert.DeserializeObject<List<Role>>(json);
                if (Info is null) throw new Exception("info - null");
                return Info;
            }

        }
    }
}
