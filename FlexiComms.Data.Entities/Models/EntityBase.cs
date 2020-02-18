using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiComms.Data.Entities.Models
{
    public static class EntityBase
    {
        public static DateTime DateCreated { get; set; }

        public static string CreatedBy { get; set; }

        public static DateTime DateModified { get; set; }

        public static string ModifiedBy { get; set; }
    }
}
