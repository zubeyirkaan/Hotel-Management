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

namespace HotelManagementAutomation.Forms.Website
{
    public partial class FrmNewRegistry : Form
    {
        public FrmNewRegistry()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmNewRegistry_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblNewRegistry
                                       select new
                                       {
                                           x.NameSurname,
                                           x.Email,
                                           x.Phone,
                                        }).ToList();
        }
    }
}
