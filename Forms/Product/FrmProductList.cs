using HotelManagementAutomation.Entitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementAutomation.Forms.Product
{
    public partial class FrmProductList : Form
    {
        public FrmProductList()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmProductList_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblProducts
                                       join p in db.TblProductGroups on x.ProductGroup equals p.ProductGroupID
                                       select new
                                       {
                                           x.ProductID,
                                           p.ProductGroupName,
                                           x.ProductName,
                                           x.Price,
                                           x.Unit,
                                           x.Total
                                       }).ToList();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            FrmProductCard fr = new FrmProductCard();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ProductID").ToString());
            fr.Show();
        }
    }
}
