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
    public partial class FrmSentMessage : Form
    {
        public FrmSentMessage()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmSentMessage_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblMessage2
                                       select new
                                       {
                                           x.MessageID,
                                           x.Reciever,
                                           x.Subject,
                                           x.Date,
                                           x.Sender
                                       }).Where(y => y.Sender == "Admin").ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMessageCard fr = new FrmMessageCard();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("MessageID").ToString());
            fr.Show();
        }
    }
}
