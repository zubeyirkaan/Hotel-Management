﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HotelManagementAutomation.Entitiy;

namespace HotelManagementAutomation.Forms.Definitions
{
    public partial class FrmStatus : Form
    {
        public FrmStatus()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();

        private void FrmStatus_Load(object sender, EventArgs e)
        {
            db.TblStatus.Load();    
            bindingSource1.DataSource = db.TblStatus.Local;
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch(Exception)
            {
              
                XtraMessageBox.Show("please try again","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db.SaveChanges();
        }
    }
}
