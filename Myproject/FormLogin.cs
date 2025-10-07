using MyProject.Entities;   // User, Role
using MyProject.BLL;        // UserManager
using MyProject.Helpers;    // DbHelper, PasswordHelper
using System;
using System.Windows.Forms;

namespace MyProject.UI
{
    public partial class FormLogin : Form
    {
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblMessage;
        private Label label1;
        private Label label2;
        private UserManager userManager = new UserManager();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Email ve şifre boş olamaz!";
                return;
            }

            var user = userManager.GetUserByEmail(email);

            if (user == null)
            {
                lblMessage.Text = "Kullanıcı bulunamadı!";
                return;
            }

            if (!user.IsActive)
            {
                lblMessage.Text = "Kullanıcı pasif durumda!";
                return;
            }

            bool isValid = PasswordHelper.VerifyPassword(password, user.PasswordHash, user.Salt);

            if (!isValid)
            {
                lblMessage.Text = "Şifre yanlış!";
                return;
            }

            if (user.MustChangePassword)
            {
                MessageBox.Show("İlk giriş, lütfen şifrenizi değiştirin.");
                // Şifre değiştirme formunu açabilirsin
            }

            this.Hide();
            var profilForm = new FormProfil(user);
            profilForm.Show();
        }

        private void InitializeComponent()
        {
            this.txtEmail = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.lblMessage = new Label();
            this.label1 = new Label();
            this.label2 = new Label();
            this.SuspendLayout();

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(131, 80);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 22);
            this.txtEmail.TabIndex = 0;

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(131, 132);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(150, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(143, 200);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Giriş";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // lblMessage
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(110, 36);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(78, 16);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "";

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Email";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Şifre";

            // FormLogin
            this.ClientSize = new System.Drawing.Size(360, 307);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Name = "FormLogin";
            this.Text = "Giriş";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }
    }
}
