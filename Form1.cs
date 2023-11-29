using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BtnStatusDefinition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmStatus fr = new Forms.Definitions.FrmStatus();
            fr.Show();
        }

        private void BtnStockUnitDefinitions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmStockUnit fr = new Forms.Definitions.FrmStockUnit();
            fr.Show();
        }

        private void BtnDepartmentDefinitions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmDepartment fr = new Forms.Definitions.FrmDepartment();
            fr.Show();
        }

        private void BtnMissionDefinitions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmMission fr = new Forms.Definitions.FrmMission();
            fr.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmCashRegister fr = new Forms.Definitions.FrmCashRegister();
            fr.Show();
        }

        private void BtnExchangerateDefinitions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmExchangeRate fr = new Forms.Definitions.FrmExchangeRate();
            fr.Show();
        }

        private void BtnRoomDefinitions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmRoom fr = new Forms.Definitions.FrmRoom();
            fr.Show();
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmPhone fr = new Forms.Definitions.FrmPhone();
            fr.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmCountry fr = new Forms.Definitions.FrmCountry();
            fr.Show();
        }
    }
}
