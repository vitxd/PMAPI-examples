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
    public class TaskResponse : EndpointResponse
    {
        public UInt32 id { get; internal set; }
        public UInt32 message_id { get; internal set; }
        public string name { get; internal set; }
        public UInt32 size { get; internal set; }
        public string channel { get; internal set; }
        public bool completed { get; internal set; }
        public bool cancelled { get; internal set; }
        public int scheduledtime { get; internal set; }
        public UInt32? endtime { get; internal set; }
        public int cdate { get; internal set; }
        public UInt32? rate { get; internal set; }
        public UInt32? list_id { get; internal set; }
        public UInt32? search_id { get; internal set; }
        public UInt32? splittest_id { get; internal set; }
        public UInt32? emailuniqueopens { get; internal set; }
        public UInt32? emailuniqueclicks { get; internal set; }
        public UInt32? emailuniquebounces { get; internal set; }
        public UInt32? emailuniqueunsubscriptions { get; internal set; }
        public UInt32? emailuniquecomplaints { get; internal set; }
        public UInt32? smsuniquebounces { get; internal set; }

        public override string debugLine()
        {
            return "id: " + id ;
        }
    }
}
