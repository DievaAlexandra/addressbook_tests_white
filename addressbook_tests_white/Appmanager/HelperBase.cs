using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;

namespace addressbook_tests_white
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WINTITLE;


        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            
        }
    }
}