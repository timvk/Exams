using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamPowered.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int? GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
