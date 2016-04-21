using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PHRMS.Data;
using PHRMS.ViewModels;

namespace PHRMS
{
    public partial class Login : XtraForm
    {
        private bool cancel_exit = true;

        public Login(MainViewModel vm)
        {
            InitializeComponent();
            bindingSource1.DataSource = typeof(LoginInfo);
            ViewModel = vm;
            EmployeesViewModel = vm.TryGetModuleViewModel<EmployeeCollectionViewModel>(ModuleType.Employés);
            lookUpEdit1.Properties.DataSource = EmployeesViewModel.Entities.Where(x => x.Role >= EmployeeRole.Agent).ToList();
            bindingSource1.DataSource = new LoginInfo();
        }

        public MainViewModel ViewModel { get; set; }
        public EmployeeCollectionViewModel EmployeesViewModel { get; set; }

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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var li = bindingSource1.Current as LoginInfo;
                if (li == null)
                    XtraMessageBox.Show("Informations incorrectes", "Login Invalide", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                else
                {
                    if (textEdit1.Text == li.User.Password)
                    {
                        if (li.User.Role == EmployeeRole.Employee)
                            XtraMessageBox.Show("Accès refusé", "Contrôle d'accès", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        else
                        {
                            MainViewModel.CurrentEmployee = li.User;
                            cancel_exit = false;

                            Close();
                        }
                    }
                    else
                        XtraMessageBox.Show("Informations incorrectes", "Login Invalide", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cancel_exit)
            {
                if (
                    XtraMessageBox.Show(
                        "The application requires login to proceed. \r\nDo you want to login?",
                        "Authentification required", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                    DialogResult.Yes)
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

    internal class LoginInfo
    {
        public Employee User { get; set; }
        public string Password { get; set; }
    }
}