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
    public class VacancyService
    {
        public List<Vacancy> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"http://127.0.0.1:5000/GetVacancy";
                var json = web.DownloadString(url);
                List<Vacancy> Info = JsonConvert.DeserializeObject<List<Vacancy>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(Vacancy model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Name", $"{model.Name}");
                reqparm.Add("Descriptions", $"{model.Descriptions}");
                reqparm.Add("Responsibilities", $"{model.Responsibilities}");
                reqparm.Add("DateStart", $"{model.DateStart}");
                reqparm.Add("DateEnd", $"{model.DateEnd}");
                reqparm.Add("Budjet", $"{model.Budjet}");
                reqparm.Add("StagesOfProjectId", $"{model.StagesOfProjectId}");


                web.UploadValues("http://127.0.0.1:5000/CreateVacancy", "POST", reqparm);

            }
        }
        public void Update(Vacancy model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("Name", $"{model.Name}");
                reqparm.Add("Descriptions", $"{model.Descriptions}");
                reqparm.Add("Responsibilities", $"{model.Responsibilities}");
                reqparm.Add("DateStart", $"{model.DateStart}");
                reqparm.Add("DateEnd", $"{model.DateEnd}");
                reqparm.Add("Budjet", $"{model.Budjet}");
                reqparm.Add("StagesOfProjectId", $"{model.StagesOfProjectId}");
                web.UploadValues("http://127.0.0.1:5000/UpdateVacancy", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("http://127.0.0.1:5000/DeleteVacancy", "DELETE", reqparm);

            }
        }
    }
}
