using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_6_2_b
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Company Company { get; set; }
        public int Manufacturer { get; set; }
    }
}
