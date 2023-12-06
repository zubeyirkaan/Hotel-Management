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
            lookUpEditProductGroup.Properties.DataSource = (from x in db.TblProductGroups
                                                       select new
                                                       {
                                                           x.ProductGroupID,
                                                           x.ProductGroupName
                                                       }).ToList();

            //product list
            lookUpEditUnit.Properties.DataSource = (from x in db.TblStockUnits
                                                    select new
                                                    {
                                                        x.StockUnitID,
                                                        x.StockUnitName
                                                    }).ToList();
            //county list
            lookUpEditStatus.Properties.DataSource = (from x in db.TblStatus
                                                      select new
                                                      {
                                                          x.StatusID,
                                                          x.StatusName
                                                      }).ToList();

            //product update
            if (id !=0)
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            
            t.ProductName = TxtProductName.Text;
            t.ProductGroup = int.Parse(lookUpEditProductGroup.EditValue.ToString());
            t.Unit = int.Parse(lookUpEditUnit.EditValue.ToString());
            t.Status = int.Parse(lookUpEditStatus.EditValue.ToString());
            t.Price = decimal.Parse(TxtPrice.Text);
            t.Total = decimal.Parse(TxtTotal.Text);
            t.Tax = byte.Parse(TxtTax.Text);
            
            repo.TAdd(t);


            XtraMessageBox.Show("Product is succesfuly added to the database");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var value = repo.Find(x => x.ProductID == id);
            value.ProductName = TxtProductName.Text;
            value.ProductGroup = int.Parse(lookUpEditProductGroup.EditValue.ToString());
            value.Unit = int.Parse(lookUpEditUnit.EditValue.ToString());
            value.Status = int.Parse(lookUpEditStatus.EditValue.ToString());
            value.Price = decimal.Parse(TxtPrice.Text);
            value.Total = decimal.Parse(TxtTotal.Text);
            value.Tax = byte.Parse(TxtTax.Text);

            repo.TAdd(t);
            XtraMessageBox.Show("Product information has been successfully updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
