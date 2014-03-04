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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Reflection;
using System.Configuration;
using SuT.PMAPI.Responses;
using SuT.PMAPI.Types.v1;
using RestSharp;

namespace SuT.PMAPI.Types.v1
{
    public abstract class Request<ResponseType>
    {
        protected Hashtable _properties = new Hashtable();
        protected PMAPIClient client;
        protected readonly int version = 1;
        public bool reverse = false;
        private string endpoint;
        public string start;
        protected int maxCount = 200;
        private RestRequest request = new RestRequest();

        private uint? _count;
        public uint? count
        {
            get
            {
                return _count;
            }
            set
            {
                if ((value > maxCount) || value < 0)
                {
                    throw new PMAPIRequestInvalidCount(value.ToString());
                }
                _count = value;
            }
        }

        public SortFields sortFields = new SortFields();
        public string _sortby;

        public string sortby
        {
            get
            {
                return _sortby;
            }
            set
            {
                if (sortFields.isSupported(value))
                {
                    _sortby = value;
                }
                else
                {
                    throw new PMAPIRequestInvalidSort(value);
                }
            }
        }

        public Request(string endpointName, PMAPIClient c)
        {
            client = c;
            endpoint = endpointName;

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            // String identifier = ConfigurationManager.AppSettings["Identifier"];
            string identifier = "C# library v0.1"; // FIXME 

            request.AddHeader("Library", identifier);
            request.Resource = getResource();
        }

        protected void setProperty<T>(string property, T value)
        {
            _properties.Add(property, value);
        }

        protected T getProperty<T>(string property)
        {
            assertPropertySet(property);
            return (T)_properties[property];
        }

        private string getPropertyAsString(string property)
        {
            assertPropertySet(property);
            return _properties[property].ToString();
        }

        protected bool isPropertySet(string property)
        {
            return _properties.ContainsKey(property);
        }

        protected void assertPropertySet(string property)
        {
            if (!_properties.ContainsKey(property))
            {
                throw new PMAPIRequestPropertyNotSetException(property);
            }
        }

        protected string getResource()
        {
            return "v" + version + "/" + endpoint;
        }

        private void setupDefaultRequest<CanVerbAttribute, MandatoryVerbAttribute, MandatoryVerbMultipleAttribute>(RestSharp.Method method)       // FIXME - choose better name for this method
        {
            request.Method = method;

            // Get the type of the class and it's properties
            Type classType = this.GetType();
            PropertyInfo[] properties = classType.GetProperties();

            List<string> mandatoryMultiples = new List<string>();

            // Go through each property
            foreach (PropertyInfo property in properties)
            {
                string propertyName = property.Name;

                // If the property has the attribute 'MandatoryVerbMultipleAttribute' then it means that it must be set
                // unless another MandatoryVerbMultipleAttribute property is set already.
                if (Attribute.IsDefined(property, typeof(MandatoryVerbMultipleAttribute)))
                {
                    mandatoryMultiples.Add(propertyName);
                }
            
                if (Attribute.IsDefined(property, typeof(CanVerbAttribute)))
                {
                    // If it's set, then add it to the request
                    if (isPropertySet(propertyName))
                    {
                        request.AddParameter(propertyName, getPropertyAsString(propertyName));
                    }
                }

                if (Attribute.IsDefined(property, typeof(MandatoryVerbAttribute)) && !isPropertySet(propertyName))
                {
                    // A mandatory property is not set, throw an exception.
                    throw new PMAPIRequestMissingPropertyException(propertyName);
                }
                
                if (!Attribute.IsDefined(property, typeof(CanVerbAttribute)))
                {
                    // This property should not be set. To avoid confusion, we will make sure that
                    // the property is not set.                    
                    if (isPropertySet(propertyName))
                    {
                        throw new PMAPIRequestPropertyNotAllowedWithVerbException(propertyName);
                    }
                }
            }
            if (mandatoryMultiples.Count > 0)
            {
                Boolean mandatoryMultiplesCheckPassed = false;
                foreach (string checkPropertyName in mandatoryMultiples)
                {
                    if (isPropertySet(checkPropertyName))
                    {
                        mandatoryMultiplesCheckPassed = true;
                        break;
                    }
                }
                if (!mandatoryMultiplesCheckPassed)
                {
                    throw new PMAPIRequestMissingPropertyException(string.Join(", ", mandatoryMultiples.ToArray())); // FIXME - needs own exception
                }
            }
        }

        public PMAPIResponse<ResponseType> get()
        {
            setupDefaultRequest<CanGetAttribute, MandatoryGetAttribute, MandatoryGetMultipleAttribute>(Method.GET);

            if (sortby != null)
            {
                request.AddParameter("sort", sortby);
            }

            if (count != null)
            {
                request.AddParameter("count", count);
            }

            if (start != null)
            {
                request.AddParameter("start", start);
            }

            if (reverse)
            {
                request.AddParameter("reverse", "1");
            }

            return makeRequest<ResponseType>(request, HttpStatusCode.OK);
        }

        public PMAPIResponse<ResponseType> post()
        {
            setupDefaultRequest<CanPostAttribute, MandatoryPostAttribute, MandatoryPostMultipleAttribute>(Method.POST);
            return makeRequest<ResponseType>(request, HttpStatusCode.Accepted);
        }

        public PMAPIResponse<ResponseType> put()
        {
            setupDefaultRequest<CanPutAttribute, MandatoryPutAttribute, MandatoryPutMultipleAttribute>(Method.PUT);
            return makeRequest<ResponseType>(request, HttpStatusCode.OK);
        }

        public PMAPIResponse<ResponseType> delete()
        {
            setupDefaultRequest<CanDeleteAttribute, MandatoryDeleteAttribute, MandatoryDeleteMultipleAttribute>(Method.DELETE);
            return makeRequest<ResponseType>(request, HttpStatusCode.OK);
        }

        private PMAPIResponse<T> makeRequest<T>(RestRequest request, HttpStatusCode expectedHttpSuccessCode)
        {
            // Make the request
            IRestResponse restResponse = client.RestClient.Execute(request);

            var response = new PMAPIResponse<T>();
            var deserializer = new RestSharp.Deserializers.JsonDeserializer();

            if (restResponse.StatusCode == expectedHttpSuccessCode)
            {
                try
                {
                    response.Data = deserializer.Deserialize<PMAPIResponseSuccessEnvelope<T>>(restResponse);
                }
                catch (System.FormatException)
                {
                    throw new PMAPIRequestUnexpectedDataFormatException();
                }
            }
            else
            {
                var errorEnvelope = deserializer.Deserialize<PMAPIResponseErrorEnvelope>(restResponse);
                response.Error = errorEnvelope.response;
            }

            return response;
        }

        protected void setSortFields(params string[] fields)
        {
            foreach (string field in fields)
            {
                sortFields.addField(field);
            }
        }

        public void displayPermissionTable()
        {
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("| {0, 59} |", getResource());
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("| {0,-40} | {1,-3} | {2,-4} | {3,-3} |", "Field", "Get", "Post", "Put");
            Console.WriteLine("+-------------------------------------------------------------+");

            Type classType = this.GetType();
            PropertyInfo[] properties = classType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                string propertyName = property.Name;

                Console.WriteLine(
                    "| {0,-40} | {1,-3} | {2,-4} | {2,-3} |",
                    propertyName,
                    (Attribute.IsDefined(property, typeof(MandatoryGetAttribute)) ? "Req" : (Attribute.IsDefined(property, typeof(CanGetAttribute)) ? "Yes" : "No")),
                    (Attribute.IsDefined(property, typeof(MandatoryPostAttribute)) ? "Req" : (Attribute.IsDefined(property, typeof(MandatoryPostAttribute)) ? "Yes" : "No")),
                    (Attribute.IsDefined(property, typeof(MandatoryPutAttribute)) ? "Req" : (Attribute.IsDefined(property, typeof(MandatoryPutAttribute)) ? "Yes" : "No"))
                );
            }
            Console.WriteLine("+-------------------------------------------------------------+");
        }
    }

    /* These attributes allow us to define how the endpoint behaves on GET/PUT/POST/DELETE */
    public class CanGetAttribute : Attribute { }
    public class CanSortAttribute : Attribute { }
    public class CanPostAttribute : Attribute { }
    public class CanPutAttribute : Attribute { }
    public class CanDeleteAttribute : Attribute { }
    public class MandatoryGetAttribute : Attribute { }
    public class MandatoryGetMultipleAttribute : Attribute { }
    public class MandatoryPostAttribute : Attribute { }
    public class MandatoryPutMultipleAttribute : Attribute { }
    public class MandatoryPostMultipleAttribute : Attribute { }
    public class MandatoryPutAttribute : Attribute { }
    public class MandatoryDeleteAttribute : Attribute { }
    public class MandatoryDeleteMultipleAttribute : Attribute { }
}
