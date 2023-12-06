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
    public partial class FrmProcessDefinitions : Form
    {
        public FrmProcessDefinitions()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();
        public int id;

        Repository<TblProductProcess> repo = new Repository<TblProductProcess>();
        TblProductProcess t = new TblProductProcess();

        private void FrmProcessDefinitions_Load(object sender, EventArgs e)
        {
            //id value
            TxtID.Text = id.ToString();
            TxtID.Enabled = false;

            lookUpEditProduct.Properties.DataSource = (from x in db.TblProducts
                                                       select new
                                                       {
                                                           x.ProductID,
                                                           x.ProductName
                                                       }).ToList();
            //fill the list
            if (id != 0)
            {
                var product = repo.Find(x => x.ProcessID == id);
                lookUpEditProduct.EditValue = product.Product;
                TxtAmount.Text = product.Amount.ToString();
                TxtStatement.Text = product.Statement;
                comboBox1.Text = product.ProcessType;
                dateEdit1.Text = product.Date.ToString();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            t.Product = int.Parse(lookUpEditProduct.EditValue.ToString());
            t.Date = DateTime.Parse(dateEdit1.Text);
            t.ProcessType = comboBox1.Text;
            t.Amount = decimal.Parse(TxtAmount.Text);
            t.Statement = TxtStatement.Text;
            repo.TAdd(t);
            XtraMessageBox.Show("Process type added to the system.");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var product = repo.Find(x => x.ProcessID == id);
            product.Product = int.Parse(lookUpEditProduct.EditValue.ToString());
            product.Date = DateTime.Parse(dateEdit1.Text);
            product.ProcessType = comboBox1.Text;
            product.Amount = decimal.Parse(TxtAmount.Text);
            product.Statement = TxtStatement.Text;
            repo.TUpdate(product);
            XtraMessageBox.Show("Product type has been successfully updated");
        }
    }
}
