namespace TreeViewApp
{
    interface ICUDHandler
    {
        CustomNode Node { get; }

        void Add();

        void Update();

        void Remove();
    }
}
