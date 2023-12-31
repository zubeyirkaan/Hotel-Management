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

namespace HotelManagementAutomation.Forms.Product
{
    public partial class FrmCashRegisterOut : Form
    {
        public FrmCashRegisterOut()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();
        Repository<TblCashRegisterOut> repo = new Repository<TblCashRegisterOut>();
        TblCashRegisterOut t = new TblCashRegisterOut();

        private void FrmCashRegisterOut_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Check if any required field is empty or invalid
            if (string.IsNullOrWhiteSpace(TxtStatement.Text) ||
                string.IsNullOrWhiteSpace(dateEdit1.Text) ||
                !decimal.TryParse(TxtTotalPrice.Text, out decimal parsedPrice))
            {
                XtraMessageBox.Show("Please fill in all the fields correctly!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution if validation fails
            }

            try
            {
                t.Statement = TxtStatement.Text;
                t.Date = DateTime.Parse(dateEdit1.Text); // Ensure that this field contains a valid date string
                t.Price = parsedPrice; // Use the parsed value

                repo.TAdd(t);
                XtraMessageBox.Show("Process type added to the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
