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
    public class UserRequest : Request<UserResponse>
    {
        [CanGet]
        [CanPut]
        [MandatoryPut]
        [CanDelete]
        [MandatoryDelete]
        public UInt32 id
        {
            get { return getProperty<UInt32>("id"); }
            set { setProperty<UInt32>("id", value); }
        }

        [CanPut]
        [CanPost]
        public Boolean active
        {
            get { return getProperty<Boolean>("active"); }
            set { setProperty<Boolean>("active", value); }
        }

        [CanGet]
        public Boolean currentuser
        {
            get { return getProperty<Boolean>("currentuser"); }
            set { setProperty<Boolean>("currentuser", value); }
        }

        [CanPut]
        [CanPost]
        [MandatoryPost]
        public System.Net.Mail.MailAddress email
        {
            get { return getProperty<System.Net.Mail.MailAddress>("email"); }
            set { setProperty<System.Net.Mail.MailAddress>("email", value); }
        }

        [CanPut]
        [CanPost]
        [MandatoryPost]
        public String firstname
        {
            get { return getProperty<String>("firstname"); }
            set { setProperty<String>("firstname", value); }
        }

        [CanPut]
        [CanPost]
        public String msisdn
        {
            get { return getProperty<String>("msisdn"); }
            set { setProperty<String>("msisdn", value); }
        }

        [CanPost]
        [MandatoryPost]
        public String password
        {
            get { return getProperty<String>("password"); }
            set { setProperty<String>("password", value); }
        }

        [CanPost]
        [MandatoryPost]
        public String lastname
        {
            get { return getProperty<String>("lastname"); }
            set { setProperty<String>("lastname", value); }
        }

        [CanPut]
        [CanPost]
        [MandatoryPost]
        public String username
        {
            get { return getProperty<String>("username"); }
            set { setProperty<String>("username", value); }
        }

        public UserRequest(PMAPIClient c)
            : base("user", c)            
        {
            setSortFields("id", "cdate");
        }
    }
}
