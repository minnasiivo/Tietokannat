using System;
using System.Collections.Generic;

#nullable disable

namespace Sql_PersonDBApp.Models
{
    public partial class ContactInfo
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public string ContactType { get; set; }
        public string Info { get; set; }
        public bool? NotInUse { get; set; }

        public virtual Person Person { get; set; }
    }
}
