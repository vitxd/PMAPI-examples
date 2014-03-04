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
    public class EmailMessageRequest : Request<EmailMessageResponse>
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

        [CanGet]
        public Boolean editable
        {
            get { return getProperty<Boolean>("editable"); }
            set { setProperty<Boolean>("editable", value); }
        }

        [CanPut]
        [CanPost]
        [MandatoryPost]
        public string fromemail
        {
            get { return getProperty<string>("fromemail"); }
            set { setProperty<string>("fromemail", value); }
        }

        [CanPut]
        [CanPost]
        [MandatoryPost]
        public string fromname
        {
            get { return getProperty<string>("fromname"); }
            set { setProperty<string>("fromname", value); }
        }

        [CanPut]
        [CanPost]
        public Boolean galinkdata
        {
            get { return getProperty<Boolean>("galinkdata"); }
            set { setProperty<Boolean>("galinkdata", value); }
        }

        [CanPut]
        [CanPost]
        [MandatoryPost]
        public string html
        {
            get { return getProperty<string>("html"); }
            set { setProperty<string>("html", value); }
        }

        [CanGet]
        [CanPut]
        [CanPost]
        [MandatoryPost]
        public string name
        {
            get { return getProperty<string>("name"); }
            set { setProperty<string>("name", value); }
        }

        [CanPut]
        [CanPost]
        [MandatoryPost]
        public string replyemail
        {
            get { return getProperty<string>("name"); }
            set { setProperty<string>("name", value); }
        }

        [CanPut]
        [CanPost]
        public Boolean friendlink
        {
            get { return getProperty<Boolean>("friendlink"); }
            set { setProperty<Boolean>("friendlink", value); }
        }

        [CanPut]
        [CanPost]
        [MandatoryPost]
        public string subject
        {
            get { return getProperty<string>("subject"); }
            set { setProperty<string>("subject", value); }
        }

        [CanPut]
        [CanPost]
        [MandatoryPost]
        public string text
        {
            get { return getProperty<string>("text"); }
            set { setProperty<string>("text", value); }
        }

        [CanPut]
        [CanPost]
        public Boolean tracktextlinks
        {
            get { return getProperty<Boolean>("tracktextlinks"); }
            set { setProperty<Boolean>("tracktextlinks", value); }
        }

        [CanGet]
        public Boolean used
        {
            get { return getProperty<Boolean>("used"); }
            set { setProperty<Boolean>("used", value); }
        }

        public EmailMessageRequest(PMAPIClient c)
            : base("emailmessage", c)            
        {
            setSortFields("id", "name", "cdate");
        }
    }
}
