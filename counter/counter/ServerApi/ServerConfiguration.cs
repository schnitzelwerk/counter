using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace counter
{
    public class ServerConfiguration
    {
        public ServerConfiguration()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, "settings.txt");
            if (System.IO.File.Exists(filePath))
            {
                string[] serverConfigList = System.IO.File.ReadAllLines(filePath);
                ServerUrl = serverConfigList[0];
                Username = serverConfigList[1];
                Password = serverConfigList[2];
            }
            else
            {
                var fs = new FileStream(filePath, FileMode.Create);
                fs.Dispose();
                ServerUrl = "url";
                Username = "user";
                Password = "password";
                string[] serverConfigList = { ServerUrl, Username, Password };
                File.WriteAllLines(filePath, serverConfigList);
            }
        SessionId = 0;
        }
            
        public UInt32 SessionId { get; set; }
        public string ServerUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
