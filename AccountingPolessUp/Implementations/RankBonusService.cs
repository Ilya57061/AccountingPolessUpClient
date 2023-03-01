using AccountingPolessUp.Configurations;
using AccountingPolessUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }
        public List<RankBonus> Get()
        {
            var json = _webClient.DownloadString("GetRankBonus");
            var Info = JsonConvert.DeserializeObject<List<RankBonus>>(json);
            if (Info is null) throw new Exception("RankBonuses - null");
            else return Info;
        }
        public void Create(RankBonus model)
        {
            try
            {
                var reqparm = new NameValueCollection
                {
                    ["RankId"] = $"{model.RankId}",
                    ["BonusId"] = $"{model.BonusId}",
                };
                _webClient.UploadValues("CreateRankBonus", "POST", reqparm);
            }
            catch (Exception)
            {

                throw new Exception("Ошибка при создании связи RankBonus");
            }
          
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
        public void Delete(int rankId, int bonusId)
        {
            var reqparm = new NameValueCollection
            {
                ["RankId"] = $"{rankId}",
                ["BonusId"] = $"{bonusId}"
            };
            _webClient.UploadValues("DeleteRankBonus", "DELETE", reqparm);
        }
    }
}
