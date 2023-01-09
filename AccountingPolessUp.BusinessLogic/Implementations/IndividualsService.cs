using AccountingPolessUp.Common.Models;
using Newtonsoft.Json;
using System.Net;


namespace AccountingPolessUp.BusinessLogic.Implementations
{
    public class IndividualsService
    {
        public List<Individuals> Get()
        {
            using (WebClient web = new WebClient())
            {
                string url = $"https://localhost:7058/Buy/GetCategory";
                var json = web.DownloadString(url);
                List<Individuals> Info = JsonConvert.DeserializeObject<List<Individuals>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Update(string name, int count)
        {
            using (WebClient web = new WebClient())
            {
                string url = $"https://localhost:7058/Buy/UpdateDrug?name={name}&count={count}";
                web.UploadString(url, "PUT");
            }
        }
    }
}
