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
    internal class DepartmentService
    {
        public List<Department> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"http://127.0.0.1:5000/GetDepartment";
                var json = web.DownloadString(url);
                List<Department> Info = JsonConvert.DeserializeObject<List<Department>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(Department model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("FullName", $"{model.FullName}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("DateStart", $"{model.DateStart}");
                reqparm.Add("DateEnd", $"{model.DateEnd}");
                reqparm.Add("Status", $"{model.Status}");
                reqparm.Add("OrganizationId", $"{model.OrganizationId}");


                web.UploadValues("http://127.0.0.1:5000/CreateDepartment", "POST", reqparm);

            }
        }
        public void Update(Department model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("FullName", $"{model.FullName}");
                reqparm.Add("Description", $"{model.Description}");
                reqparm.Add("DateStart", $"{model.DateStart}");
                reqparm.Add("DateEnd", $"{model.DateEnd}");
                reqparm.Add("Status", $"{model.Status}");
                reqparm.Add("OrganizationId", $"{model.OrganizationId}");
                web.UploadValues("http://127.0.0.1:5000/UpdateDepartment", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("http://127.0.0.1:5000/DeleteDepartment", "DELETE", reqparm);

            }
        }
    }
}
