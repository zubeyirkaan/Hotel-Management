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
            if (TxtNewPassword.Text == TxtNewPasswordAgain.Text)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(TxtUsername.Text) || 
                        string.IsNullOrWhiteSpace(TxtNewPassword.Text))
                    {
                        XtraMessageBox.Show("Please fill in all the required fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Stop further execution
                    }
                    TblAdmin t = new TblAdmin();
                    t.Username = TxtUsername.Text;
                    t.Password = TxtNewPassword.Text;
                    db.TblAdmin.Add(t);
                    db.SaveChanges();
                    XtraMessageBox.Show("New user addded", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("asdaweSD", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                   
                }


            }
            else
            {
                XtraMessageBox.Show("Password doesnt match, try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtNewPassword.Text == TxtNewPasswordAgain.Text)
                {
                    //  var value = repo.Find(x => x.ID == id);

                    var value = repo.Find(x => x.Username == TxtUsername.Text);

                    if (value != null)
                    {
                        value.Username = TxtUsername.Text;
                        value.Password = TxtNewPassword.Text;
                        value.Role = TxtRole.Text;
                        repo.TUpdate(value);
                        XtraMessageBox.Show("Admin information has been successfully updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        XtraMessageBox.Show("Admin not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Password doesn't match, try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            FrmAdminList fr = new FrmAdminList();
            fr.ShowDialog();
            this.Hide();
        }

        Repository<TblAdmin> repo = new Repository<TblAdmin>();

        private void FrmPasswordProcess_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                var admin = repo.Find(x => x.ID == id);
                TxtUsername.Text = admin.Username;
                TxtCurrentPassword.Text = admin.Password;
                TxtRole.Text = admin.Role;
            }
        }

        
    }
}
