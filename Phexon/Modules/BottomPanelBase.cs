using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using PHRMS.Helpers;

namespace PHRMS.Modules
{
    public partial class BottomPanelBase : XtraUserControl
    {
        private static Image splitterImageCore;

        public BottomPanelBase()
        {
            InitializeComponent();
            windowsUIButtonPanel1.QueryPeekFormContent += windowsUIButtonPanel1_QueryPeekFormContent;
            windowsUIButtonPanel1.ButtonClick += windowsUIButtonPanel1_ButtonClick;
        }

        public static Image SplitterImage
        {
            get
            {
                if (splitterImageCore == null)
                {
                    splitterImageCore = ResourceImageHelper.CreateBitmapFromResources("PHRMS.Resources.Separator.png",
                        Assembly.GetExecutingAssembly());
                }
                return splitterImageCore;
            }
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (e.Button.Properties.Tag != null)
            {
                windowsUIButtonPanel1.ShowPeekForm(e.Button);
            }
        }

        private void windowsUIButtonPanel1_QueryPeekFormContent(object sender, QueryPeekFormContentEventArgs e)
        {
            if (e.Button.Properties.Tag != null && e.Button.Properties.Tag is Control)
            {
                e.Control = e.Button.Properties.Tag as Control;
            }
        }

        public void InitializeButtons(List<ButtonInfo> listButtonInfo, bool searchControlVisible)
        {
            Visible = true;
            windowsUIButtonPanel1.Buttons.Clear();
            windowsUIButtonPanel1.HidePeekForm();
            foreach (var buttonInfo in listButtonInfo)
            {
                WindowsUIButton button;
                if (buttonInfo.Text == null && buttonInfo.Image == null)
                {
                    button = new WindowsUIButton();
                    button.Enabled = false;
                    button.UseCaption = false;
                    button.Image = SplitterImage;
                }
                else
                {
                    button = new WindowsUIButton(buttonInfo.Text, buttonInfo.Image, 0, ButtonStyle.PushButton, 0);
                    button.Tag = buttonInfo.PopupMenuContent;
                    button.Click += buttonInfo.mouseEventHandler;
                }
                windowsUIButtonPanel1.Buttons.Add(button);
            }
            if (searchControlVisible)
            {
                searchLayoutControlItem.Visibility = LayoutVisibility.Always;
            }
            else
            {
                searchLayoutControlItem.Visibility = LayoutVisibility.Never;
            }
        }

        public void InitializeButtons(List<ButtonInfo> listButtonInfo)
        {
            InitializeButtons(listButtonInfo, true);
        }
    }
}