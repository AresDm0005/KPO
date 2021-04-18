using TreeViewApp.SDTreeViewDataSetTableAdapters;
using TreeViewApp.CUDForms;
using System;
using System.Data.SqlClient;

namespace TreeViewApp
{
    class ServicesHandler : ICUDHandler
    {
        private ShowServSalesTableAdapter servShowAdapter;
        private SDTreeViewDataSet.ShowServSalesDataTable servShow;

        private ServiceSalesTableAdapter servsAdapter;
        private SDTreeViewDataSet.ServiceSalesDataTable servs;

        public CustomNode Node { get; }

        public ServicesHandler() 
        {
            servShowAdapter = new ShowServSalesTableAdapter();
            servShow = new SDTreeViewDataSet.ShowServSalesDataTable();
            servsAdapter = new ServiceSalesTableAdapter();
            servs = new SDTreeViewDataSet.ServiceSalesDataTable();
        }

        public ServicesHandler(CustomNode node) : this() { Node = node; }

        private void UpdateParentDeal(bool add)
        {
            DealsHandler handler
                = new DealsHandler(add ? Node.Parent as CustomNode : Node.Parent.Parent as CustomNode);
            handler.UpdateDealsCost();
            handler.UpdateTextOfNode();
        }

        public void Add()
        {
            QueriesTableAdapter queries = new QueriesTableAdapter();
            int highCopies = Convert.ToInt32(queries.GetNumberOfCopiesInProductSaleById(Node.Id));

            ServiceForm form = new ServiceForm(highCopies);
            form.ShowDialog();

            int service;
            int copies;
            decimal cost;

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                service = form.Service;
                copies = form.Copies;
                cost = form.Cost;
            }
            else return;

            int id = InsertIntoServSales(Node.Id, service, copies, cost);

            servShowAdapter.FillById(servShow, id);
            UpdateParentDeal(true);

            if (servShow.Rows.Count != 1)
                throw new Exception();

            var row = servShow.Rows[0];
            CustomNode newNode =
                new CustomNode(text: Convert.ToString(row[2]), type: CustomNode.SERVICE, id: Convert.ToInt32(row[1]),
                    pId: Convert.ToInt32(row[0]));
            newNode.ContextMenu =
                new CustomMenu(new Controller().GetServiceMenuItems(), newNode);

            Node.Nodes.Add(newNode);
        }

        public void Update()
        {
            QueriesTableAdapter queries = new QueriesTableAdapter();
            int highCopies = Convert.ToInt32(queries.GetNumberOfCopiesInProductSaleById(Node.Id));
            servsAdapter.FillBy(servs, Node.Id);

            if (servs.Rows.Count != 1)
                throw new Exception();

            var row = servs.Rows[0];
            ServiceForm form = new ServiceForm(Convert.ToInt32(row[2]), Convert.ToInt32(row[3]), highCopies);
            form.ShowDialog();

            int service;
            int copies;
            decimal cost;

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                service = form.Service;
                copies = form.Copies;
                cost = form.Cost;
            }
            else return;

            UpdateServSales(Node.Id, service, copies, cost);

            servShowAdapter.FillById(servShow, Node.Id);
            UpdateParentDeal(false);

            if (servShow.Rows.Count != 1)
                throw new Exception();

            row = servShow.Rows[0];
            Node.Text = Convert.ToString(row[2]);
        }

        public void Remove()
        {
            DeleteServiceSale(Node.Id);
            UpdateParentDeal(false);
            Node.Remove();
        }

        public int InsertIntoServSales(int psale, int service, int copies, decimal cost)
        {
            string funcName = "InsertIntoServSales";
            int result = -1;

            using (SqlConnection connection = Connections.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(funcName, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@psale", psale),
                    new SqlParameter("@service", service),
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

        public void UpdateServSales(int id, int service, int copies, decimal cost)
        {
            string funcName = "UpdateServSales";

            using (SqlConnection connection = Connections.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(funcName, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id),
                    new SqlParameter("@service", service),
                    new SqlParameter("@copies", copies),
                    new SqlParameter("@cost", cost)
                };

                command.Parameters.AddRange(parameters);

                var result = command.ExecuteNonQuery();
            }
        }

        public void DeleteServiceSale(int id)
        {
            string funcName = "DeleteServiceSale";

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
