using DevExpress.XtraEditors;
using HotelManagementAutomation.Entitiy;
using HotelManagementAutomation.Repositories;
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
    public partial class FrmCashRegisterOut : Form
    {
        public FrmCashRegisterOut()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();
        Repository<TblCashRegisterOut> repo = new Repository<TblCashRegisterOut>();
        TblCashRegisterOut t = new TblCashRegisterOut();

        private void FrmCashRegisterOut_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            t.Statement = TxtStatement.Text;
            t.Date = DateTime.Parse(dateEdit1.Text);
            t.Price = decimal.Parse(TxtTotalPrice.Text);
            repo.TAdd(t);
            XtraMessageBox.Show("Process type added to the system.");
        }
    }
}
