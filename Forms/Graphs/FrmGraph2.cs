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

namespace HotelManagementAutomation.Forms.Graphs
{
    public partial class FrmGraph2 : Form
    {
        public FrmGraph2()
        {
            InitializeComponent();
        }
        DbHotelEntities db = new DbHotelEntities();
        private void FrmGraph2_Load(object sender, EventArgs e)
        {
            var status = db.RoomStatus();
            foreach (var x in status)
            {
                chartControl1.Series["Status"].Points.AddPoint(x.StatusName, double.Parse(x.Count.ToString()));
            }
        }
    }
}
