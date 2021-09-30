using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryAPI.AptitudeCore
{
    public sealed class DbResponse<TResult> : DbResponseBase<TResult> where TResult : class
    {
        public OutputParameter OutPutParameters { get; set; }
    }
}