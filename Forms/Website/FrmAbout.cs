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
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();
        Repository<TblAbout> repo = new Repository<TblAbout>();

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            var about = repo.Find(x => x.ID == 1);
            TxtAbout1.Text = about.About1;
            TxtAbout2.Text = about.About2;
            TxtAbout3.Text = about.About3;
            TxtAbout4.Text = about.About4;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var about = repo.Find(x => x.ID == 1);
            about.About1 = TxtAbout1.Text;
            about.About2 = TxtAbout2.Text;
            about.About3 = TxtAbout3.Text;
            about.About4 = TxtAbout4.Text;

            repo.TUpdate(about);
            XtraMessageBox.Show("Contact information has been successfully updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
