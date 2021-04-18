using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeViewApp.SDTreeViewDataSetTableAdapters;

namespace TreeViewApp
{
    public partial class MainForm : Form
    {
        private ShowDealsTableAdapter dealsAdapter;
        private ShowProdSalesTableAdapter prodsAdapter;
        private ShowServSalesTableAdapter servsAdapter;

        private Controller _controller = new Controller();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadAdapters();


            LoadNodes();
        }

        private void LoadAdapters()
        {
            dealsAdapter = new ShowDealsTableAdapter();
            prodsAdapter = new ShowProdSalesTableAdapter();
            servsAdapter = new ShowServSalesTableAdapter();
        }

        private void LoadNodes()
        {
            SDTreeViewDataSet.ShowDealsDataTable deals =
                new SDTreeViewDataSet.ShowDealsDataTable();
            SDTreeViewDataSet.ShowProdSalesDataTable prods = 
                new SDTreeViewDataSet.ShowProdSalesDataTable();
            SDTreeViewDataSet.ShowServSalesDataTable servs = 
                new SDTreeViewDataSet.ShowServSalesDataTable();

            dealsAdapter.Fill(deals);

            foreach(var deal in deals)
            {
                CustomNode dealNode = 
                    new CustomNode(Convert.ToString(deal[1]), CustomNode.DEAL, Convert.ToInt32(deal[0]));
                dealNode.ContextMenu = new CustomMenu(_controller.GetDealsMenuItems(), dealNode);

                treeView.Nodes.Add(dealNode);

                prodsAdapter.FillBy(prods, dealNode.Id);
                foreach(var prod in prods)
                {
                    CustomNode prodNode 
                        = new CustomNode(Convert.ToString(prod[2]), CustomNode.PRODUCT, Convert.ToInt32(prod[1]), Convert.ToInt32(prod[0]));
                    prodNode.ContextMenu = new CustomMenu(_controller.GetProductsMenuItems(), prodNode);

                    dealNode.Nodes.Add(prodNode);

                    servsAdapter.FillBy(servs, prodNode.Id);
                    foreach(var serv in servs)
                    {
                        CustomNode servNode =
                            new CustomNode(Convert.ToString(serv[2]), CustomNode.SERVICE, Convert.ToInt32(serv[1]), Convert.ToInt32(serv[0]));
                        servNode.ContextMenu = new CustomMenu(_controller.GetServiceMenuItems(), servNode);

                        prodNode.Nodes.Add(servNode);
                    }
                }
            }
        }

        private void addDealBtn_Click(object sender, EventArgs e)
        {
            DealsHandler handler = new DealsHandler(treeView);
            handler.Add();
        }
    }
}
