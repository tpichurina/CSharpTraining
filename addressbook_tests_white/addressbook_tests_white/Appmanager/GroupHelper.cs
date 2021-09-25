using System.Windows.Automation;
using System.Collections.Generic;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialog();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });

            }
            CloseGroupsDialog(dialogue);
            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialog();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox)dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialog(dialogue);
        }

        private void CloseGroupsDialog(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        private Window OpenGroupsDialog()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }

        public void Remove(GroupData toBeRemoved)
        {

            Window dialogue = OpenGroupsDialog();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode toRemove = tree.Nodes[0].Nodes.Find(n => n.Name == toBeRemoved.Name);
            toRemove.Focus();
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            dialogue.ModalWindow("Delete group").Get<Button>("uxOKAddressButton").Click();
            CloseGroupsDialog(dialogue);
        }

        public bool IsMoreThenOne()
        {
            Window dialogue = OpenGroupsDialog();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            bool result = tree.Nodes[0].Nodes.Count > 1;
            CloseGroupsDialog(dialogue);
            return result;
        }
    }
}
