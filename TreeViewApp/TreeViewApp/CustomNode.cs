using System.Windows.Forms;

namespace TreeViewApp
{
    class CustomNode : TreeNode
    {
        public const int DEAL = 1;
        public const int PRODUCT = 2;
        public const int SERVICE = 3;

        public int ParentId { get; }
        public int Id { get; }
        public int Type { get; }

        public CustomNode() : base() { }

        public CustomNode(string text, int type, int id, int pId = -1) : base(text)
        {
            Id = id;
            ParentId = pId;
            Type = type;
        }

        public CustomNode(string text, TreeNode[] nodes, int type, int id, int pId = -1) :
            base(text, nodes)
        {
            Id = id;
            ParentId = pId;
            Type = type;
        }
    }
}
