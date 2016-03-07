namespace DevExpress.DevAV.ViewModels {
    using System;
    using DevExpress.DevAV;
    using DevExpress.Mvvm;

    public abstract class MailMergeViewModelBase<TMailTemplate> : DocumentContentViewModelBase, ISupportParameter
        where TMailTemplate: struct {
        public virtual TMailTemplate? MailTemplate { get; set; }
        protected virtual void OnMailTemplateChanged() {
            RaiseMailTemplateChanged();
        }
        public virtual bool IsMailTemplateSelected { get; set; }
        protected virtual void OnIsMailTemplateSelectedChanged() {
            RaiseMailTemplateSelectedChanged();
        }
        object ISupportParameter.Parameter {
            get {
                return MailTemplate;
            }
            set {
                IsMailTemplateSelected = value is TMailTemplate;
                if (IsMailTemplateSelected) {
                    MailTemplate = (TMailTemplate)value;
                } else {
                    MailTemplate = null;
                }
            }
        }
        public event EventHandler MailTemplateChanged;
        public event EventHandler MailTemplateSelectedChanged;
        private void RaiseMailTemplateChanged() {
            EventHandler handler = MailTemplateChanged;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }
        private void RaiseMailTemplateSelectedChanged() {
            EventHandler handler = MailTemplateSelectedChanged;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
