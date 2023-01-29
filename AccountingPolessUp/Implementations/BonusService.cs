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
    public class BonusService
    {
        public List<Bonus> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/GetBonus";
                var json = web.DownloadString(url);
                List<Bonus> Info = JsonConvert.DeserializeObject<List<Bonus>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public List<Bonus> Get(int rankId)
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://localhost:7273/BonusForRankId?id={rankId}";
                var json = web.DownloadString(url);
                List<Bonus> Info = JsonConvert.DeserializeObject<List<Bonus>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(Bonus model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("BonusName", $"{model.BonusName}");
                reqparm.Add("BonusDescription", $"{ model.BonusDescription}");
                reqparm.Add("RankId", $"{model.RankId}");


                web.UploadValues("https://localhost:7273/CreateBonus", "POST", reqparm);

            }
        }
        public void Update(Bonus model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("BonusName", $"{model.BonusName}");
                reqparm.Add("BonusDescription", $"{model.BonusDescription}");
                reqparm.Add("RankId ", $"{model.RankId}");
                web.UploadValues("https://localhost:7273/UpdateBonus", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("https://localhost:7273/DeleteBonus", "DELETE", reqparm);

            }
        }
    }
}
