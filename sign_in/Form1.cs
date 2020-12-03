using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sign_in
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] arr_hosts = File.ReadAllLines(@"C:\Users\ASUS\Desktop\bibi\Nam_2\Lap_Trinh_truc_quan\sign_in\hieu.txt");
        private void textBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                
                //pass sẽ la cái chuỗi thứ 2
                if(arr_hosts[1]== textBox_password.Text)//pass nhập đúng thì xuất hiện cái file
                {
                    MessageBox.Show("Password is corret.");
                }
                else
                {
                    MessageBox.Show("Password is incorret.");
                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("030301hieu@gmail.com");
            mail.To.Add(arr_hosts[2]);
            mail.Subject = "Password app";
            mail.Body = arr_hosts[1];

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("030301hieu@gmail.com", "bibi030301");
            SmtpServer.EnableSsl = true;
            //SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Send(mail);
            MessageBox.Show("mail Send");
        }
    }
}
