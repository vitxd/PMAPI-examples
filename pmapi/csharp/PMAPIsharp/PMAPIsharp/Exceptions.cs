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

namespace SuT.PMAPI
{
    public class PMAPIException : System.Exception
    {
        public PMAPIException() : base() { }
        public PMAPIException(string message) : base(message) { }
    }

    public class PMAPITokenException : PMAPIException
    {
        public PMAPITokenException() : base() { }
        public PMAPITokenException(string message) : base(message) { }
    }

    public class PMAPITokenAuthorizationException : PMAPIAuthorizationException
    {
        public PMAPITokenAuthorizationException() : base() { }
        public PMAPITokenAuthorizationException(string message) : base(message) { }
    }

    public class PMAPIAuthorizationException : PMAPIException
    {
        public PMAPIAuthorizationException() : base() { }
        public PMAPIAuthorizationException(string message) : base(message) { }
    }
    
    public class PMAPIRequestException : PMAPIException 
    {
        public PMAPIRequestException() : base() { }
        public PMAPIRequestException(string message) : base(message) { }
    }

    public class PMAPIRequestUnexpectedDataFormatException : PMAPIRequestException
    {
        public PMAPIRequestUnexpectedDataFormatException() : base() { }
        public PMAPIRequestUnexpectedDataFormatException(string message) : base(message) { }
    }

    public class PMAPIRequestInvalidCount : PMAPIRequestException
    {
        public PMAPIRequestInvalidCount() : base() { }
        public PMAPIRequestInvalidCount(string message) : base(message) { }
    }

    public class PMAPIRequestInvalidSort : PMAPIRequestException
    {
        public PMAPIRequestInvalidSort() : base() { }
        public PMAPIRequestInvalidSort(string message) : base(message) { }
    }

    public class PMAPIRequestConstructionException : PMAPIRequestException
    {
        public PMAPIRequestConstructionException() : base() { }
        public PMAPIRequestConstructionException(string message) : base(message) { }
    }

    public class PMAPIRequestMissingPropertyException : PMAPIRequestConstructionException
    {
        public PMAPIRequestMissingPropertyException() : base() { }
        public PMAPIRequestMissingPropertyException(string message) : base(message) { }
    }

    public class PMAPIRequestPropertyNotSetException : PMAPIRequestConstructionException
    {
        public PMAPIRequestPropertyNotSetException() : base() { }
        public PMAPIRequestPropertyNotSetException(string message) : base(message) { }
    }

    public class PMAPIRequestPropertyNotAllowedWithVerbException : PMAPIRequestConstructionException
    {
        public PMAPIRequestPropertyNotAllowedWithVerbException() : base() { }
        public PMAPIRequestPropertyNotAllowedWithVerbException(string message) : base(message) { }
    }
}
