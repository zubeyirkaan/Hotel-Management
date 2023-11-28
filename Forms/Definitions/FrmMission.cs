using DevExpress.XtraEditors;
using HotelManagementAutomation.Entitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementAutomation.Forms.Definitions
{
    public partial class FrmMission : Form
    {
        public FrmMission()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmMission_Load(object sender, EventArgs e)
        {
            db.TblMissions.Load();
            bindingSource1.DataSource = db.TblMissions.Local;

            repositoryItemLookUpEditDepartment.DataSource = (from x in db.TblDepartments
                                                             select new
                                                             {
                                                                 x.DepartmentID,
                                                                 x.DepartmentName
                                                             }).ToList();

            repositoryItemLookUpEditStatus.DataSource = (from x in db.TblStatus
                                                         select new
                                                         {
                                                             x.StatusID,
                                                             x.StatusName
                                                         }).ToList();

            
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //try
            //{
                db.SaveChanges();
            //}
            //catch (Exception)
            //{
            //    XtraMessageBox.Show("Try again!");
            //}
        }
    }
}
