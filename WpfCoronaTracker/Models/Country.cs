using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCoronaTracker.Models
{
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<State> States { get; set; }

        public Country( string code, string name )
        {
            Code = code;
            Name = name;
            States = new List<State>();
        }
    }
}
