﻿using AccountingPolessUp.Configurations;
using AccountingPolessUp.Models;
using AccountingPolessUp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace AccountingPolessUp.Implementations
{
    public class PositionService
    {
        private readonly WebClient _webClient;
        public PositionService()
        {
            _webClient = new WebClient
            {
                BaseAddress = WebClientConfiguration.BaseAdress,
                Headers = WebClientConfiguration.Headers,
                Encoding = WebClientConfiguration.Encoding
            };
        }

        public List<Position> Get()
        {
            var json = _webClient.DownloadString("GetPosition");
            var position = JsonConvert.DeserializeObject<List<Position>>(json);
            if (position is null) throw new Exception("position  - null");
            return position;
        }
        public List<Position> Get(int departmentId)
        {
            var reqparm = new NameValueCollection
            {
                ["departmentId"] = $"{departmentId}"
            };
            var response = _webClient.UploadValues("GetPositionForDepartmentId", "PUT", reqparm);
            var responseString = Encoding.Default.GetString(response);
            var position = JsonConvert.DeserializeObject<List<Position>>(responseString);
            if (position is null) throw new Exception("position by departmentId - null");
            return position;


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
        public List<Position> GetFiltered(PositionFilter model)
        {
            var reqparm = new NameValueCollection
            {
                ["Name"] = $"{model.Name}",
                ["Department"] = $"{model.Department}"
            };
            var response = _webClient.UploadValues("GetFiltredPositions", "PUT", reqparm);
            var responseString = Encoding.Default.GetString(response);
            var positions = JsonConvert.DeserializeObject<List<Position>>(responseString);
            if (positions is null) throw new Exception("Positions - null");
            else return positions;
        }
    }
}
