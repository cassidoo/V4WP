using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json; // This is gonna come from an external parsing library

namespace VenmoBackend
{

    // All the main jazz.  Should generally work, if hooked up right. ;)
    public class VenmoWork
    {
        public enum USER_TYPE { USER_ID, PHONE, EMAIL };
        public int clientID { get; private set; }
        public string clientSecret { get; private set; }
        public string userAccessToken { get; private set; }
        public string userAccessTokenQueryString
        {
            get
            {
                return "?access_token=" + userAccessToken;
            }
        }
        public bool loggedIn { get; private set; }

        string venmoAuthUrl = "https://api.venmo.com/oauth/access_token";
        string venmoPaymentUrl = "https://api.venmo.com/payments";
        string venmoUserUrl = "https://api.venmo.com/users/{0}";
        string venmoFriendsUrl = "https://api.venmo.com/users/{0}/friends";
        string venmoMeUrl = "https://api.venmo.com/me";


        public VenmoWork(int clientID, string clientSecret)
        {
            this.clientID = clientID;
            this.clientSecret = clientSecret;
            loggedIn = false;
        }

        public VenmoWork(int clientID, string clientSecret, string userAccessToken)
        {
            this.clientID = clientID;
            this.clientSecret = clientSecret;
            this.userAccessToken = userAccessToken;
            loggedIn = true;
        }

        private async Task<string> PostTransaction(string recipient, string note, double sendAmount)
        {
            string postData = "access_token=" + userAccessToken + "&" + recipient + "&note=" + note + "&amount=" + sendAmount;
            return await VenmoPost(venmoPaymentUrl, postData);
        }

        private async Task<string> VenmoGet(string url, string queryString)
        {
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(url + queryString);
            webRequest.Method = "GET";
            var webResponse = (HttpWebResponse)(await Task<WebResponse>.Factory.FromAsync(webRequest.BeginGetResponse, (Func<IAsyncResult, WebResponse>)webRequest.BetterEndGetResponse, null));

            string responseCode = webResponse.StatusCode.ToString();
            string response = GetContentFromWebResponse(webResponse);

            errorCheck(responseCode, response);

            return response;
        }

        private async Task<string> VenmoPost(string url, string postData)
        {
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";

            var reqStream = await Task<Stream>.Factory.FromAsync(webRequest.BeginGetRequestStream, webRequest.EndGetRequestStream, null);

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            reqStream.Write(byteArray, 0, byteArray.Length);

            var webResponse = (HttpWebResponse)(await Task<WebResponse>.Factory.FromAsync(webRequest.BeginGetResponse, (Func<IAsyncResult, WebResponse>)webRequest.BetterEndGetResponse, null));

            string responseCode = webResponse.StatusCode.ToString();
            string response = GetContentFromWebResponse(webResponse);

            errorCheck(responseCode, response);

            return response;
        }

        // JsonConvert stuff comes from the external library

        private async Task<string> LogIn(string accessCode)
        {
            string postData = "client_id=" + clientID + "&client_secret=" + clientSecret + "&code=" + accessCode;
            string venmoResponse = await VenmoPost(venmoAuthUrl, postData);

            Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object>>(venmoResponse);
            userAccessToken = (string)results["access_token"];
            loggedIn = true;

            return results["user"].ToString(); ;
        }


        public void errorCheck(string responseCode, string response)
        {
            if (responseCode != "OK")
            {
                var definition = new { message = "", code = 0 };
                Dictionary<string, object> message = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
                var error = JsonConvert.DeserializeAnonymousType(message["error"].ToString(), definition);
                throw new Exception(error.message);
            }
        }

        public string GetContentFromWebResponse(HttpWebResponse response)
        {
            using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = httpWebStreamReader.ReadToEnd();
                return result;
            }
        }

        public void logOut()
        {
            userAccessToken = "";
            loggedIn = false;
        }

    }

    // User stuff.  Self explanatory.
    public class VenmoUser
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string firstname
        {
            get
            {
                return first_name;
            }
            set
            {
                first_name = value;
            }
        }
        public string last_name { get; set; }
        public string lastname
        {
            get
            {
                return last_name;
            }
            set
            {
                last_name = value;
            }
        }
        public string display_name { get; set; }
        public string name
        {
            get
            {
                return display_name;
            }
            set
            {
                display_name = value;
            }
        }
        public string username { get; set; }
        public string date_joined { get; set; }
        public string profile_picture_url { get; set; }
        public string picture
        {
            get
            {
                return profile_picture_url;
            }
            set
            {
                profile_picture_url = value;
            }
        }
        public string about { get; set; }
        public double balance { get; set; }
        public string formattedBalance
        {
            get
            {
                if (balance != null)
                {
                    return balance.ToString("N2");
                }
                return "";
            }
        }
        public string phone { get; set; }
        public string email { get; set; }
    }


    //-----------------------------------------------------------------------
    //
    //     Copyright (c) 2011 Garrett Serack. All rights reserved.
    //
    //
    //     The software is licensed under the Apache 2.0 License (the "License")
    //     You may not use the software except in compliance with the License.
    //
    //-----------------------------------------------------------------------
    public static class WebRequestExtension
    {
        public static WebResponse BetterEndGetResponse(this WebRequest request, IAsyncResult asyncResult)
        {
            try
            {
                return request.EndGetResponse(asyncResult);
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    return wex.Response;
                }
                throw;
            }
        }
    }

}