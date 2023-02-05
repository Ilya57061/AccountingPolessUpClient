using AccountingPolessUp.Models;
using AccountingPolessUp.ViewModels;
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
    public class BonusService
    {
        private readonly WebClient _webClient;

        public BonusService()
        {
            _webClient = new WebClient
            {
                BaseAddress = "https://localhost:7273/",
                Headers = { ["Authorization"] = "Bearer " + TokenManager.AccessToken }
            };
            _webClient.Encoding = System.Text.Encoding.UTF8;
        }

        public List<Bonus> Get()
        {
            var json = _webClient.DownloadString("GetBonus");
            var Info = JsonConvert.DeserializeObject<List<Bonus>>(json);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }

        public List<Bonus> Get(int rankId)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{rankId}"
            };
            var response = _webClient.UploadValues("BonusForRankId", "POST", reqparm);
            var responseString = Encoding.Default.GetString(response);
            var Info = JsonConvert.DeserializeObject<List<Bonus>>(responseString);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }

        public void Create(Bonus model)
        {
            var reqparm = new NameValueCollection
            {
                ["BonusName"] = $"{model.BonusName}",
                ["BonusDescription"] = $"{model.BonusDescription}",
                ["RankId"] = $"{model.RankId}"
            };
            _webClient.UploadValues("CreateBonus", "POST", reqparm);
        }

        public void Update(Bonus model)
        {
            var reqparm = new NameValueCollection
            {
                ["Id"] = $"{model.Id}",
                ["BonusName"] = $"{model.BonusName}",
                ["BonusDescription"] = $"{model.BonusDescription}",
                ["RankId"] = $"{model.RankId}"
            };
            _webClient.UploadValues("UpdateBonus", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{id}"
            };
            _webClient.UploadValues("DeleteBonus", "DELETE", reqparm);
        }
    }
}
