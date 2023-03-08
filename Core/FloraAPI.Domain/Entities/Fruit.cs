using FloraAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraAPI.Domain.Entities
{
    public class Fruit:BaseEntity
    {
        public string Color { get; set; }
        public bool Scent { get; set; }
        public string Shape { get; set; }

        public Tree Tree { get; set; }
    }
}
