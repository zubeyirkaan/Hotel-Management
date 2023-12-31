using DevExpress.XtraEditors;
using HotelManagementAutomation.Entitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementAutomation.Forms.Admin
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Check if the username or password fields are empty
            if (string.IsNullOrWhiteSpace(TxtUsername.Text) || string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                XtraMessageBox.Show("Please fill in both the username and password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution
            }

            // Existing login logic
            var user = db.TblAdmin.Where(x => x.Username == TxtUsername.Text && x.Password == TxtPassword.Text).FirstOrDefault();
            if (user != null)
            {
                Form1 frm = new Form1();
                frm.userRole = user.Role;
                frm.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Username or password is incorrect!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
        }
    }
}
