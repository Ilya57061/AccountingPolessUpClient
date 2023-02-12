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
    public class PositionService
    {
        private readonly WebClient _webClient;
        public PositionService()
        {
            _webClient = new WebClient
            {
                BaseAddress = "https://localhost:5001/",
                Headers = { ["Authorization"] = "Bearer " + TokenManager.AccessToken }
            };
            _webClient.Encoding = System.Text.Encoding.UTF8;
        }

        public List<Position> Get()
        {
            var json = _webClient.DownloadString("GetPosition");
            var Info = JsonConvert.DeserializeObject<List<Position>>(json);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }
        public List<Position> Get(int departmentId)
        {
            var reqparm = new NameValueCollection
            {
                ["departmentId"] = $"{departmentId}"
            };
            var response = _webClient.UploadValues("GetPositionForDepartmentId", "PUT", reqparm);
            var responseString = Encoding.Default.GetString(response);
            var Info = JsonConvert.DeserializeObject<List<Position>>(responseString);
            if (Info is null) throw new Exception("info - null");
            else return Info;
        }

        public void Create(Position model)
        {
            var reqparm = new NameValueCollection
            {
                ["FullName"] = $"{model.FullName}",
                ["Description"] = $"{model.Description}",
                ["DepartmentId"] = $"{model.DepartmentId}"
            };
            _webClient.UploadValues("CreatePosition", "POST", reqparm);
        }

        public void Update(Position model)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{model.Id}",
                ["FullName"] = $"{model.FullName}",
                ["Description"] = $"{model.Description}",
                ["DepartmentId"] = $"{model.DepartmentId}"
            };
            _webClient.UploadValues("UpdatePosition", "PUT", reqparm);
        }

        public void Delete(int id)
        {
            var reqparm = new NameValueCollection
            {
                ["id"] = $"{id}"
            };
            _webClient.UploadValues("DeletePosition", "DELETE", reqparm);
        }
    }
}
