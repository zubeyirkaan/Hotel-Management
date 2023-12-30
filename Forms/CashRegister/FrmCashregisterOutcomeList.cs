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

namespace HotelManagementAutomation.Forms.CashRegister
{
    public partial class FrmCashregisterOutcomeList : Form
    {
        public FrmCashregisterOutcomeList()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmCashregisterOutcomeList_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblCashRegisterOut
                                       select new
                                       {
                                           x.Statement,
                                           x.Date,
                                           x.Price
                                       }).ToList();
        }
    }
}
