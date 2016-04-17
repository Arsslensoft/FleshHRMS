using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace PHRMS
{
    public abstract class DocumentContentViewModelBase : IDocumentContent
    {
        void IDocumentContent.OnClose(CancelEventArgs e)
        {
        }

        void IDocumentContent.OnDestroy()
        {
        }

        IDocumentOwner IDocumentContent.DocumentOwner { get; set; }

        object IDocumentContent.Title
        {
            get { return GetTitle(); }
        }

        [Command]
        public void Close()
        {
            ((IDocumentContent) this).DocumentOwner.Close(this);
        }

        protected virtual string GetTitle()
        {
            return null;
        }
    }
}