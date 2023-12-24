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

namespace HotelManagementAutomation.Forms.Website
{
    public partial class FrmPreReservationCard : Form
    {
        public FrmPreReservationCard()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();
        Repository<TblPreReservation> repo = new Repository<TblPreReservation>();

        public int id;
        private void FrmPreReservationCard_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                var reservation = repo.Find(x => x.ID == id);
                dateEditCheckIn.Text = reservation.StartDate.ToString();
                dateEditCheckOut.Text = reservation.LeaveDate.ToString();
                dateEditDate.Text = reservation.Date.ToString();
                numericUpDown1.Value = decimal.Parse(reservation.NumberOfPeople.ToString());
                TxtPhone.Text = reservation.Phone;
                TxtEmail.Text = reservation.Email;
                TxtStatement.Text = reservation.Statement;
                TxtNameSurname.Text = reservation.NameSurname;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
