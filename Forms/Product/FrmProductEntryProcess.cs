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
    public partial class FrmProductEntryProcess : Form
    {
        public FrmProductEntryProcess()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmProductEntryProcess_Load(object sender, EventArgs e)
        {
            LoadProductEntry();
        }

        private void LoadProductEntry()
        {
            gridControl1.DataSource = (from x in db.TblProductProcess
                                       select new
                                       {
                                           x.ProcessID,
                                           x.TblProduct.ProductName,
                                           x.Amount,
                                           x.Date,
                                           x.ProcessType,
                                           x.UnitPrice,
                                           x.TotalPrice
                                       }).Where(y => y.ProcessType == "Entry").ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmProcessDefinitions fr = new FrmProcessDefinitions();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ProcessID").ToString());
            fr.ShowDialog();
            LoadProductEntry();
        }
    }
}
