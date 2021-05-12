using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Examples
{
    public interface IAuthorize
    {
        public bool Authorize(string name, string passwd);
    }
}
