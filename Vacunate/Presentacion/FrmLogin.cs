using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Presentacion.Usuario;

namespace Presentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            //PersonalizarControls();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wsg, int wparam, int lparam);

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PersonalizarControls()
        {
            this.txtUserName.AutoSize = false;
            this.txtUserName.Size = new Size(287,25);

            this.txtPassword.AutoSize = false;
            this.txtPassword.Size = new Size(287, 25);
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rectangle = btnLogin.ClientRectangle;
            rectangle.Inflate(0, 30);
            buttonPath.AddEllipse(rectangle);
            btnLogin.Region = new Region(buttonPath);
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if (txtUserName.Text == "Usuario")
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.RoyalBlue;
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Text = "Usuario";
                txtUserName.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Contraseña";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Contraseña")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.RoyalBlue;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void MsgError(string mensaje)
        {
            labelErrorMessage.Text = mensaje;
            labelErrorMessage.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var rol = radioButtonPaciente.Checked ? "P" : radioButtonFunci.Checked ? "F" : null;
            bool validLogin = false;
            if (rol != null)
            {
                if (txtUserName.Text != "Usuario")
                {
                    if (txtPassword.Text != "Contraseña")
                    {
                        if (rol == "F")
                        {
                            UserModel userModel = new UserModel();
                            validLogin = userModel.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                        }
                        else
                        {
                            PatientsModel patientsModel = new PatientsModel();
                            validLogin = patientsModel.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                        }
                        
                        if (validLogin)
                        {
                            this.Hide();
                            FrmBienvenida bienvenida = new FrmBienvenida();
                            bienvenida.ShowDialog();
                            if (rol == "F")
                            {
                                FrmPrincipal principal = new FrmPrincipal();
                                principal.Show();
                            }
                            else
                            {
                                FrmPrincipalPaciente principalPaciente = new FrmPrincipalPaciente();
                                principalPaciente.Show();
                            }
                            

                        }
                        else
                        {
                            MsgError("Usuario o Contraseña incorrectos. \n Por favor intentelo nuevamente");
                            txtPassword.Text = "Contraseña";
                            txtPassword.UseSystemPasswordChar = false;
                            txtUserName.Focus();
                        }
                    }
                    else
                    {
                        MsgError("Por favor digite su Contraseña");
                    }
                }
                else
                {
                    MsgError("Por favor digite su Usuario");
                }
            }
            else
            {
                MsgError("Por favor seleccione su rol");
            }
           
        }

        private void linkLabelRecuperarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var recoveryPassword = new FrmRecuperarContraseña();
            recoveryPassword.ShowDialog();
        }
    }
}
