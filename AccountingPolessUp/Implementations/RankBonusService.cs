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
    public class RankBonusService
    {
        private readonly WebClient _webClient;
        public RankBonusService()
        {
            _webClient = new WebClient
            {
                BaseAddress = "https://localhost:5001/",
                Headers = { ["Authorization"] = "Bearer " + TokenManager.AccessToken }
            };
            _webClient.Encoding = System.Text.Encoding.UTF8;
        }
        public List<RankBonus> Get()
        {
            var json = _webClient.DownloadString("GetRankBonus");
            var Info = JsonConvert.DeserializeObject<List<RankBonus>>(json);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }
        public void Create(RankBonus model)
        {
            var reqparm = new NameValueCollection
            {
                ["RankId"] = $"{model.RankId}",
                ["BonusId"] = $"{model.BonusId}",
                
            };
            _webClient.UploadValues("CreateRankBonus", "POST", reqparm);
        }
        public void Edit(RankBonus model)
        {
            var reqparm = new NameValueCollection
            {
                ["Id"] = $"{model.Id}",
                ["RankId"] = $"{model.RankId}",
                ["BonusId"] = $"{model.BonusId}",

            };
            _webClient.UploadValues("UpdateRankBonus", "PUT", reqparm);
        }
        public void Delete(int id)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{id}"
            };
            _webClient.UploadValues("DeleteRankBonus", "DELETE", reqparm);
        }
    }
}
