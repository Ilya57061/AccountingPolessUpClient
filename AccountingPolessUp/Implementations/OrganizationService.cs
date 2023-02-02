using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPolessUp.Implementations
{
    public class OrganizationService
    {
        public List<Organization> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetOrganization";
                var json = web.DownloadString(url);
                List<Organization> Info = JsonConvert.DeserializeObject<List<Organization>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(Organization model)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Fullname", $"{model.Fullname}");
                reqparm.Add("Address", $"{model.Address}");
                reqparm.Add("Contacts", $"{model.Contacts}");
                reqparm.Add("WebSite", $"{model.WebSite}");
                reqparm.Add("FoundationDate", $"{model.FoundationDate}");


                web.UploadValues("https://localhost:7273/CreateOrganization", "POST", reqparm);

            }
        }
        public void Update(Organization model)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("Fullname", $"{model.Fullname}");
                reqparm.Add("Address", $"{model.Address}");
                reqparm.Add("Contacts", $"{model.Contacts}");
                reqparm.Add("WebSite", $"{model.WebSite}");
                reqparm.Add("FoundationDate", $"{model.FoundationDate}");
                web.UploadValues("https://localhost:7273/UpdateOrganization", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                web.Headers.Add("Authorization", "Bearer " + TokenManager.AccessToken);
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("https://localhost:7273/DeleteOrganization", "DELETE", reqparm);

            }
        }
    }
}
