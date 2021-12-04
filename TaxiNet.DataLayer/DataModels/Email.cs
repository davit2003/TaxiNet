using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiNet.DataLayer
{
    public class Email
    {
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string EmailAddress { get; set; }

        [StringLength(200)]
        public string Text { get; set; }

        public DateTime SendTime { get; set; }
    }
}
