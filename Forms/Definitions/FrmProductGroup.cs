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
    public partial class FrmProductGroup : Form
    {
        public FrmProductGroup()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmProductGroup_Load(object sender, EventArgs e)
        {
            db.TblProductGroups.Load();
            bindingSource1.DataSource = db.TblProductGroups.Local;

            repositoryItemLookUpEditStatus.DataSource = (from x in db.TblStatus
                                                         select new
                                                         {
                                                             x.StatusID,
                                                             x.StatusName
                                                         }).ToList();
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }
    }
}
