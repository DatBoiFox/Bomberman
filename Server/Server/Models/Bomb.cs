using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Bomb
    {
        [Key]
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
    }
}
