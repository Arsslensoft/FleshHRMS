namespace DevExpress.DevAV.Services {
    using System.ComponentModel;
    using System.Windows.Forms;
    using DevExpress.Mvvm;
    using DevExpress.XtraEditors;

    public class MessageBoxService : IMessageBoxService {
        MessageResult IMessageBoxService.Show(string messageBoxText, string caption, MessageButton button, MessageIcon icon, MessageResult defaultResult) {
            return XtraMessageBox.Show(messageBoxText, caption, button.ToMessageBoxButtons(), icon.ToMessageBoxIcon(), defaultResult.ToMessageBoxDefaultButton(button)).ToMessageResult();
        }
    }
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    static class MessageBoxEnumsConverter {
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageBoxDefaultButton ToMessageBoxDefaultButton(this MessageResult result, MessageButton buttons) {
            switch(result) {
                case MessageResult.No:
                    return MessageBoxDefaultButton.Button2;
                case MessageResult.Cancel:
                    return (buttons == MessageButton.OKCancel) ? MessageBoxDefaultButton.Button2 : MessageBoxDefaultButton.Button3;
                default:
                    return MessageBoxDefaultButton.Button1;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageResult ToMessageResult(this DialogResult result) {
            switch(result) {
                case DialogResult.Cancel: return MessageResult.Cancel;
                case DialogResult.No: return MessageResult.No;
                case DialogResult.Yes: return MessageResult.Yes;
                case DialogResult.OK: return MessageResult.OK;
                default: return MessageResult.None;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageBoxButtons ToMessageBoxButtons(this MessageButton button) {
            switch(button) {
                case MessageButton.OKCancel: return MessageBoxButtons.OKCancel;
                case MessageButton.YesNo: return MessageBoxButtons.YesNo;
                case MessageButton.YesNoCancel: return MessageBoxButtons.YesNoCancel;
                default: return MessageBoxButtons.OK;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageButton ToMessageButton(this MessageBoxButtons button) {
            switch(button) {
                case MessageBoxButtons.OKCancel: return MessageButton.OKCancel;
                case MessageBoxButtons.YesNo: return MessageButton.YesNo;
                case MessageBoxButtons.YesNoCancel: return MessageButton.YesNoCancel;
                default: return MessageButton.OK;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageBoxIcon ToMessageBoxIcon(this MessageIcon icon) {
            switch(icon) {
                case MessageIcon.Error: return MessageBoxIcon.Error;
                case MessageIcon.Information: return MessageBoxIcon.Information;
                case MessageIcon.Question: return MessageBoxIcon.Question;
                case MessageIcon.Warning: return MessageBoxIcon.Warning;
                default: return MessageBoxIcon.None;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageIcon ToMessageIcon(this MessageBoxIcon icon) {
            switch(icon) {
                case MessageBoxIcon.Error: return MessageIcon.Error;
                case MessageBoxIcon.Information: return MessageIcon.Information;
                case MessageBoxIcon.Question: return MessageIcon.Question;
                case MessageBoxIcon.Warning: return MessageIcon.Warning;
                default: return MessageIcon.None;
            }
        }
    }
}
