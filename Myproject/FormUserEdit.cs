using MyProject.Entities;   // User, Role
using MyProject.BLL;        // UserManager
using MyProject.Helpers;    // DbHelper, PasswordHelper
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyProject.UI
{
    public partial class FormUserEdit : Form
    {
        private UserManager _userManager = new UserManager();
        private ComboBox cmbRole;
        private Button btnSave;
        private Label lblMessage;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private Label label1;
        private Label label2;
        private Label label3;
        private User _editingUser = null; // null = yeni kullanıcı

        public FormUserEdit(User user = null)
        {
            _editingUser = user;
            InitializeComponent();
            LoadRoles();
            if (_editingUser != null)
                LoadUserData();
        }

        private void LoadRoles()
        {
            cmbRole.Items.Add(new { Id = 1, Name = "Admin" });
            cmbRole.Items.Add(new { Id = 2, Name = "User" });
            cmbRole.DisplayMember = "Name";
            cmbRole.ValueMember = "Id";
            cmbRole.SelectedIndex = 0;
        }

        private void LoadUserData()
        {
            txtFullName.Text = _editingUser.FullName;
            txtEmail.Text = _editingUser.Email;
            cmbRole.SelectedIndex = _editingUser.RoleId - 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            int roleId = ((dynamic)cmbRole.SelectedItem).Id;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email))
            {
                lblMessage.Text = "Ad Soyad ve Email boş olamaz!";
                return;
            }

            if (_editingUser == null)
            {
                string defaultPassword = $"{fullName[0]}{fullName.Split(' ')[1]}1234";
                var (hash, salt) = PasswordHelper.CreateHash(defaultPassword);

                _userManager.AddUser(fullName, email, hash, salt, roleId);
                MessageBox.Show("Kullanıcı eklendi. Default şifre ile giriş yapabilir.");
            }
            else
            {
                _editingUser.FullName = fullName;
                _editingUser.RoleId = roleId;
                _userManager.UpdateUser(_editingUser);
                MessageBox.Show("Kullanıcı güncellendi.");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.cmbRole = new ComboBox();
            this.btnSave = new Button();
            this.lblMessage = new Label();
            this.txtFullName = new TextBox();
            this.txtEmail = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();

            // 
            // cmbRole
            // 
            this.cmbRole.Location = new System.Drawing.Point(210, 178);
            this.cmbRole.Size = new System.Drawing.Size(174, 24);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(210, 233);
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(543, 89);
            this.lblMessage.Text = "";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(210, 70);
            this.txtFullName.Size = new System.Drawing.Size(100, 22);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(210, 121);
            this.txtEmail.Size = new System.Drawing.Size(100, 22);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 73);
            this.label1.Text = "Ad Soyad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 121);
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 178);
            this.label3.Text = "Rol";
            // 
            // FormUserEdit
            // 
            this.ClientSize = new System.Drawing.Size(712, 383);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "FormUserEdit";
            this.Text = "Kullanıcı Düzenle / Ekle";
            this.Load += new EventHandler(this.FormUserEdit_Load);
        }

        private void FormUserEdit_Load(object sender, EventArgs e)
        {
            // İsteğe bağlı yükleme işlemleri
        }
    }
}
