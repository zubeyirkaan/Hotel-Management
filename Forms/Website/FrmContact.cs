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

namespace HotelManagementAutomation.Forms.Website
{
    public partial class FrmContact : Form
    {
        public FrmContact()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMessageCard fr = new FrmMessageCard();
            fr.id2 = int.Parse(gridView1.GetFocusedRowCellValue("MessageID").ToString());
            fr.Show();
        }

        private void FrmContact_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblMessage
                                       select new
                                       {
                                           x.MessageID,
                                           x.Sender,
                                           x.Email,
                                           x.Subject,
                                           x.Message
                                       }).ToList();
        }
    }
}
