﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace counter
{
    public class RestService : IRestService
    {
        HttpClient client;
        String authData;
        String authHeaderValue;

        public RestService()
        {
            configHttpClient();
        }

        public void configHttpClient()
        {
            authData = string.Format("{0}:{1}", App.Settings.Username, App.Settings.Password);
            authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task<List<Food>> GetFoodListAsync()
        {
            List<Food> menuFoodList = new List<Food>();

            var uri = new Uri(string.Format(App.Settings.RestUrl + "?cmd=getF", string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    menuFoodList = JsonConvert.DeserializeObject<List<Food>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return menuFoodList;
        }

        public async Task<UInt32> Register()
        {
            var uri = new Uri(string.Format(App.Settings.RestUrl + "?cmd=addF", string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                
                response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var respContent = await response.Content.ReadAsStringAsync();
                    var respItem = JsonConvert.DeserializeObject<FellowItem>(respContent);
                    item.ID = respItem.ID;
                    Fellows.Add(item);
                }
                
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Fellow successfully added.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return 0;
        }
    }
}