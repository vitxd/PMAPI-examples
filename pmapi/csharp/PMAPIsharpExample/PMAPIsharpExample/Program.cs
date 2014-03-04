/*
 *  Part of the Sign-Up.to Permission Marketing API v0.1 Redistributable
 *
 *
 *  Copyright (c) 2013 Sign-Up Technologies Ltd.
 *  All rights reserved.
 *
 *  Redistribution and use in source and binary forms, with or without
 *  modification, are permitted provided that the following conditions are met:
 *
 *  1. Redistributions of source code must retain the above copyright notice, this
 *     list of conditions and the following disclaimer.
 *  2. Redistributions in binary form must reproduce the above copyright notice,
 *     this list of conditions and the following disclaimer in the documentation
 *     and/or other materials provided with the distribution.
 *
 *  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 *  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 *  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 *  DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
 *  ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 *  (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 *  LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 *  ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 *  (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 *  SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SuT.PMAPI;
using SuT.PMAPI.Responses;
using SuT.PMAPI.Types.v1;
using SuT.PMAPI.Authenticators;

/*
 * This basic example makes a call to the folder endpoint to either retrieve
 * a list of folders or create a new folder.
 */

namespace PMAPIsharpExample
{
    class Program
    {
        public static int Main(string[] args)
        {
            if(args.Length < 2)
            {
                Console.WriteLine("Usage: {0} [username] [password] [optional folder name to create]", System.AppDomain.CurrentDomain.FriendlyName);
                return 1;
            }

            var example = new PMAPIExample(args[0], args[1]);

            if(args.Length == 3)
            {
                // The third argument implies that we should create a folder.
                example.CreateFolder(args[2]);
            }
            else
            {
                example.GetFolders();
            }

            return 0;
        }
    }

    class PMAPIExample
    {
        private SuT.PMAPI.PMAPIClient client;
        
        public PMAPIExample(string username, string password)
        {
            try
            {
                SuT.PMAPI.PMAPITokenGenerator tokenGenerator = new SuT.PMAPI.PMAPITokenGenerator(username, password);
                client = new SuT.PMAPI.PMAPIClient(new TokenAuthenticator(tokenGenerator.getToken()));
            }
            catch(SuT.PMAPI.PMAPITokenAuthorizationException exception)
            {
                Console.WriteLine("ERROR: Unable to authenticate, please check your details and try again.");
                Environment.Exit(1);
            }
        }

        public void CreateFolder(string folderName)
        {
            FolderRequest request = new FolderRequest(client);
            request.name = folderName;

            var apiResponse = request.post();
            if(apiResponse.IsSuccess())
            {
                Console.WriteLine("Created folder, id: {0} name:{1}", apiResponse.Data.response.data[0].id, apiResponse.Data.response.data[0].name);
            }
            else
            {
                Console.WriteLine("ERROR: Unable to create folder.");
            }
        }

        public void GetFolders()
        {
            FolderRequest request = new FolderRequest(client);
                
            var apiResponse = request.get();

            DisplayFolderItems(apiResponse);

            // If "next" is not null, then there are more records that can be retrieved.
            // Retrieve all the available folders.
            while (apiResponse.Data.response.next != null)
            { 
                request.start = apiResponse.Data.response.next.ToString();
                DisplayFolderItems(request.get());
            }
        }

        public void DisplayFolderItems(PMAPIResponse<FolderResponse> apiResponse)
        {
            if (apiResponse.IsSuccess())
            {
                var response = apiResponse.Data.response;
                if (response.count > 0)
                {
                    foreach (var item in response.data)
                    {
                        Console.WriteLine("id:{0}\tfolder name:{1}", item.id, item.name);
                    }
                }
                else
                {
                    Console.WriteLine("No results returned\n");
                }
            }
            else
            {
                Console.WriteLine("ERROR: request failed.");
            }
        }
    }
}

