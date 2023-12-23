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

        public int id;

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

            //guest list2
            lookUpEditPerson2.Properties.DataSource = (from x in db.TblGuests
                                                     select new
                                                     {
                                                         x.GuestID,
                                                         x.NameSurname
                                                     }).ToList();

            //guest list3
            lookUpEditPerson3.Properties.DataSource = (from x in db.TblGuests
                                                     select new
                                                     {
                                                         x.GuestID,
                                                         x.NameSurname
                                                     }).ToList();

            //guest list4
            lookUpEditPerson4.Properties.DataSource = (from x in db.TblGuests
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

            //product update
            if (id != 0)
            {
                var reservation = repo.Find(x => x.ReservationID == id);
                lookUpEditGuest.EditValue = reservation.Guest;
                dateEditCheckIn.Text = reservation.StartDate.ToString();
                dateEditCheckOut.Text = reservation.LeaveDate.ToString();
                numericUpDown1.Value = decimal.Parse(reservation.NumberOfPeople.ToString());
                lookUpEditRoom.EditValue = reservation.Room;
                TxtPhone.Text = reservation.Phone;
                lookUpEditStatus.EditValue = reservation.Status;
                TxtStatement.Text = reservation.Statement;
                lookUpEditPerson2.EditValue = reservation.Person1;
                lookUpEditPerson3.EditValue = reservation.Person2;
                lookUpEditPerson4.EditValue = reservation.Person3;

            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            TblReservation t = new TblReservation();
            if(numericUpDown1.Value==1)
            {
                t.Guest = int.Parse(lookUpEditGuest.EditValue.ToString());
            }
            if (numericUpDown1.Value == 2)
            {
                t.Guest = int.Parse(lookUpEditGuest.EditValue.ToString());
                t.Person1 = int.Parse(lookUpEditPerson2.EditValue.ToString());
            }
            if (numericUpDown1.Value == 3)
            {
                t.Guest = int.Parse(lookUpEditGuest.EditValue.ToString());
                t.Person1 = int.Parse(lookUpEditPerson2.EditValue.ToString());
                t.Person2 = int.Parse(lookUpEditPerson3.EditValue.ToString());
            }
            if (numericUpDown1.Value == 4)
            {
                t.Guest = int.Parse(lookUpEditGuest.EditValue.ToString());
                t.Person1 = int.Parse(lookUpEditPerson2.EditValue.ToString());
                t.Person2 = int.Parse(lookUpEditPerson3.EditValue.ToString());
                t.Person3 = int.Parse(lookUpEditPerson4.EditValue.ToString());
            }
            t.StartDate = DateTime.Parse(dateEditCheckIn.Text);
            t.LeaveDate = DateTime.Parse(dateEditCheckOut.Text);
            t.NumberOfPeople = numericUpDown1.Value.ToString();
            t.Room = int.Parse(lookUpEditRoom.EditValue.ToString());
            //t.ReservationNameSurname = TxtReservationName.Text;
            t.Phone = TxtPhone.Text;
            t.Statement = TxtStatement.Text;
            t.Status = int.Parse(lookUpEditStatus.EditValue.ToString());
            repo.TAdd(t);
            XtraMessageBox.Show("Reservation was created successfully");
        }
    }
}
