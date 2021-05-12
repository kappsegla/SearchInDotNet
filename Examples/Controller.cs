using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Examples
{
    public class Controller
    {
        private readonly IAuthorize authorize;

        public Controller(IAuthorize authorize)
        {
            this.authorize = authorize;
        }

        public string Index()
        {
            return "";
        }

        public string GetInformation(string name, string pass)
        {
            if (authorize.Authorize(name, pass))
            {
                return "Secret information";
            }
            return "Not authorized";
        }
    }
}
