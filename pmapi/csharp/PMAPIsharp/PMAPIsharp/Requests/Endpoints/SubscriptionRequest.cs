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
    public class SubscriptionRequest : Request<SubscriptionResponse>
    {
        [CanGet]
        [MandatoryGetMultiple]
        [CanPut]
        [MandatoryPut]
        [CanDelete]
        [MandatoryDeleteMultiple]
        public UInt32 id
        {
            get { return getProperty<UInt32>("id"); }
            set { setProperty<UInt32>("id", value); }
        }
        
        [CanPost]
        public String confirmationredirect
        {
            get { return getProperty<String>("confirmationredirect"); }
            set { setProperty<String>("confirmationredirect", value); }
        }

        [CanGet]
        [MandatoryGetMultiple]
        [CanPost]
        [MandatoryPost]
        public Boolean confirmed
        {
            get { return getProperty<Boolean>("confirmed"); }
            set { setProperty<Boolean>("confirmed", value); }
        }

        [CanGet]
        [MandatoryGetMultiple]
        [CanPost]
        [MandatoryPost]
        [CanDelete]
        [MandatoryDeleteMultiple]
        public UInt32 list_id
        {
            get { return getProperty<UInt32>("list_id"); }
            set { setProperty<UInt32>("list_id", value); }
        }

        [CanGet]
        [MandatoryGetMultiple]
        [CanPost]
        [MandatoryPost]
        [CanDelete]
        [MandatoryDeleteMultiple]
        public UInt32 subscriber_id
        {
            get { return getProperty<UInt32>("subscriber_id"); }
            set { setProperty<UInt32>("subscriber_id", value); }
        }

        public SubscriptionRequest(PMAPIClient c)
            : base("subscription", c)            
        {
            setSortFields("id", "cdate");
        }
    }
}
