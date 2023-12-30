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
                                                    }).Where(y => y.StatusName == "Active").ToList();

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
                TxtTotalPrice.Text = reservation.TotalPrice.ToString();
                lookUpEditPerson2.EditValue = reservation.Person1;
                lookUpEditPerson3.EditValue = reservation.Person2;
                lookUpEditPerson4.EditValue = reservation.Person3;
                TxtRoomNo.Text = reservation.TblRoom.RoomNo;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            TblReservation t = new TblReservation();
            if (numericUpDown1.Value == 1)
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
            t.TotalPrice = decimal.Parse(TxtTotalPrice.Text);
            repo.TAdd(t);
            XtraMessageBox.Show("Reservation was created successfully");
        }

        private void lookUpEditGuest_EditValueChanged(object sender, EventArgs e)
        {
            int picked;
            picked = int.Parse(lookUpEditGuest.EditValue.ToString());
            var phone = db.TblGuests.Where(x => x.GuestID == picked).Select(y => y.Phone).FirstOrDefault();
            TxtPhone.Text = phone.ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var reservation = repo.Find(x => x.ReservationID == id);

            Repository<TblRoom> repo2 = new Repository<TblRoom>();
            if (lookUpEditStatus.Text == "Checked out")
            {
                var roomstatus = repo2.Find(x => x.RoomID == reservation.Room);
                roomstatus.Status = 3;
                repo2.TUpdate(roomstatus);
                reservation.ToTheCashResgiter = true;
                repo.TUpdate(reservation);

                //to the cash register
                TblCashRegisterOperations tcash = new TblCashRegisterOperations();
                Repository<TblCashRegisterOperations> repocash = new Repository<TblCashRegisterOperations>();

                tcash.Guest = lookUpEditGuest.Text;
                tcash.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                tcash.Price = decimal.Parse(TxtTotalPrice.Text);
                repocash.TAdd(tcash);

            }
            

            
            reservation.Guest = int.Parse(lookUpEditGuest.EditValue.ToString());
            reservation.StartDate = DateTime.Parse(dateEditCheckIn.Text);
            reservation.LeaveDate = DateTime.Parse(dateEditCheckOut.Text);
            reservation.NumberOfPeople = numericUpDown1.Value.ToString();
            reservation.Room = int.Parse(lookUpEditRoom.EditValue.ToString());
            reservation.Phone = TxtPhone.Text;
            reservation.Status = int.Parse(lookUpEditStatus.EditValue.ToString());
            reservation.Statement = TxtStatement.Text;
            reservation.TotalPrice = decimal.Parse(TxtTotalPrice.Text);

            if (numericUpDown1.Value == 1)
            {
                reservation.Guest = int.Parse(lookUpEditGuest.EditValue.ToString());
            }
            if (numericUpDown1.Value == 2)
            {
                reservation.Guest = int.Parse(lookUpEditGuest.EditValue.ToString());
                reservation.Person1 = int.Parse(lookUpEditPerson2.EditValue.ToString());
            }
            if (numericUpDown1.Value == 3)
            {
                reservation.Guest = int.Parse(lookUpEditGuest.EditValue.ToString());
                reservation.Person1 = int.Parse(lookUpEditPerson2.EditValue.ToString());
                reservation.Person2 = int.Parse(lookUpEditPerson3.EditValue.ToString());
            }
            if (numericUpDown1.Value == 4)
            {
                reservation.Guest = int.Parse(lookUpEditGuest.EditValue.ToString());
                reservation.Person1 = int.Parse(lookUpEditPerson2.EditValue.ToString());
                reservation.Person2 = int.Parse(lookUpEditPerson3.EditValue.ToString());
                reservation.Person3 = int.Parse(lookUpEditPerson4.EditValue.ToString());
            }
            repo.TUpdate(reservation);
            XtraMessageBox.Show("Guest information has been successfully updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //room status change


        }
    }
}
