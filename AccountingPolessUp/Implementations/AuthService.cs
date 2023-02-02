using System;
using System.Net;
using System.Net.Http;
using System.Text;
using AccountingPolessUp.Models;
using AccountingPolessUp.ViewModels;
using Newtonsoft.Json;

namespace AccountingPolessUp.Implementations
{
    
    public class AuthService
    {

        public User Login(LoginDto loginModel)
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
                    TokenDto token = JsonConvert.DeserializeObject<TokenDto>(responseString);
                    TokenManager.AccessToken = token.Token;
                    return token.User;
                }
            }
            catch (Exception)
            {

                return null;
            }
           
        }
    }
}
