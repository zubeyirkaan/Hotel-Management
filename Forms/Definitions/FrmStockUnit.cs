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
    public partial class FrmStockUnit : Form
    {
        public FrmStockUnit()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void TblStockUnit_Load(object sender, EventArgs e)
        {
            db.TblStockUnits.Load();
            bindingSource1.DataSource = db.TblStockUnits.Local;

            repositoryItemLookUpEditStatus.DataSource = (from x in db.TblStatus
                                                         select new
                                                         {
                                                             x.StatusID,
                                                             x.StatusName
                                                         }).ToList();
        }
    }
}
