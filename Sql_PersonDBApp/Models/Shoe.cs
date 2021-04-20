using System;
using System.Collections.Generic;

#nullable disable

namespace Sql_PersonDBApp.Models
{
    public partial class Shoe
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public virtual Person Person { get; set; }
    }
}
