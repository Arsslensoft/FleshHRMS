using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using PHRMS.Data;
using PHRMS.Helpers;
using PHRMS.ViewModels;

namespace PHRMS.Modules
{
    public partial class ImprimerAvertissements : BaseModuleControl
    {
        public ImprimerAvertissements()
            : base(CreateViewModel<WarningPrintView>)
        {
            InitializeComponent();
            ViewModel.ParameterChanged += ViewModel_ParameterChanged;
        }

        public WarningPrintView ViewModel
        {
            get { return GetViewModel<WarningPrintView>(); }
        }

        private void ViewModel_ParameterChanged(object sender, EventArgs e)
        {
            printableComponentLink.Component = ViewModel.GetParameter() as GridControl;
            printableComponentLink.CreateDocument();
        }

        protected override void Return()
        {
            GetParentViewModel<MainViewModel>().SelectModule(ModuleType.Avertissements);
        }

        protected internal override void OnTransitionCompleted()
        {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }

        private void InitializeButtonPanel()
        {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Agrandir",
                Name = "1",
                Image = ImageHelper.GetImageFromToolbarResource("ZoomIn"),
                mouseEventHandler = zoomInClick
            });
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Dézoomer",
                Name = "2",
                Image = ImageHelper.GetImageFromToolbarResource("ZoomOut"),
                mouseEventHandler = zoomOutClick
            });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Imprimer",
                Name = "4",
                Image = ImageHelper.GetImageFromToolbarResource("Print"),
                mouseEventHandler = (e, s) => { DoPrint(); }
            });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo
            {
                Type = typeof(SimpleButton),
                Text = "Fermer",
                Name = "3",
                Image = ImageHelper.GetImageFromToolbarResource("Cancel"),
                mouseEventHandler = (e, s) => { Cancel(); }
            });

            BottomPanel.InitializeButtons(listBI, false);
        }

        private void DoPrint()
        {
            documentViewer.ExecCommand(PrintingSystemCommand.PrintDirect);
        }

        private void zoomOutClick(object sender, EventArgs e)
        {
            documentViewer.Zoom -= 0.10f;
        }

        private void zoomInClick(object sender, EventArgs e)
        {
            documentViewer.Zoom += 0.10f;
        }
    }


    public class WarningPrintView : WarningsCollectionViewModel
    {
        public override Warning SelectedEntity
        {
            get { return null; }
        }

        internal object GetParameter()
        {
            return Parameter;
        }
    }
}