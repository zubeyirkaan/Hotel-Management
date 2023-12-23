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

namespace HotelManagementAutomation.Forms.Reservation
{
    public partial class FrmAllReservations : Form
    {
        public FrmAllReservations()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmAllReservations_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblReservation
                                       select new
                                       {
                                           x.ReservationID,
                                           x.TblGuest.NameSurname,
                                           x.StartDate,
                                           x.LeaveDate,
                                           x.NumberOfPeople,
                                           x.TblRoom.RoomNo,
                                           x.Phone,
                                           x.TblStatus.StatusName
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmReservationCard fr = new FrmReservationCard();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ReservationID").ToString());
            fr.BtnUpdate.Visible = true;
            fr.Show();
        }
    }
}
