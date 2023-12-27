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

namespace HotelManagementAutomation.Forms.Admin
{
    public partial class FrmAdminList : Form
    {
        public FrmAdminList()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmAdminList_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TblAdmin.ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmPasswordProcess fr = new FrmPasswordProcess();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }
    }
}
