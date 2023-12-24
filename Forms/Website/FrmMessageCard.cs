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

namespace HotelManagementAutomation.Forms.Website
{
    public partial class FrmMessageCard : Form
    {
        public FrmMessageCard()
        {
            InitializeComponent();
        }

        DbHotelEntities db = new DbHotelEntities();
        Repository<TblMessage2> repo = new Repository<TblMessage2>();
        Repository<TblMessage> repocontact = new Repository<TblMessage>();
        public int id;
        public int id2;
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMessageCard_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                var message = repo.Find(x => x.MessageID == id);
                TxtSenderEmail.Text = message.Sender;
                TxtSubject.Text = message.Subject;
                TxtMessage.Text = message.Message;
                TxtDate.Text = message.Date.ToString();

                var person = db.TblNewRegistry.Where(x => x.Email == message.Sender).Select(y => y.NameSurname).FirstOrDefault();
                if(person!= null)
                {
                    TxtNameSurname.Text = person.ToString();
                }
                else
                {
                    TxtNameSurname.Text = "Admin";
                }
                
            }

            if (id2 != 0)
            {
                var message = repocontact.Find(x => x.MessageID == id2);
                TxtSenderEmail.Text = message.Sender;
                TxtSubject.Text = message.Subject;
                TxtMessage.Text = message.Message;
                TxtNameSurname.Text = message.Sender;

                var person = db.TblNewRegistry.Where(x => x.Email == message.Sender).Select(y => y.NameSurname).FirstOrDefault();
                if (person != null)
                {
                    TxtNameSurname.Text = person.ToString();
                }
                else
                {
                    TxtNameSurname.Text = "Admin";
                }

            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            TblMessage2 t = new TblMessage2();
            t.Sender = "Admin";
            t.Reciever = TxtSenderEmail.Text;
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            t.Subject = TxtSubject.Text;
            t.Message = TxtMessage.Text;
            repo.TAdd(t);
            XtraMessageBox.Show("Your message delivered succefully");
        }
    }
}
