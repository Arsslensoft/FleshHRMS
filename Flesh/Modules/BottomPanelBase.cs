using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.DevAV.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010;
using System.Reflection;
using DevExpress.Utils;

namespace DevExpress.DevAV.Modules {
    public partial class BottomPanelBase : XtraUserControl {
        public BottomPanelBase() {
            InitializeComponent();
            windowsUIButtonPanel1.QueryPeekFormContent += windowsUIButtonPanel1_QueryPeekFormContent;
            windowsUIButtonPanel1.ButtonClick += windowsUIButtonPanel1_ButtonClick;
        }
        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e) {
            if (e.Button.Properties.Tag != null) {
                windowsUIButtonPanel1.ShowPeekForm(e.Button);
            }
        }
        private void windowsUIButtonPanel1_QueryPeekFormContent(object sender, QueryPeekFormContentEventArgs e) {
            if (e.Button.Properties.Tag != null && e.Button.Properties.Tag is Control) {
                e.Control = e.Button.Properties.Tag as Control;
            }
        }
        private static Image splitterImageCore = null;
        public static Image SplitterImage {
            get {
                if (splitterImageCore == null) {
                    splitterImageCore = ResourceImageHelper.CreateBitmapFromResources("DevExpress.DevAV.Resources.Separator.png", Assembly.GetExecutingAssembly());
                }
                return splitterImageCore;
            }
        }
        public void InitializeButtons(List<ButtonInfo> listButtonInfo, bool searchControlVisible) {
            Visible = true;
            windowsUIButtonPanel1.Buttons.Clear();
            windowsUIButtonPanel1.HidePeekForm();
            foreach (ButtonInfo buttonInfo in listButtonInfo) {
                WindowsUIButton button;
                if (buttonInfo.Text == null && buttonInfo.Image == null) {
                    button = new WindowsUIButton();
                    button.Enabled = false;
                    button.UseCaption = false;
                    button.Image = SplitterImage;
                } else {
                    button = new WindowsUIButton(buttonInfo.Text, buttonInfo.Image, 0, ButtonStyle.PushButton, 0);
                    button.Tag = buttonInfo.PopupMenuContent;
                    button.Click += buttonInfo.mouseEventHandler;
                }
                windowsUIButtonPanel1.Buttons.Add(button);
            }
            if (searchControlVisible) {
                searchLayoutControlItem.Visibility = XtraLayout.Utils.LayoutVisibility.Always;
            } else {
                searchLayoutControlItem.Visibility = XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
        public void InitializeButtons(List<ButtonInfo> listButtonInfo) {
            InitializeButtons(listButtonInfo, true);
        }
    }
}
