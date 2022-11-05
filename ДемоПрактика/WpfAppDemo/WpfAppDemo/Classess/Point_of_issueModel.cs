using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDemo.Classess
{
    public class Point_of_issueModel
    {
        public string Address { get; set; }

        public string Number { get; set; }

        public Point_of_issueModel(string address, string number)
        {
            Address = address;
            Number = number;
        }
    }
}
