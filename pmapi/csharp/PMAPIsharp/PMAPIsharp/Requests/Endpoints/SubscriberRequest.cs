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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuT.PMAPI.Responses;
using SuT.PMAPI.Types.v1;

namespace SuT.PMAPI.Types.v1
{
    public class SubscriberRequest : Request<SubscriberResponse>
    {
        [CanGet]
        [CanPut]
        [CanDelete]
        [MandatoryPut]
        [MandatoryDelete]
        public UInt32? id
        {
            get { return getProperty<UInt32?>("id"); }
            set { setProperty<UInt32?>("id", value); }
        }

        [CanGet]
        [CanPut]
        [CanPost]
        [MandatoryPostMultiple]
        public System.Net.Mail.MailAddress email
        {
            get { return getProperty<System.Net.Mail.MailAddress>("email"); }
            set { setProperty<System.Net.Mail.MailAddress>("email", value); }
        }

        [CanGet]
        [CanPut]
        [CanPost]
        [MandatoryPostMultiple]
        public string msisdn
        {
            get { return getProperty<string>("msisdn"); }
            set { setProperty<string>("msisdn", value); }
        }

        [CanPut]
        [CanPost]
        public bool emailsuspended
        {
            get { return getProperty<Boolean>("emailsuspended"); }
            set { setProperty<Boolean>("emailsuspended", value); }
        }

        [CanGet]
        [CanPut]
        [CanPost]
        [MandatoryPost]
        public UInt32? list_id
        {
            get { return getProperty<UInt32?>("list_id"); }
            set { setProperty<UInt32?>("list_id", value); }
        }

        [CanPut]
        [CanPost]
        public bool confirmed
        {
            get { return getProperty<Boolean>("confirmed"); }
            set { setProperty<Boolean>("confirmed", value); }
        }

        [CanPut]
        [CanPost]
        public string title
        {
            get { return getProperty<string>("title"); }
            set { setProperty<string>("title", value); }
        }

        [CanPut]
        [CanPost]
        public string firstname
        {
            get { return getProperty<string>("firstname"); }
            set { setProperty<string>("firstname", value); }
        }

        [CanPut]
        [CanPost]
        public string lastname
        {
            get { return getProperty<string>("lastname"); }
            set { setProperty<string>("lastname", value); }
        }

        [CanPut]
        [CanPost]
        public string companyname
        {
            get { return getProperty<string>("companyname"); }
            set { setProperty<string>("companyname", value); }
        }

        [CanPut]
        [CanPost]
        public string gender
        {
            get { return getProperty<string>("gender"); }
            set { setProperty<string>("gender", value); }
        }

        [CanPut]
        [CanPost]
        public string housenumber
        {
            get { return getProperty<string>("housenumber"); }
            set { setProperty<string>("housenumber", value); }
        }

        [CanPut]
        [CanPost]
        public string streetname
        {
            get { return getProperty<string>("streetname"); }
            set { setProperty<string>("streetname", value); }
        }

        [CanPut]
        [CanPost]
        public string town
        {
            get { return getProperty<string>("town"); }
            set { setProperty<string>("town", value); }
        }

        [CanPut]
        [CanPost]
        public string county
        {
            get { return getProperty<string>("county"); }
            set { setProperty<string>("county", value); }
        }

        [CanPut]
        [CanPost]
        public string postcode
        {
            get { return getProperty<string>("postcode"); }
            set { setProperty<string>("postcode", value); }
        }

        [CanPut]
        [CanPost]
        public string country
        {
            get { return getProperty<string>("country"); }
            set { setProperty<string>("country", value); }
        }

        [CanPut]
        [CanPost]
        public UInt32? daybirth
        {
            get { return getProperty<UInt32?>("daybirth"); }
            set { setProperty<UInt32?>("daybirth", value); }
        }

        [CanPut]
        [CanPost]
        public UInt32? monthbirth
        {
            get { return getProperty<UInt32?>("monthbirth"); }
            set { setProperty<UInt32?>("monthbirth", value); }
        }

        [CanPut]
        [CanPost]
        public UInt32? yearbirth
        {
            get { return getProperty<UInt32?>("yearbirth"); }
            set { setProperty<UInt32?>("yearbirth", value); }
        }

        public SubscriberRequest(PMAPIClient c)
            : base("subscriber", c)
        {
            setSortFields("id", "email", "msisdn", "cdate");
        }
    }
}
