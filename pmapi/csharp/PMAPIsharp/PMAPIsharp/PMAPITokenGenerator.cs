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
﻿using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using SuT.PMAPI.Responses;
using SuT.PMAPI.Types.v1;
using SuT.PMAPI.Authenticators;

namespace SuT.PMAPI
{
    public class PMAPITokenGenerator
    {
        protected Hashtable parameters = new Hashtable();
        protected string endpoint = "v1/token";
        protected string server = "https://api.sign-up.to";

        public PMAPITokenGenerator(string username, string password, string serverURL = null)
        {
            if (serverURL != null)
            {
                server = serverURL;
            }

            parameters.Add("username", username);
            parameters.Add("password", password);
        }

        public SuTToken getToken()
        {
            // Set up the POST request object.
            var request = new RestRequest();
            request.AddHeader("Accept", "application/json");
            request.Method = Method.POST;

            // Set the endpoint
            request.Resource = this.endpoint;

            // Iterate over the parameters and set them accordingly.
            foreach (string key in this.parameters.Keys)
            {
                request.AddParameter(key, (string)this.parameters[key]);
            }

            // Create the rest client and execute the request
            RestClient client = new RestClient(this.server);
            IRestResponse restResponse = client.Execute(request);

            var response = new PMAPIResponse<Token>();

            if (restResponse.StatusCode == HttpStatusCode.Accepted)
            {
                var deserializer = new RestSharp.Deserializers.JsonDeserializer();
                response.Data = deserializer.Deserialize<PMAPIResponseSuccessEnvelope<Token>>(restResponse);
                // TODO - we don't know if deserializer worked.
            }
            else if (restResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new PMAPITokenAuthorizationException(restResponse.ErrorMessage);
            }
            else
            {
                throw new PMAPITokenException(restResponse.ErrorMessage);
            }

            var data = response.Data.response.data[0];
            string token = data.token;
            uint expiry = data.expiry;

            return new SuTToken(token, expiry);
        }
    }
}
