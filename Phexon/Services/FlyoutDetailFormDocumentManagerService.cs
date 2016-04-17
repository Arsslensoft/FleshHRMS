using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Mvvm;
using DevExpress.XtraBars.Docking2010.Customization;
using PHRMS.Modules;
using PHRMS.Services;

namespace PHRMS
{
    internal class FlyoutDetailFormDocumentManagerService : IDocumentManagerService, IDocumentOwner
    {
        private readonly ModuleType viewModuleType;
        private readonly IList<IDocument> documents;

        public FlyoutDetailFormDocumentManagerService(ModuleType viewModuleType)
        {
            this.viewModuleType = viewModuleType;
            documents = new List<IDocument>();
        }

        public IEnumerable<IDocument> Documents
        {
            get { return documents; }
        }

        IDocument IDocumentManagerService.CreateDocument(string documentType, object viewModel, object parameter,
            object parentViewModel)
        {
            var actualModuleType = GetActualViewModuleType(documentType, parentViewModel);
            var moduleLocator = ((ISupportServices) parentViewModel).ServiceContainer.GetService<IModuleLocator>();
            object view = null;
            if (parameter is Guid)
                view = moduleLocator.GetModule(actualModuleType, (Guid) parameter);
            else
                view = moduleLocator.GetModule(actualModuleType);
            viewModel = EnsureViewModel(viewModel, parameter, parentViewModel, view);
            return RegisterDocument(control => new FlyoutDocument(this, control, viewModel), view, parameter);
        }

        IDocument IDocumentManagerService.ActiveDocument
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        event ActiveDocumentChangedEventHandler IDocumentManagerService.ActiveDocumentChanged
        {
            add { }
            remove { }
        }

        void IDocumentOwner.Close(IDocumentContent documentContent, bool force)
        {
            var document = documents.FirstOrDefault(d => Equals(d.Content, documentContent));
            if (document != null)
                document.Close(force);
        }

        protected virtual ModuleType GetActualViewModuleType(string documentType, object parentViewModel)
        {
            return viewModuleType;
        }

        protected object EnsureViewModel(object viewModel, object parameter, object parentViewModel, object view)
        {
            if (viewModel == null)
            {
                if (view is ISupportViewModel)
                    viewModel = ((ISupportViewModel) view).ViewModel;
                ViewModelHelper.EnsureModuleViewModel(view, parentViewModel, parameter);
            }
            var documentContent = viewModel as IDocumentContent;
            if (documentContent != null)
                documentContent.DocumentOwner = this;
            return viewModel;
        }

        protected IDocument RegisterDocument(Func<Control, IDocument> create, object view, object id)
        {
            var document = create((Control) view);
            document.Id = id;
            documents.Add(document);
            return document;
        }

        #region Document

        protected class FlyoutDocument : IDocument, IDocumentInfo
        {
            private readonly object content;
            private readonly FlyoutDetailFormDocumentManagerService owner;
            private readonly Control view;
            private FlyoutDialog dialog;
            private DocumentState state = DocumentState.Hidden;

            public FlyoutDocument(FlyoutDetailFormDocumentManagerService owner, Control control, object content)
            {
                this.owner = owner;
                view = control;
                this.content = content;
            }

            void IDocument.Show()
            {
                if (dialog == null)
                {
                    dialog = new FlyoutDialog(Program.MainForm, view, Program.MainForm.MenuManager);
                    dialog.Closed += dialog_Closed;
                    using (dialog)
                        dialog.ShowDialog();
                    dialog = null;
                }
                else dialog.Activate();
                state = DocumentState.Visible;
            }

            void IDocument.Hide()
            {
                if (dialog != null)
                {
                    dialog.Hide();
                    state = DocumentState.Hidden;
                }
            }

            void IDocument.Close(bool force)
            {
                if (dialog != null)
                {
                    dialog.Close();
                    state = DocumentState.Hidden;
                }
            }

            bool IDocument.DestroyOnClose
            {
                get { return true; }
                set { }
            }

            object IDocument.Id { get; set; }
            object IDocument.Title { get; set; }

            object IDocument.Content
            {
                get { return GetContent(); }
            }

            DocumentState IDocumentInfo.State
            {
                get { return state; }
            }

            public string DocumentType
            {
                get { return null; }
            }

            private void dialog_Closed(object sender, EventArgs e)
            {
                RemoveFromDocumentsList();
                dialog.Closed -= dialog_Closed;
            }

            private void RemoveFromDocumentsList()
            {
                owner.documents.Remove(this);
            }

            private object GetContent()
            {
                return content;
            }
        }

        #endregion Document
    }
}