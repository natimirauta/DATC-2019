﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;



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

            Console.WriteLine("Token is: " + credentials.Token.AccessToken);

        }

        static void Main(string[] args)
        {
            init();
        }

    }
}
