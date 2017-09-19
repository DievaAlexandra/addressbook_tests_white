using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        
        private GroupHelper groupHelper;
        public ApplicationManager()
        {
            Application app = Application.Launch(@"C:\Program Files (x86)\Free Address Book\AddressBook.exe");
            MAinWindow =  app.GetWindow(WINTITLE);
            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            MAinWindow.Get<Button>("uxExitAddressButton").Click();
        }


        public Window MAinWindow { get; set; }



        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
    }

}
