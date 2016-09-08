﻿// Copyright 2007-2016 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace GreenPipes.Policies
{
    using System;
    using System.Threading.Tasks;
    using Util;


    public class NoRetryContext<T> :
        RetryContext<T>
        where T : class
    {
        public NoRetryContext(T context, Exception exception)
        {
            Context = context;
            Exception = exception;
        }

        public T Context { get; }
        public Exception Exception { get; }

        public int RetryCount => 1;
        public int RetryAttempt => 1;

        public TimeSpan? Delay => default(TimeSpan?);

        public Task PreRetry()
        {
            return TaskUtil.Completed;
        }

        public Task PostRetry()
        {
            return TaskUtil.Completed;
        }

        public Task RetryFaulted(Exception exception)
        {
            return TaskUtil.Completed;
        }

        public bool CanRetry(Exception exception, out RetryContext<T> retryContext)
        {
            retryContext = this;

            return false;
        }
    }
}