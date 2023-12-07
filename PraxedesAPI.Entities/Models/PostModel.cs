using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraxedesAPI.Entities.Models
{
    public class PostModel
    {
        public long? UserId { get; set; }

        public long? Id { get; set; }

        public string? Title { get; set; }

        public string? Body { get; set; }
    }
}
