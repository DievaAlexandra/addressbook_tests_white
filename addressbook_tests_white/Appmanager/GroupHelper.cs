using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string GROUPDELETETITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

       
        //получение списка групп
        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialog = OpenGroupsDialog();
            Tree tree  = dialog.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
          
            CloseGroupsDialog(dialog);
            return list;
        }

       //создание группы
        public void Add(GroupData newGroup)
        {
            Window dialog = OpenGroupsDialog();
            dialog.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox =  (TextBox) dialog.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialog(dialog);

        }

        //удаление группы
        public GroupHelper Remove(GroupData group)
        {
            OpenGroupsDialog(); //открытие окна групп
            SelectGroup(group.Id);//выбор группы
            RemoveGroup();//выбор действия удаления
            ConfirmDeleteGroup();//подтверждение действия Удалить
            return this;
        }

        //открытие диалогового окна групп
        private Window OpenGroupsDialog()
        {
            manager.MAinWindow.Get<Button>("groupButton").Click();
            return manager.MAinWindow.ModalWindow(GROUPWINTITLE);
        }
        
        //выбор действия Удалить
        public GroupHelper RemoveGroup()
        {

            manager.MAinWindow.Get<Button>("uxDeleteAddressButton").Click();//выбор действия Удалить
            manager.MAinWindow.Get<RadioButton>("uxDeleteAllRadioButton").Click(); 
            return this;
        }

        //подтверждение удаления группы
        private void ConfirmDeleteGroup()
        {
            manager.MAinWindow.Get<Button>("uxOKAddressButton").Click(); //клик на "Ок" в диалоговом окне "delete group"
        }
      
        //выбор группы из списка
       public GroupData SelectGroup(string id)
        {
         GroupData groupData = GetGroupList()[1];
         return groupData;
        }

        //закрытие диалогового окна групп
        private void CloseGroupsDialog(Window dialog)
        {
            dialog.Get<Button>("uxCloseAddressButton").Click();
        }

      
    }

   
}