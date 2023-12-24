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

namespace HotelManagementAutomation.Forms.Website
{
    public partial class FrmContactCard : Form
    {
        public FrmContactCard()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();
        Repository<TblContact> repo = new Repository<TblContact>();

        private void FrmContactCard_Load(object sender, EventArgs e)
        {
            var contact = repo.Find(x => x.ID == 1);
            TxtPhone.Text = contact.Phone;
            TxtEmail.Text = contact.Email;
            TxtCoordinate.Text = contact.Coordinate;
            TxtAddress.Text = contact.Address;
            TxtStatement.Text = contact.Statement;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var contact = repo.Find(x => x.ID == 1);
            contact.Email = TxtEmail.Text;
            contact.Phone = TxtPhone.Text;
            contact.Statement = TxtStatement.Text;
            contact.Coordinate = TxtCoordinate.Text;
            contact.Address = TxtAddress.Text;
            
            repo.TUpdate(contact);
            XtraMessageBox.Show("Contact information has been successfully updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
