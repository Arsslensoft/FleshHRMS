using System;
using System.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;

public class LabelTabController
{
    private object editValue;
    private readonly object[] list;

    public LabelTabController(object eValue, params object[] list)
    {
        this.list = list;
        EditValue = eValue;
        foreach (LabelControl lb in list)
        {
            lb.Click += (s, e) => EditValue = ((LabelControl) s).Tag;
        }
    }

    public object EditValue
    {
        get { return editValue; }
        set
        {
            editValue = value;
            if (EditValueChanged != null)
            {
                EditValueChanged(EditValue, EventArgs.Empty);
            }
            foreach (LabelControl lc in list)
            {
                if (EditValue.Equals(lc.Tag))
                {
                    lc.Appearance.ForeColor = CommonColors.GetQuestionColor(UserLookAndFeel.Default);
                }
                else
                {
                    lc.Appearance.ForeColor = Color.Empty;
                }
            }
        }
    }

    public event EventHandler EditValueChanged;
}