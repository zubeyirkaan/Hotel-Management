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

namespace HotelManagementAutomation.Forms.Guest
{
    public partial class FrmGuest : Form
    {
        public FrmGuest()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        public int id;

        string image1, image2;

        Repository<TblGuest> repo = new Repository<TblGuest>();
        TblGuest t = new TblGuest();

        private void FrmGuest_Load(object sender, EventArgs e)
        {
            try
            {
                //Card information to be updated
                if (id != 0)
                {
                    var guest = repo.Find(x => x.GuestID == id);
                    TxtNameSurname.Text = guest.NameSurname;
                    TxtTC.Text = guest.TC;
                    TxtAddres.Text = guest.Address;
                    TxtPhone.Text = guest.Phone;
                    TxtEmail.Text = guest.Mail;
                    TxtStatement.Text = guest.Statement;
                    pictureEditIDFront.Image = Image.FromFile(guest.IDPhoto1);
                    pictureEditIDBack.Image = Image.FromFile(guest.IDPhoto2);
                    image1 = guest.IDPhoto1;
                    image2 = guest.IDPhoto2;
                    lookUpEditCity.EditValue = guest.sehir;
                    lookUpEditCounty.EditValue = guest.ilce;
                    lookUpEditCountry.EditValue = guest.Country;

                    //country list
                    loadCountry();

                    //city list
                    loadCity();

                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Please fill the all blanks!","Warning", MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }

            loadCountry();
            loadCity();



        }

        private void loadCity()
        {
            lookUpEditCity.Properties.DataSource = (from x in db.iller
                                                    select new
                                                    {
                                                        Id = x.id,
                                                        Sehir = x.sehir
                                                    }).ToList();
        }

        private void loadCountry()
        {
            lookUpEditCountry.Properties.DataSource = (from x in db.TblCountries
                                                       select new
                                                       {
                                                           x.CountryID,
                                                           x.CountryName
                                                       }).ToList();
        }

        private void lookUpEditCity_EditValueChanged(object sender, EventArgs e)
        {
            int picked;
            picked = int.Parse(lookUpEditCity.EditValue.ToString());
            lookUpEditCounty.Properties.DataSource = (from x in db.ilceler
                                                      select new
                                                      {
                                                          Id = x.id,
                                                          Ilce = x.ilce,
                                                          Sehir = x.sehir
                                                      }).Where(y => y.Sehir == picked).ToList();
        }



        private void pictureEditIDFront_EditValueChanged(object sender, EventArgs e)
        {
            image1 = pictureEditIDFront.GetLoadedImageLocation().ToString();
        }

        private void pictureEditIDBack_EditValueChanged(object sender, EventArgs e)
        {
            image2 = pictureEditIDBack.GetLoadedImageLocation().ToString();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var value = repo.Find(x => x.GuestID == id);
            value.NameSurname = TxtNameSurname.Text;
            value.TC = TxtTC.Text;
            value.Address = TxtAddres.Text;
            value.Phone = TxtPhone.Text;
            value.Country = int.Parse(lookUpEditCountry.EditValue.ToString());
            value.sehir = int.Parse(lookUpEditCity.EditValue.ToString());
            value.ilce = int.Parse(lookUpEditCounty.EditValue.ToString());
            value.Statement = TxtStatement.Text;
            value.Mail = TxtEmail.Text;
            value.IDPhoto1 = image1;
            value.IDPhoto2 = image2;
            value.Status = 1;
            repo.TUpdate(value);
            XtraMessageBox.Show("Guest information has been successfully updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            
            t.NameSurname = TxtNameSurname.Text;
            t.TC = TxtTC.Text;
            t.Address = TxtAddres.Text;
            t.Phone = TxtPhone.Text;
            t.Mail = TxtEmail.Text;
            t.Statement = TxtStatement.Text;
            t.Status = 1;
            t.sehir = int.Parse(lookUpEditCity.EditValue.ToString());
            t.ilce = int.Parse(lookUpEditCounty.EditValue.ToString());
            t.Country = int.Parse(lookUpEditCountry.EditValue.ToString());
            t.IDPhoto1 = image1;
            t.IDPhoto2 = image2;
            try
            {
                repo.TAdd(t);
            }
            catch (Exception)
            {

                XtraMessageBox.Show("please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            XtraMessageBox.Show("Guest successfully added to the system","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
