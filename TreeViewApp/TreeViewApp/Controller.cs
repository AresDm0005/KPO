using System;
using System.Windows.Forms;

namespace TreeViewApp
{
    class Controller
    {
        public Controller() { }

        public MenuItem[] GetDealsMenuItems()
        {
            return new MenuItem[] {
                new MenuItem("Добавить новый продукт в заказ", Add),
                new MenuItem("Редактировать детали заказа", Update),
                new MenuItem("Удалить заказ", Remove)
            };
        }

        public MenuItem[] GetProductsMenuItems()
        {
            return new MenuItem[] {
                new MenuItem("Добавить новую услугу для данного изделия в заказе", Add),
                new MenuItem("Редактировать тираж продукта", Update),
                new MenuItem("Удалить изделия из заказа", Remove)
            };
        }

        public MenuItem[] GetServiceMenuItems()
        {
            return new MenuItem[] {
                new MenuItem("Редактировать тираж услуги", Update),
                new MenuItem("Удалить услугу из заказа", Remove)
            };
        }

        private ICUDHandler GetController(int type, CustomNode node) 
        {
            switch (type)
            {
                case CustomNode.DEAL: return new DealsHandler(node);
                case CustomNode.PRODUCT: return new ProductsHandler(node);
                case CustomNode.SERVICE: return new ServicesHandler(node);
                default: throw new ArgumentException("Sth wrong happend with node type");
            }
        }

        public void Add(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            CustomMenu menu = item.Parent as CustomMenu;
            CustomNode node = menu.SourceNode as CustomNode;

            if (node == null)
                throw new ArgumentException("Controller.Add() - sender is not a CustomNode");


            ICUDHandler handler;
            if (node.Type == CustomNode.DEAL)
                handler = new ProductsHandler(node);
            else if (node.Type == CustomNode.PRODUCT)
                handler = new ServicesHandler(node);
            else return;

            handler.Add();
        }

        public void Update(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            CustomMenu menu = item.Parent as CustomMenu;
            CustomNode node = menu.SourceNode as CustomNode;

            if (node == null)
                throw new ArgumentException("Controller.Update() - sender is not a CustomNode");

            ICUDHandler handler = GetController(node.Type, node);
            handler.Update();
        }

        public void Remove(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            CustomMenu menu = item.Parent as CustomMenu;
            CustomNode node = menu.SourceNode as CustomNode;

            if (node == null)
                throw new ArgumentException("Controller.Remove() - sender is not a CustomNode");

            ICUDHandler handler = GetController(node.Type, node);
            handler.Remove();
        }
    }
}
