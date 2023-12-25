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

namespace HotelManagementAutomation.Forms.Graphs
{
    public partial class FrmGraph1 : Form
    {
        public FrmGraph1()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmGraph1_Load(object sender, EventArgs e)
        {
            var product = db.TblProducts.ToList();
            foreach (var x in product)
            {
                chartControl1.Series["Product-Stock"].Points.AddPoint(x.ProductName, double.Parse(x.Total.ToString()));
            }
        }
    }
}
