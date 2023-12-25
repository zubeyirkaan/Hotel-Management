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

namespace HotelManagementAutomation.Forms.Main
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //guest list
            gridControl2.DataSource = (from x in db.TblGuests
                                       select new
                                       {
                                           x.NameSurname
                                       }).ToList();

            //message list
            gridControl4.DataSource = (from x in db.TblMessage
                                       select new
                                       {
                                           x.Sender
                                       }).ToList();

            //Will check in today
            gridControl3.DataSource = (from x in db.TblReservation
                                       select new
                                       {
                                           x.TblGuest.NameSurname,
                                           x.Status
                                       }).Where(y=>y.Status == 1010).ToList();

            //product stock list
            gridControl1.DataSource = (from x in db.TblProducts
                                       select new
                                       {
                                           x.ProductName,
                                           x.Total
                                       }).ToList();

            //Product stock graph
            var product = db.TblProducts.ToList();
            foreach(var x in product)
            {
                chartControl1.Series["Product-Stock"].Points.AddPoint(x.ProductName, double.Parse(x.Total.ToString()));
            }

            //Room occupancy chart
            var status = db.RoomStatus();
            foreach(var x in status)
            {
                chartControl2.Series["Status"].Points.AddPoint(x.StatusName, double.Parse(x.Count.ToString()));
            }
        }
    }
}
