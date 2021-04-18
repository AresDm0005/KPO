using TreeViewApp.SDTreeViewDataSetTableAdapters;
using TreeViewApp.CUDForms;
using System;
using System.Data.SqlClient;

namespace TreeViewApp
{
    class ProductsHandler : ICUDHandler
    {
        private ShowProdSalesTableAdapter prodShowAdapter;
        private SDTreeViewDataSet.ShowProdSalesDataTable prodShow;

        private ProductSalesTableAdapter prodsAdapter;
        private SDTreeViewDataSet.ProductSalesDataTable prods;

        public CustomNode Node { get; }

        public ProductsHandler() 
        {
            prods = new SDTreeViewDataSet.ProductSalesDataTable();
            prodsAdapter = new ProductSalesTableAdapter();

            prodShow = new SDTreeViewDataSet.ShowProdSalesDataTable();
            prodShowAdapter = new ShowProdSalesTableAdapter();
        }

        public ProductsHandler(CustomNode node) : this() { Node = node; }

        private void UpdateParentDeal(bool add)
        {
            DealsHandler handler 
                = new DealsHandler(add ? Node : Node.Parent as CustomNode);
            handler.UpdateDealsCost();
            handler.UpdateTextOfNode();
        }   

        public void Add()
        {
            ProductForm form = new ProductForm();
            form.ShowDialog();

            int product;
            int copies;
            decimal cost;

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                product = form.Product;
                copies = form.Copies;
                cost = form.Cost;
            }
            else return;

            int id = InsertIntoProdSales(Node.Id, product, copies, cost);

            prodShowAdapter.FillByPSaleId(prodShow, id);
            UpdateParentDeal(true);

            if (prodShow.Rows.Count != 1)
                throw new Exception();

            var row = prodShow.Rows[0];
            CustomNode newNode =
                new CustomNode(text: Convert.ToString(row[2]), type: CustomNode.PRODUCT, id: Convert.ToInt32(row[1]), 
                    pId: Convert.ToInt32(row[0]));
            newNode.ContextMenu =
                new CustomMenu(new Controller().GetProductsMenuItems(), newNode);

            
            Node.Nodes.Add(newNode);
        }

        public void Update()
        {
            prodsAdapter.FillBy(prods, Node.Id);

            if (prods.Rows.Count != 1)
                throw new Exception();

            var row = prods.Rows[0];
            ProductForm form = new ProductForm(Convert.ToInt32(row[2]), Convert.ToInt32(row[3]));
            form.ShowDialog();

            int product;
            int copies;
            decimal cost;

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                product = form.Product;
                copies = form.Copies;
                cost = form.Cost;
            }
            else return;

            UpdateProdSales(Node.Id, product, copies, cost);

            prodShowAdapter.FillByPSaleId(prodShow, Node.Id);
            UpdateParentDeal(false);

            if (prodShow.Rows.Count != 1)
                throw new Exception();

            row = prodShow.Rows[0];
            Node.Text = Convert.ToString(row[2]);
        }

        public void Remove()
        {
            DeleteProductSale(Node.Id);
            UpdateParentDeal(false);
            Node.Remove();
        }

        public int InsertIntoProdSales (int deal, int product, int copies, decimal cost)
        {
            string funcName = "InsertIntoProdSales";
            int result = -1;

            using (SqlConnection connection = Connections.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(funcName, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@deal", deal),
                    new SqlParameter("@product", product),
                    new SqlParameter("@copies", copies),
                    new SqlParameter("@cost", cost)
                };

                command.Parameters.AddRange(parameters);

                SqlParameter retParam = new SqlParameter("@id", System.Data.SqlDbType.Int);
                retParam.Direction = System.Data.ParameterDirection.ReturnValue;

                command.Parameters.Add(retParam);

                command.ExecuteNonQuery();

                result = Convert.ToInt32(retParam.Value);
            }

            return result;
        }

        public void UpdateProdSales(int id, int product, int copies, decimal cost)
        {
            string funcName = "UpdateProdSales";

            using (SqlConnection connection = Connections.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(funcName, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id),
                    new SqlParameter("@product", product),
                    new SqlParameter("@copies", copies),
                    new SqlParameter("@cost", cost)
                };

                command.Parameters.AddRange(parameters);

                var result = command.ExecuteNonQuery();
            }
        }

        public void DeleteProductSale(int id)
        {
            string funcName = "DeleteProductSale";

            using (SqlConnection connection = Connections.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(funcName, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@id", id);

                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }
    }
}
