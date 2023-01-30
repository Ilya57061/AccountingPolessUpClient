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
    public class PositionService
    {
        public List<Position> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"https://polessu.by/polessup/GetPosition";
                var json = web.DownloadString(url);
                List<Position> Info = JsonConvert.DeserializeObject<List<Position>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(Position model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("FullName", $"{model.FullName}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("DepartmentId", $"{model.DepartmentId}");

                web.UploadValues("https://polessu.by/polessup/CreatePosition", "POST", reqparm);

            }
        }
        public void Update(Position model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("FullName", $"{model.FullName}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("DepartmentId", $"{model.DepartmentId}");
                web.UploadValues("https://polessu.by/polessup/UpdatePosition", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("https://polessu.by/polessup/DeletePosition", "DELETE", reqparm);

            }
        }
    }
}
