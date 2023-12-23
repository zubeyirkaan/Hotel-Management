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

namespace HotelManagementAutomation.Forms.Staff
{
    public partial class FrmStaffList : Form
    {
        public FrmStaffList()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmStaffList_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblStaffs
                         select new
                         {
                             x.StaffID,
                             x.NameSurname,
                             x.TC,
                             x.Phone,
                             x.Mail,
                             x.TblDepartment.DepartmentName,
                             x.TblMission.MissionName,
                             x.TblStatu.StatusName
                         }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmStaffCard fr = new Forms.Staff.FrmStaffCard();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("StaffID").ToString());
            fr.BtnUpdate.Visible = true;
            fr.Show();
        }
    }
}
