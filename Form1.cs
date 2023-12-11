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

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmProductGroup fr = new Forms.Definitions.FrmProductGroup();
            fr.Show();
        }

        private void BtnStaffCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Staff.FrmStaffCard fr = new Forms.Staff.FrmStaffCard();
            fr.Show();
        }

        private void BtnStaffList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Staff.FrmStaffList fr = new Forms.Staff.FrmStaffList();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnGuestCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Guest.FrmGuest fr = new Forms.Guest.FrmGuest();
            fr.Show();
        }

        private void BtnCustomerList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Guest.FrmGuestList fr = new Forms.Guest.FrmGuestList();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnProductList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Product.FrmProductList fr = new Forms.Product.FrmProductList();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnProductCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Product.FrmProductCard fr = new Forms.Product.FrmProductCard();
            fr.Show();
        }

        private void BtnProductEntryProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Product.FrmProductEntryProcess fr = new Forms.Product.FrmProductEntryProcess();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnProductReductionProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Product.FrmProductReductionProcess fr = new Forms.Product.FrmProductReductionProcess();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnNewProductProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Product.FrmProcessDefinitions fr = new Forms.Product.FrmProcessDefinitions();
            fr.Show();
        }

        private void BtnReservationCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Reservation.FrmReservationCard fr = new Forms.Reservation.FrmReservationCard();
            fr.Show();
        }

        private void BtnAllReservationList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Reservation.FrmAllReservations fr = new Forms.Reservation.FrmAllReservations();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnActiveReservations_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Reservation.FrmActiveReservations fr = new Forms.Reservation.FrmActiveReservations();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnCanceledReservations_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Reservation.FrmCanceledReservations fr = new Forms.Reservation.FrmCanceledReservations();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnPastreservations_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Reservation.FrmPastReservations fr = new Forms.Reservation.FrmPastReservations();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnFutureReservations_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Reservation.FrmFutureReservations fr = new Forms.Reservation.FrmFutureReservations();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void BtnCalculator_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void BtnCurrency_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Tools.FrmCurrency fr = new Forms.Tools.FrmCurrency();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnYoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Tools.FrmYoutube fr = new Forms.Tools.FrmYoutube();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnGoogle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Tools.FrmGoogle fr = new Forms.Tools.FrmGoogle();
            fr.MdiParent = this;
            fr.Show();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }
    }
}




