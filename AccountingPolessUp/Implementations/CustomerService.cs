using AccountingPolessUp.Configurations;
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
    public class CustomerService
    {
        private readonly WebClient _webClient;

        public CustomerService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<Customer> Get()
        {
            var json = _webClient.DownloadString("GetCustomer");
            var Info = JsonConvert.DeserializeObject<List<Customer>>(json);
            if (Info is null) throw new Exception("Customers - null");
            else return Info;
        }

        public void Create(Customer model)
        {
            var reqparm = new NameValueCollection
            {
                ["FullName"] = $"{model.FullName}",
                ["Address"] = $"{model.Address}",
                ["Contacts"] = $"{model.Contacts}",
                ["WebSite"] = $"{model.WebSite}",
                ["Description"] = $"{model.Description}"
            };
            _webClient.UploadValues("CreateCustomer", "POST", reqparm);
        }

        public void Update(Customer model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["FullName"] = $"{model.FullName}",
                ["Address"] = $"{model.Address}",
                ["Contacts"] = $"{model.Contacts}",
                ["WebSite"] = $"{model.WebSite}",
                ["Description"] = $"{model.Description}"
            };
            _webClient.UploadValues("UpdateCustomer", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            try
            {
                var reqparm = new NameValueCollection
                {
                    ["id"] = $"{id}"
                };
                _webClient.UploadValues("DeleteCustomer", "DELETE", reqparm);
            }
            catch (Exception)
            {

            }
            
        }
    }
}
