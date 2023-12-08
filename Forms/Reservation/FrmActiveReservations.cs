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
    public partial class FrmActiveReservations : Form
    {
        public FrmActiveReservations()
        {
            InitializeComponent();
        }
        DbHotelEntities db = new DbHotelEntities();
        private void FrmActiveReservations_Load(object sender, EventArgs e)
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
                                       }).Where(y=>y.StatusName == "Active").ToList();
        }
    }
}
