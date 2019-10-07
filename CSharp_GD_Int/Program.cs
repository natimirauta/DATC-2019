﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Net;
using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Newtonsoft.Json.Linq;
// missing libraries



namespace CSharp_GD_Int
{
    class Program
    {

        private static DriveService _service;
        private static string _token;

        static void init(){

            string[] scopes = new string[]{

                DriveService.Scope.Drive,
                DriveService.Scope.DriveFile

            };

            var clientID = "210295401760-rg1cisrkke2csu3m3bpskmr26h2e9okl.apps.googleusercontent.com";
            var clientSecret = "cztXJagKeSVv-XFvHOQNrW0H";

            var credentials = GoogleWebAuthorizationBroker.AuthorizeAsync(

                new ClientSecrets
                {

                    ClientId = clientID,
                    ClientSecret = clientSecret

                },
                scopes,
                Environment.UserName,
                CancellationToken.None,
                // new FileDataStore("Daimto.GoogleDrive.Auth.Store")
                null

            ).Result;

            _token = credentials.Token.AccessToken;
            Console.WriteLine("Token is: " + _token);

        }

        static void GetMyFiles(){
            
            var request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/drive/v3/files");
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + _token);

                using (var response = request.GetResponse())
                {

                    using (Stream data = response.GetResponseStream())
                    
                    using (var reader = new StreamReader(data))
                    {

                        string text = reader.ReadToEnd();
                        var myData = JObject.Parse(text);
                        
                        // Console.WriteLine(text);

                        foreach(var file in myData["files"])
                        {

                            // Console.WriteLine(file);
                            if(file["mimeType"].ToString() != "application/vnd.google-apps.folder")
                            {

                                Console.WriteLine("File name: " + file["name"]);

                            }

                        }

                    }

                }

        }


        static void Main(string[] args)
        {
            init();
            GetMyFiles();
        }

    }
}
