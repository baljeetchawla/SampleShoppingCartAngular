﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleShoppingCartAPI.Business
{
    public interface IBaseBusiness
    {
        JObject AddDataOnJson(string message, string result, object jsonValue, bool appendData = true);
    }
}
