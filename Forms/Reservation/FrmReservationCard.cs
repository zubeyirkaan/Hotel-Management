using DevExpress.XtraEditors;
using HotelManagementAutomation.Entitiy;
using HotelManagementAutomation.Repositories;
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
    public partial class FrmReservationCard : Form
    {
        public FrmReservationCard()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();
        Repository<TblReservation> repo = new Repository<TblReservation>();
        TblProduct t = new TblProduct();

        private void FrmReservationCard_Load(object sender, EventArgs e)
        {
            //guest list
            lookUpEditGuest.Properties.DataSource = (from x in db.TblGuests
                                                     select new
                                                     {
                                                         x.GuestID,
                                                         x.NameSurname
                                                     }).ToList();

            //room list
            lookUpEditRoom.Properties.DataSource = (from x in db.TblRooms
                                                    select new
                                                    {
                                                        x.RoomID,
                                                        x.RoomNo,
                                                        x.TblStatu.StatusName
                                                    }).Where(y=>y.StatusName == "Active").ToList();

            //product list
            lookUpEditStatus.Properties.DataSource = (from x in db.TblStatus
                                                    select new
                                                    {
                                                        x.StatusID,
                                                        x.StatusName
                                                    }).ToList();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            TblReservation t = new TblReservation();
            t.Guest = int.Parse(lookUpEditGuest.EditValue.ToString());
            t.StartDate = DateTime.Parse(dateEditCheckIn.Text);
            t.LeaveDate = DateTime.Parse(dateEditCheckOut.Text);
            t.NumberOfPeople = numericUpDown1.Value.ToString();
            t.Room = int.Parse(lookUpEditRoom.EditValue.ToString());
            t.ReservationNameSurname = TxtReservationName.Text;
            t.Phone = TxtPhone.Text;
            t.Statement = TxtStatement.Text;
            t.Status = int.Parse(lookUpEditStatus.EditValue.ToString());
            repo.TAdd(t);
            XtraMessageBox.Show("Reservation was created successfully");
        }
    }
}
