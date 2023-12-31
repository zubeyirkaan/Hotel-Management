using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        public void OpenForm<T>() where T : Form, new()
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is T)
                {
                    form.Activate();
                    return;
                }
            }

            T newForm = new T
            {
                MdiParent = this
            };
            newForm.Show();
        }

        private void BtnStatusDefinition_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmStatus fr = new Forms.Definitions.FrmStatus();
            fr.ShowDialog();
        }

        private void BtnStockUnitDefinitions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmStockUnit fr = new Forms.Definitions.FrmStockUnit();
            fr.ShowDialog();
        }

        private void BtnDepartmentDefinitions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmDepartment fr = new Forms.Definitions.FrmDepartment();
            fr.ShowDialog();
        }

        private void BtnMissionDefinitions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmMission fr = new Forms.Definitions.FrmMission();
            fr.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmCashRegister fr = new Forms.Definitions.FrmCashRegister();
            fr.ShowDialog();
        }

        private void BtnExchangerateDefinitions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmExchangeRate fr = new Forms.Definitions.FrmExchangeRate();
            fr.ShowDialog();
        }

        private void BtnRoomDefinitions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmRoom fr = new Forms.Definitions.FrmRoom();
            fr.ShowDialog();
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmPhone fr = new Forms.Definitions.FrmPhone();
            fr.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmCountry fr = new Forms.Definitions.FrmCountry();
            fr.ShowDialog();
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmProductGroup fr = new Forms.Definitions.FrmProductGroup();
            fr.ShowDialog();
        }

        private void BtnStaffCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Staff.FrmStaffCard fr = new Forms.Staff.FrmStaffCard();
            fr.ShowDialog();
        }

        private void BtnStaffList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Staff.FrmStaffList>();
        }

        private void BtnGuestCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Guest.FrmGuest fr = new Forms.Guest.FrmGuest();
            fr.ShowDialog();
        }

        private void BtnCustomerList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Guest.FrmGuestList>();
        }

        private void BtnProductList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Product.FrmProductList>();
        }

        private void BtnProductCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Product.FrmProductCard fr = new Forms.Product.FrmProductCard();
            fr.ShowDialog();
        }

        private void BtnProductEntryProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Product.FrmProductEntryProcess>();
        }

        private void BtnProductReductionProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Product.FrmProductReductionProcess>();
        }

        private void BtnNewProductProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Product.FrmProcessDefinitions fr = new Forms.Product.FrmProcessDefinitions();
            fr.ShowDialog();
        }

        private void BtnReservationCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Reservation.FrmReservationCard fr = new Forms.Reservation.FrmReservationCard();
            fr.ShowDialog();
        }

        private void BtnAllReservationList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Reservation.FrmAllReservations>();
        }

        private void BtnActiveReservations_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Reservation.FrmActiveReservations>();
        }

        private void BtnCanceledReservations_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Reservation.FrmCanceledReservations>();
        }

        private void BtnPastreservations_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Reservation.FrmPastReservations>();
        }

        private void BtnFutureReservations_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Reservation.FrmFutureReservations>();
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
            OpenForm<Forms.Tools.FrmCurrency>();
        }

        private void BtnYoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Tools.FrmYoutube>();
        }

        private void BtnGoogle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Tools.FrmGoogle>();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }

        private void BtnNewRegistirations_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Website.FrmNewRegistry>();
        }

        private void BtnPreReservations_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Website.FrmPreReservations>();
        }

        private void BtnRecievedMessages_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Website.FrmRecievedMessages>();
        }

        private void BtnNewMessage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Website.FrmMessageCard fr = new Forms.Website.FrmMessageCard();
            fr.ShowDialog();
        }

        private void BtnSentMessage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Website.FrmSentMessage>();
        }

        private void BtnContact_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Website.FrmContact>();
        }

        private void BtnAddressCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Website.FrmContactCard fr = new Forms.Website.FrmContactCard();
            fr.ShowDialog();
        }

        private void BtnAboutPage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Website.FrmAbout fr = new Forms.Website.FrmAbout();
            fr.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Main.FrmMain>();
        }

        private void BtnGraph1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Graphs.FrmGraph2>();
        }

        private void BtnGraph2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.Graphs.FrmGraph1>();
        }

        private void BtnPassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Admin.FrmPasswordProcess fr = new Forms.Admin.FrmPasswordProcess();
            fr.ShowDialog();
        }

        public string userRole;
        private void Form1_Load(object sender, EventArgs e)
        {
            if(userRole != "A")
            {
                ribbonPage6.Visible = false;
            }

            Forms.Main.FrmMain fr = new Forms.Main.FrmMain();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnAuthorization_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Admin.FrmPasswordProcess fr = new Forms.Admin.FrmPasswordProcess();

            if (userRole != "A")
            {
                fr.BtnList.Visible = false;
                fr.TxtRole.Text = "B";
                fr.TxtRole.ReadOnly = true;               
            }

            fr.BtnSave.Visible = true;
            fr.ShowDialog();
        }

        private void BtnReceptionOperations_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.CashRegister.FrmReceptionOperations>();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Definitions.FrmCashRegister fr = new Forms.Definitions.FrmCashRegister();
            fr.ShowDialog();
        }

        private void BtncashRegisterOutcome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Product.FrmCashRegisterOut fr = new Forms.Product.FrmCashRegisterOut();
            fr.ShowDialog();
        }

        private void BtnCashRegisterOutcomeProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<Forms.CashRegister.FrmCashregisterOutcomeList>();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}