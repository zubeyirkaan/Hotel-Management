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
    public partial class FrmProductCard : Form
    {
        public FrmProductCard()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        public int id;

        Repository<TblProduct> repo = new Repository<TblProduct>();
        TblProduct t = new TblProduct();

        private void FrmProductCard_Load(object sender, EventArgs e)
        {
            try
            {
                ProductGroup();

                //unit
                Unit();
                //status
                Status();

                //product update
                if (id != 0)
                {
                    var product = repo.Find(x => x.ProductID == id);
                    TxtProductName.Text = product.ProductName;
                    lookUpEditProductGroup.EditValue = product.ProductGroup;
                    lookUpEditUnit.EditValue = product.Unit;
                    TxtPrice.Text = product.Price.ToString();
                    TxtTotal.Text = product.Total.ToString();
                    TxtTax.Text = product.Tax.ToString();
                    lookUpEditStatus.EditValue = product.Status;
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Please fill the all blanks!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            ProductGroup();
            //unit
            Unit();
            //status
            Status();

        }

        private void Status()
        {
            lookUpEditStatus.Properties.DataSource = (from x in db.TblStatus
                                                      select new
                                                      {
                                                          x.StatusID,
                                                          x.StatusName
                                                      }).ToList();
        }

        private void Unit()
        {
            lookUpEditUnit.Properties.DataSource = (from x in db.TblStockUnits
                                                    select new
                                                    {
                                                        x.StockUnitID,
                                                        x.StockUnitName
                                                    }).ToList();
        }

        private void ProductGroup()
        {
            lookUpEditProductGroup.Properties.DataSource = (from x in db.TblProductGroups
                                                            select new
                                                            {
                                                                x.ProductGroupID,
                                                                x.ProductGroupName
                                                            }).ToList();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Check if any required field is empty or invalid
            if (string.IsNullOrWhiteSpace(TxtProductName.Text) ||
                lookUpEditProductGroup.EditValue == null ||
                lookUpEditUnit.EditValue == null ||
                lookUpEditStatus.EditValue == null ||
                !decimal.TryParse(TxtPrice.Text, out decimal parsedPrice) ||
                !decimal.TryParse(TxtTotal.Text, out decimal parsedTotal) ||
                !byte.TryParse(TxtTax.Text, out byte parsedTax))
            {
                XtraMessageBox.Show("Please fill in all the blanks correctly!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution if validation fails
            }

            try
            {
                t.ProductName = TxtProductName.Text;
                t.ProductGroup = int.Parse(lookUpEditProductGroup.EditValue.ToString());
                t.Unit = int.Parse(lookUpEditUnit.EditValue.ToString());
                t.Status = int.Parse(lookUpEditStatus.EditValue.ToString());
                t.Price = parsedPrice;  // Use the parsed value
                t.Total = parsedTotal;  // Use the parsed value
                t.Tax = parsedTax;      // Use the parsed value

                repo.TAdd(t);
                XtraMessageBox.Show("Product is successfully added to the database", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var value = repo.Find(x => x.ProductID == id);
                value.ProductName = TxtProductName.Text;
                value.ProductGroup = int.Parse(lookUpEditProductGroup.EditValue.ToString());
                value.Unit = int.Parse(lookUpEditUnit.EditValue.ToString());
                value.Status = int.Parse(lookUpEditStatus.EditValue.ToString());
                value.Price = decimal.Parse(TxtPrice.Text);
                value.Total = decimal.Parse(TxtTotal.Text);
                value.Tax = byte.Parse(TxtTax.Text);

                repo.TUpdate(t);
                XtraMessageBox.Show("Product information has been successfully updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Please fill the all blanks!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            TxtTax.Text = "1";
        }

        private void rdb8_CheckedChanged(object sender, EventArgs e)
        {
            TxtTax.Text = "8";
        }

        private void rdb10_CheckedChanged(object sender, EventArgs e)
        {
            TxtTax.Text = "10";
        }

        private void rdb18_CheckedChanged(object sender, EventArgs e)
        {
            TxtTax.Text = "18";
        }
    }
}
