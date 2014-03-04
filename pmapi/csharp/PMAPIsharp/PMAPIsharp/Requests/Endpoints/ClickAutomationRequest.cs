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
    public class ClickAutomationRequest : Request<ClickAutomationResponse>
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
        [CanPut]
        [CanPost]
        public Boolean actiononweekend
        {
            get { return getProperty<Boolean>("actiononweekend"); }
            set { setProperty<Boolean>("actiononweekend", value); }
        }
        
        [CanPut]
        [CanPost]
        [MandatoryPost]
        public String actiontarget
        {
            get { return getProperty<String>("actiontarget"); }
            set { setProperty<String>("actiontarget", value); }
        }

        [CanPut]
        [CanPost]        
        public String actionhour
        {
            get { return getProperty<String>("actionhour"); }
            set { setProperty<String>("actionhour", value); }
        }

        [CanPut]
        [CanPost]
        public UInt32 actiontimediff
        {
            get { return getProperty<UInt32>("actiontimediff"); }
            set { setProperty<UInt32>("actiontimediff", value); }
        }

        [CanPut]
        [CanPost]
        [MandatoryPost]
        public String actiontype
        {
            get { return getProperty<String>("actiontype"); }
            set { setProperty<String>("actiontype", value); }
        }

        [CanPut]
        [CanPost]
        public UInt32 link_id
        {
            get { return getProperty<UInt32>("link_id"); }
            set { setProperty<UInt32>("link_id", value); }
        }

        [CanPut]
        [CanPost]
        public UInt32 message_id
        {
            get { return getProperty<UInt32>("message_id"); }
            set { setProperty<UInt32>("message_id", value); }
        }

        [CanGet]
        [CanPut]
        [CanPost]
        [MandatoryPost]
        public String name
        {
            get { return getProperty<String>("name"); }
            set { setProperty<String>("name", value); }
        }

        [CanGet]
        [CanPut]
        [CanPost]
        public Boolean paused
        {
            get { return getProperty<Boolean>("paused"); }
            set { setProperty<Boolean>("paused", value); }
        }

        [CanPut]
        [CanPost]
        [MandatoryPost]
        public String summary
        {
            get { return getProperty<String>("summary"); }
            set { setProperty<String>("summary", value); }
        }

        [CanGet]
        public UInt32 user_id
        {
            get { return getProperty<UInt32>("user_id"); }
            set { setProperty<UInt32>("user_id", value); }
        }

        public ClickAutomationRequest(PMAPIClient c)
            : base("clickautomation", c)            
        {
            setSortFields("id", "actionhour", "actiontimediff", "name", "cdate");
        }
    }
}
