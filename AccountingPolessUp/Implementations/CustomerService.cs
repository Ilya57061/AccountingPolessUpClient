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
    public class CustomerService
    {
        public List<Customer> Get()
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                string url = $"http://127.0.0.1:5000/GetCustomer";
                var json = web.DownloadString(url);
                List<Customer> Info = JsonConvert.DeserializeObject<List<Customer>>(json);
                if (Info is null) throw new Exception("info - null");
                else return Info;
            }
        }
        public void Create(Customer model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("FullName", $"{model.FullName}");
                reqparm.Add("Address", $"{model.Address}");
                reqparm.Add("Contracts", $"{model.Contacts}");
                reqparm.Add("WebSite", $"{model.WebSite}");
                reqparm.Add("Description", $"{model.Description}");


                web.UploadValues("http://127.0.0.1:5000/CreateCustomer", "POST", reqparm);

            }
        }
        public void Update(Customer model)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{model.Id}");
                reqparm.Add("FullName", $"{model.FullName}");
                reqparm.Add("Address", $"{model.Address}");
                reqparm.Add("Contracts", $"{model.Contacts}");
                reqparm.Add("WebSite", $"{model.WebSite}");
                reqparm.Add("Description", $"{model.Description}");
                web.UploadValues("http://127.0.0.1:5000/UpdateCustomer", "PUT", reqparm);

            }
        }
        public void Delete(int id)
        {
            using (WebClient web = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("id", $"{id}");
                web.UploadValues("http://127.0.0.1:5000/DeleteCustomer", "DELETE", reqparm);

            }
        }
    }
}
