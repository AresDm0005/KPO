using TreeViewApp.SDTreeViewDataSetTableAdapters;
using TreeViewApp.CUDForms;
using System;
using System.Data.SqlClient;

namespace TreeViewApp
{
    class DealsHandler : ICUDHandler
    {
        private ShowDealsTableAdapter dealsShowAdapter;
        private SDTreeViewDataSet.ShowDealsDataTable dealsShow;

        private DealsTableAdapter dealsAdapter;
        private SDTreeViewDataSet.DealsDataTable deals;

        public System.Windows.Forms.TreeView View { get; }
        public CustomNode Node { get; }

        public DealsHandler() 
        {
            dealsAdapter = new DealsTableAdapter();
            dealsShowAdapter = new ShowDealsTableAdapter();
            
            deals = new SDTreeViewDataSet.DealsDataTable();
            dealsShow = new SDTreeViewDataSet.ShowDealsDataTable();
        }

        public DealsHandler(System.Windows.Forms.TreeView view) : this() { View = view; }

        public DealsHandler(CustomNode node) : this() { Node = node; }        

        public void Add()
        {
            DealForm form = new DealForm();
            form.ShowDialog();

            int client;
            DateTime date;

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                client = form.Client;
                date = form.DateSign;
            }
            else return;

            int id = InsertIntoDeals(client, date, 0);

            dealsShowAdapter.FillBy(dealsShow, id);

            if (dealsShow.Rows.Count != 1)
                throw new Exception("Sth gone wrong with inserting new deal");

            var row = dealsShow.Rows[0];
            CustomNode newNode =
                new CustomNode(text: Convert.ToString(row[1]), type: CustomNode.DEAL, id: Convert.ToInt32(row[0]));
            newNode.ContextMenu =
                new CustomMenu(new Controller().GetDealsMenuItems(), newNode);

            View.Nodes.Add(newNode);
        }

        public void Update()
        {
            dealsAdapter.FillBy(deals, Node.Id);

            if (deals.Rows.Count != 1)
                throw new Exception("DH.Update()");

            var row = deals.Rows[0];
            DealForm form =
                new DealForm(Convert.ToInt32(row[1]), Convert.ToDateTime(row[2]));
            form.ShowDialog();

            int client;
            DateTime date;

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                client = form.Client;
                date = form.DateSign;
            }
            else return;

            UpdateDealsInfo(Node.Id, client, date);
            UpdateTextOfNode();
        }

        public void Remove()
        {
            DeleteDeal(Node.Id);
            Node.Remove();
        }

        public int InsertIntoDeals(int client, DateTime date_sign, decimal cost)
        {
            string funcName = "InsertIntoDeals";
            int result = -1;

            using (SqlConnection connection = Connections.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(funcName, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@client", client),
                    new SqlParameter("@date_sign", date_sign),
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

        public void UpdateDealsInfo(int id, int client, DateTime date_sign)
        {
            string funcName = "UpdateDealsInfo";

            using (SqlConnection connection = Connections.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(funcName, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id),
                    new SqlParameter("@client", client),
                    new SqlParameter("@date_sign", date_sign)
                };

                command.Parameters.AddRange(parameters);

                var result = command.ExecuteNonQuery();
            }
        }

        public void DeleteDeal(int id)
        {
            string funcName = "DeleteDeal";

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

        public void UpdateDealsCost()
        {
            string funcName = "UpdateDealsCost";

            using (SqlConnection connection = Connections.GetConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(funcName, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", Node.Id)
                };

                command.Parameters.AddRange(parameters);

                var result = command.ExecuteNonQuery();
            }
        }

        public void UpdateTextOfNode()
        {
            dealsShowAdapter.FillBy(dealsShow, Node.Id);

            if (dealsShow.Rows.Count != 1)
                throw new Exception("Sth gone wrong with inserting new deal");

            var row = dealsShow.Rows[0];
            Node.Text = Convert.ToString(row[1]);
        }
    }
}
