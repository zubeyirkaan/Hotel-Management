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

namespace HotelManagementAutomation.Forms.Guest
{
    public partial class FrmGuest : Form
    {
        public FrmGuest()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmGuest_Load(object sender, EventArgs e)
        {
            //country list
            lookUpEditCountry.Properties.DataSource = (from x in db.TblCountries
                                                          select new
                                                          {
                                                              x.CountryID,
                                                              x.CountryName
                                                          }).ToList();
        }
    }
}
