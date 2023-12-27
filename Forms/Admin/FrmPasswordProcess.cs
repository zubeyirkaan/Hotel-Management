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

namespace HotelManagementAutomation.Forms.Admin
{
    public partial class FrmPasswordProcess : Form
    {
        public FrmPasswordProcess()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();
        public int id;

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(TxtNewPassword.Text== TxtNewPasswordAgain.Text)
            {
                TblAdmin t = new TblAdmin();
                t.Username = TxtUsername.Text;
                t.Password = TxtNewPassword.Text;
                db.TblAdmin.Add(t);
                db.SaveChanges();
                XtraMessageBox.Show("New user addded", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Password doesnt match, try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if(TxtNewPassword.Text==TxtNewPasswordAgain.Text)
            {
                var value = repo.Find(x => x.ID == id);
                value.Username = TxtUsername.Text;
                value.Password = TxtNewPassword.Text;
                value.Role = TxtRole.Text;
                repo.TUpdate(value);
                XtraMessageBox.Show("Admin information has been successfully updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                XtraMessageBox.Show("Password doesnt match, try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            FrmAdminList fr = new FrmAdminList();
            fr.Show();
            this.Hide();
        }

        Repository<TblAdmin> repo = new Repository<TblAdmin>();

        private void FrmPasswordProcess_Load(object sender, EventArgs e)
        {
            if(id !=0)
            {
                var admin = repo.Find(x => x.ID == id);
                TxtUsername.Text = admin.Username;
                TxtCurrentPassword.Text = admin.Password;
                TxtRole.Text = admin.Role;
            }
        }
    }
}
