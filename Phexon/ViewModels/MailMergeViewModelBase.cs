using System;
using DevExpress.Mvvm;

namespace PHRMS.ViewModels
{
    public abstract class MailMergeViewModelBase<TMailTemplate> : DocumentContentViewModelBase, ISupportParameter
        where TMailTemplate : struct
    {
        public virtual TMailTemplate? MailTemplate { get; set; }
        public virtual bool IsMailTemplateSelected { get; set; }

        object ISupportParameter.Parameter
        {
            get { return MailTemplate; }
            set
            {
                IsMailTemplateSelected = value is TMailTemplate;
                if (IsMailTemplateSelected)
                {
                    MailTemplate = (TMailTemplate) value;
                }
                else
                {
                    MailTemplate = null;
                }
            }
        }

        protected virtual void OnMailTemplateChanged()
        {
            RaiseMailTemplateChanged();
        }

        protected virtual void OnIsMailTemplateSelectedChanged()
        {
            RaiseMailTemplateSelectedChanged();
        }

        public event EventHandler MailTemplateChanged;
        public event EventHandler MailTemplateSelectedChanged;

        private void RaiseMailTemplateChanged()
        {
            var handler = MailTemplateChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void RaiseMailTemplateSelectedChanged()
        {
            var handler = MailTemplateSelectedChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}