using DevExpress.XtraEditors;
using FHRMS.Data;
using FHRMS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FHRMS
{
    public partial class Login : XtraForm
    {
        public MainViewModel ViewModel{get;set;}
        public EmployeeCollectionViewModel EmployeesViewModel { get; set; }
    
        public Login(MainViewModel vm)
        {
            InitializeComponent();
            bindingSource1.DataSource = typeof(LoginInfo);
            ViewModel = vm;
            EmployeesViewModel = vm.TryGetModuleViewModel<EmployeeCollectionViewModel>(ModuleType.Employés);
            lookUpEdit1.Properties.DataSource = EmployeesViewModel.Entities.ToList();
            bindingSource1.DataSource = new LoginInfo();
        }

        private void Login_Load(object sender, EventArgs e)
        {
     
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        bool cancel_exit = true;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                LoginInfo li = bindingSource1.Current as LoginInfo;
                if (li == null)
                    DevExpress.XtraEditors.XtraMessageBox.Show("Informations incorrectes", "Invalid login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (li.User.Credential.GetSha256FromString(li.Password) == li.User.Credential.PasswordHash)
                    {
                   ViewModel.CurrentEmployee = li.User;
                        cancel_exit = false;
                        this.Close();
                    }
                    else DevExpress.XtraEditors.XtraMessageBox.Show("Informations incorrectes", "Invalid login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Login error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cancel_exit)
            {
                if(DevExpress.XtraEditors.XtraMessageBox.Show("The application requires login to proceed. \r\nDo you want to login?", "Authentification required", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                            e.Cancel = true;

            }
        }
    }
    class LoginInfo
    {
        public Employee User { get; set; }
        public string Password { get; set; }
    }
}
