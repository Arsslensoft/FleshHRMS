using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DevExpress.DevAV {
    public abstract class DocumentContentViewModelBase : IDocumentContent {
        protected DocumentContentViewModelBase() { }

        void IDocumentContent.OnClose(CancelEventArgs e) { }
        void IDocumentContent.OnDestroy() { }
        IDocumentOwner IDocumentContent.DocumentOwner { get; set; }
        object IDocumentContent.Title { get { return GetTitle(); } }

        [Command]
        public void Close() {
            ((IDocumentContent)this).DocumentOwner.Close(this);
        }

        protected virtual string GetTitle() {
            return null;
        }
    }
}
