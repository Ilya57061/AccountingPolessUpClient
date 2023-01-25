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
    public class RankService
    {
        public List<Rank> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetRank";
                var json = web.DownloadString(url);
                List<Rank> Info = JsonConvert.DeserializeObject<List<Rank>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(Rank model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("RankName", $"{model.RankName}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("OrganizationId", $"{model.OrganizationId}");


                web.UploadValues("https://localhost:7273/CreateRank", "POST", reqparm);

            }
        }
        public void Update(Rank model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("RankName", $"{model.RankName}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("OrganizationId", $"{model.OrganizationId}");
                web.UploadValues("https://localhost:7273/UpdateRank", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("https://localhost:7273/DeleteRank", "DELETE", reqparm);

            }
        }
    }
}
