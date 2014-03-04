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

namespace SuT.PMAPI.Types.v1
{
    public class SubscriberResponse : EndpointResponse
    {
        public UInt32 id { get; internal set; }
        public string email { get; internal set; }
        public string msisdn { get; internal set; }
        public bool emailsuspended { get; internal set; }
        public bool smssuspended { get; internal set; }
        public string emailmd5 { get; internal set; }
        public UInt32 subscription_count { get; internal set; }
        public object list_id { get; internal set; }
        public object confirmed { get; internal set; }
        public bool contact_exists { get; internal set; }
        public bool bounce_exists { get; internal set; }
        public object latestopenip { get; internal set; }
        public DateTime cdate { get; internal set; }
        public DateTime mdate { get; internal set; }
        public string title { get; internal set; }
        public string firstname { get; internal set; }
        public string lastname { get; internal set; }
        public string companyname { get; internal set; }
        public string gender { get; internal set; }
        public string housenumber { get; internal set; }
        public string streetname { get; internal set; }
        public string town { get; internal set; }
        public string county { get; internal set; }
        public string postcode { get; internal set; }
        public string country { get; internal set; }
        public UInt32? daybirth { get; internal set; }
        public UInt32? monthbirth { get; internal set; }
        public UInt32? yearbirth { get; internal set; }

        public override string debugLine()
        {
            return "id: " + id + ", list_id: " + list_id + ", email: " + email + ", name: " + firstname + " " + lastname;
        }
    }
}
