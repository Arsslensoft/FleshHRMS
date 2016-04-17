using DevExpress.XtraEditors;
using PHRMS.Data;
using PHRMS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PHRMS
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

            ExitProcess();
        }

        public void ExitProcess()
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
                    DevExpress.XtraEditors.XtraMessageBox.Show("Informations incorrectes", "Login Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (li.User.GetSha256FromString(textEdit1.Text) == li.User.PasswordHash)
                    {
                        if (li.User.Role == EmployeeRole.Employee)
                            DevExpress.XtraEditors.XtraMessageBox.Show("Accès refusé", "Contrôle d'accès", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MainViewModel.CurrentEmployee = li.User;
                            cancel_exit = false;
                    
                            this.Close();
                        }
                    }
                    else DevExpress.XtraEditors.XtraMessageBox.Show("Informations incorrectes", "Login Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cancel_exit)
            {
                if (
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "The application requires login to proceed. \r\nDo you want to login?",
                        "Authentification required", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                    System.Windows.Forms.DialogResult.Yes)
                    e.Cancel = true;
                else
                    ExitProcess();
            }
        }

        private void textEdit1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                simpleButton1_Click(this, EventArgs.Empty);
        }
    }
    class LoginInfo
    {
        public Employee User { get; set; }
        public string Password { get; set; }
    }
}
