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
    public partial class FrmStaffCard : Form
    {
        public FrmStaffCard()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmStaffCard_Load(object sender, EventArgs e)
        {
            lookUpEditDepartment.Properties.DataSource = (from x in db.TblDepartments
                                                          select new
                                                          {
                                                              x.DepartmentID,
                                                              x.DepartmentName
                                                          }).ToList();

            lookUpEditMission.Properties.DataSource = (from x in db.TblMissions
                                                       select new
                                                       {
                                                           x.MissionID,
                                                           x.MissionName
                                                       }).ToList();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            TxtStatement.Text = pictureEdit11.GetLoadedImageLocation();
        }
    }
}
