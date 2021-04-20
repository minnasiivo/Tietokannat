using System;
using System.Collections.Generic;

#nullable disable

namespace Sql_PersonDBApp.Models
{
    public partial class Phone
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public string Phonenumber { get; set; }

        public virtual Person Person { get; set; }
    }
}
