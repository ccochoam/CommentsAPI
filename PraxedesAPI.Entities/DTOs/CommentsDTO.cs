using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraxedesAPI.Entities.DTOs
{
    public class CommentsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostId { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
