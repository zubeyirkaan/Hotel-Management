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
    public partial class FrmPreReservations : Form
    {
        public FrmPreReservations()
        {
            InitializeComponent();
        }
        DbHotelEntities db = new DbHotelEntities();


        private void FrmPreReservations_Load(object sender, EventArgs e)
        {
            preReservationList();
        }

        private void preReservationList()
        {
            gridControl1.DataSource = (from x in db.TblPreReservation
                                       select new
                                       {
                                           x.ID,
                                           x.NameSurname,
                                           x.Email,
                                           x.Phone,
                                           x.Date
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmPreReservationCard fr = new FrmPreReservationCard();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.ShowDialog();
            preReservationList();
        }
    }
}
