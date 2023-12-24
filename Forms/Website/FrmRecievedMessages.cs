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
    public partial class FrmRecievedMessages : Form
    {
        public FrmRecievedMessages()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmRecievedMessages_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblMessage2
                                       select new
                                       {
                                           x.MessageID,
                                           x.Sender,
                                           x.Subject,
                                           x.Date,
                                           x.Reciever
                                       }).Where(y=>y.Reciever=="Admin").ToList();
        }
    }
}
