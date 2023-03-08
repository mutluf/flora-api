using FloraAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraAPI.Domain.Entities
{
    public class Farmer:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Tree> Trees { get; set; }
    }
}
