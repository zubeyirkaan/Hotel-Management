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
    public partial class FrmReceptionOperations : Form
    {
        public FrmReceptionOperations()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmReceptionOperations_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblReservation
                                       select new
                                       {
                                           x.TblGuest.NameSurname,
                                           x.LeaveDate,
                                           x.TotalPrice
                                       }).ToList();
        }
    }
}
