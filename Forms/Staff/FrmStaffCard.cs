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

namespace HotelManagementAutomation.Forms.Staff
{
    public partial class FrmStaffCard : Form
    {
        public FrmStaffCard()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        public int id;
        Repository<TblStaff> repo = new Repository<TblStaff>();

        private void FrmStaffCard_Load(object sender, EventArgs e)
        {
            this.Text = id.ToString();
            if (id != 0)
            {
                var staff = repo.Find(x => x.StaffID == id);
                TxtNameSurname.Text = staff.NameSurname;
                TxtTC.Text = staff.TC;
                TxtAddres.Text = staff.Address;
                TxtPhone.Text = staff.Phone;
                TxtEmail.Text = staff.Mail;
                DateEditStartDate.Text = staff.StartDateOfWork.ToString();
                DateEditterminationDate.Text = staff.TerminationDate.ToString();
                TxtStatement.Text = staff.Statement;
                TxtPassword.Text = staff.Password;
                pictureEditIDFront.Image = Image.FromFile(staff.IDFront);
                pictureEditIDBack.Image = Image.FromFile(staff.IDBack);
                labelControl15.Text = staff.IDFront;
                labelControl16.Text = staff.IDBack;
                lookUpEditDepartment.EditValue = staff.Department;
                lookUpEditMission.EditValue = staff.Mission;

            }
            lookUpEditDepartment.Properties.DataSource = (from x in db.TblDepartments
                                                          select new
                                                          {
                                                              x.DepartmentID,
                                                              x.DepartmentName
                                                          }).ToList();

            lookUpEditMission.Properties.DataSource = (from x in db.TblMissions
                                                       select new
                                                       {
                                                           x.MissionID,
                                                           x.MissionName
                                                       }).ToList();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(TxtNameSurname.Text) ||
                    string.IsNullOrWhiteSpace(TxtTC.Text) ||
                    string.IsNullOrWhiteSpace(TxtAddres.Text) ||
                    string.IsNullOrWhiteSpace(TxtPhone.Text) ||
                    string.IsNullOrWhiteSpace(DateEditStartDate.Text) ||
                    lookUpEditDepartment.EditValue == null ||
                    lookUpEditMission.EditValue == null ||
                    string.IsNullOrWhiteSpace(TxtEmail.Text) ||
                    string.IsNullOrWhiteSpace(pictureEditIDFront.GetLoadedImageLocation()) ||
                    string.IsNullOrWhiteSpace(pictureEditIDBack.GetLoadedImageLocation()))
                {
                    XtraMessageBox.Show("Please fill in all the required fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop further execution
                }

                TblStaff t = new TblStaff();
                t.NameSurname = TxtNameSurname.Text;
                t.TC = TxtTC.Text;
                t.Address = TxtAddres.Text;
                t.Phone = TxtPhone.Text;
                t.StartDateOfWork = DateTime.Parse(DateEditStartDate.Text);
                t.Department = int.Parse(lookUpEditDepartment.EditValue.ToString());
                t.Mission = int.Parse(lookUpEditMission.EditValue.ToString());
                t.Statement = TxtStatement.Text;
                t.Mail = TxtEmail.Text;
                t.IDFront = pictureEditIDFront.GetLoadedImageLocation();
                t.IDBack = pictureEditIDBack.GetLoadedImageLocation();
                t.Password = TxtPassword.Text;
                t.Status = 1;

                repo.TAdd(t);
                XtraMessageBox.Show("Staff successfully added to the system", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var value = repo.Find(x => x.StaffID == id);
            value.NameSurname = TxtNameSurname.Text;
            value.TC = TxtTC.Text;
            value.Address = TxtAddres.Text;
            value.Phone = TxtPhone.Text;
            value.StartDateOfWork = DateTime.Parse(DateEditStartDate.Text);
            value.Department = int.Parse(lookUpEditDepartment.EditValue.ToString());
            value.Mission = int.Parse(lookUpEditMission.EditValue.ToString());
            value.Statement = TxtStatement.Text;
            value.Mail = TxtEmail.Text;
            value.Password = TxtPassword.Text;
            value.IDFront = labelControl15.Text;
            value.IDBack = labelControl16.Text;
            repo.TUpdate(value);
            XtraMessageBox.Show("Staff information has been successfully updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pictureEditIDFront_EditValueChanged(object sender, EventArgs e)
        {
            labelControl15.Text = pictureEditIDFront.GetLoadedImageLocation().ToString();
        }

        private void pictureEditIDBack_EditValueChanged(object sender, EventArgs e)
        {
            labelControl16.Text = pictureEditIDBack.GetLoadedImageLocation().ToString();
        }
    }
}
