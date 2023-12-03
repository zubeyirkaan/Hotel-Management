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

namespace HotelManagementAutomation.Forms.Guest
{
    public partial class FrmGuestList : Form
    {
        public FrmGuestList()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();
        

        private void FrmGuestList_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblGuests
                                       select new
                                       {
                                           x.GuestID,
                                           x.NameSurname,
                                           x.TC,
                                           x.Phone,
                                           x.Mail,
                                           x.iller.sehir,
                                           x.ilceler.ilce

                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmGuest fr = new Forms.Guest.FrmGuest();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("GuestID").ToString());
            fr.Show();
        }
    }
}
