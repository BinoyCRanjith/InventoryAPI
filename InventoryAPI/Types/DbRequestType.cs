using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryAPI.Types
{
    public enum DbRequestType
    {
        Insert,
        Update,
        Delete,
        Select,
        Scalar
    }
}
