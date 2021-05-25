using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThknApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public bool IsItThere { get; set; }
        public bool IsItFood { get; set; }
        public int AppUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
