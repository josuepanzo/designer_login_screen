using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Splash_login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int iparam);

        private void txt_user_Enter(object sender, EventArgs e)
        {
            if(this.txt_user.Text == "Usuário") {
                this.txt_user.Text = "";
                this.txt_user.ForeColor = Color.DarkBlue;
            }
        }

        private void txt_user_Leave(object sender, EventArgs e)
        {
            if (this.txt_user.Text == "")
            {
                this.txt_user.Text = "Usuário";
                this.txt_user.ForeColor = Color.DimGray;
            }
        }

        private void txt_password_Enter(object sender, EventArgs e) {
            if (txt_password.Text == "Password") {
                txt_password.Text = "";
                txt_password.ForeColor = Color.DarkBlue;
                txt_password.UseSystemPasswordChar = true;
            }
        }

        private void txt_password_Leave(object sender, EventArgs e) {
            if (txt_password.Text == "") {
                txt_password.Text = "Password";
                txt_password.ForeColor = Color.DimGray;
                txt_password.UseSystemPasswordChar = false;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
