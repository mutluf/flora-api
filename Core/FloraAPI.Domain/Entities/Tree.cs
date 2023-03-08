using FloraAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraAPI.Domain.Entities
{
    public class Tree: BaseEntity
    {//farmer ım vardı aslında d diğer yerden ekldeim hem de 2 tane 2si de ben
        public string Color { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
        public ICollection<Fruit> Fruits { get; set; }
    }
}
