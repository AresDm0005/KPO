using System.Windows.Forms;

namespace TreeViewApp
{
    class CustomMenu : ContextMenu
    {
        public TreeNode SourceNode { get; }

        public CustomMenu() : base() { }

        public CustomMenu(MenuItem[] items) : base(items) { }

        public CustomMenu(MenuItem[] items, TreeNode node) : base(items) 
        {
            SourceNode = node;
        }
    }
}
