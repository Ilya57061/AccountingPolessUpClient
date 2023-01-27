using System;
using System.Net;
using System.Net.Http;
using System.Text;
using AccountingPolessUp.Models;
using AccountingPolessUp.ViewModels;
using Newtonsoft.Json;

namespace AccountingPolessUp.Implementations
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
    public class LoginService
    {

        public User Login(LoginModel loginModel)
        {
            try
            {
                using (WebClient web = new WebClient())
                {

                    System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                    reqparm.Add("Login", $"{loginModel.Login}");
                    reqparm.Add("Password", $"{loginModel.Password}");
                    var response = web.UploadValues("https://localhost:7273/Login", "POST", reqparm);
                    var responseString = Encoding.Default.GetString(response);
                    User user = JsonConvert.DeserializeObject<User>(responseString);
                    return user;
                }
            }
            catch (Exception)
            {

                return null;
            }
           
        }
    }
}
