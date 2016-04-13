﻿using System;
using System.Collections.Generic;
using System.Linq;
using PHRMS.ViewModels;
using PHRMS.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;


namespace PHRMS.Modules {
    public partial class ImprimerAbsence : BaseModuleControl {
        public ImprimerAbsence()
            : base(CreateViewModel<AbsencesPrintView>)
        {
            InitializeComponent();
            ViewModel.ParameterChanged += ViewModel_ParameterChanged;
        }

        private void ViewModel_ParameterChanged(object sender, EventArgs e) {
            printableComponentLink.Component = ViewModel.GetParameter() as GridControl;
            printableComponentLink.CreateDocument();
        }
        protected override void Return() {
            GetParentViewModel<MainViewModel>().SelectModule(ModuleType.Absences);
        }
        protected internal override void OnTransitionCompleted() {
            base.OnTransitionCompleted();
            InitializeButtonPanel();
        }

        private void InitializeButtonPanel() {
            var listBI = new List<ButtonInfo>();
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Agrandir", Name = "1", Image = ImageHelper.GetImageFromToolbarResource("ZoomIn"), mouseEventHandler = zoomInClick });
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Dézoomer", Name = "2", Image = ImageHelper.GetImageFromToolbarResource("ZoomOut"), mouseEventHandler = zoomOutClick });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() { Type = typeof(SimpleButton), Text = "Imprimer", Name = "4", Image = ImageHelper.GetImageFromToolbarResource("Print"), mouseEventHandler = (e, s) => {
                DoPrint();
            } });
            listBI.Add(new ButtonInfo());
            listBI.Add(new ButtonInfo() {
                Type = typeof(SimpleButton),
                Text = "Fermer",
                Name = "3",
                Image = ImageHelper.GetImageFromToolbarResource("Cancel"),
                mouseEventHandler = (e, s) => {
                    Cancel();
                }
            });

            BottomPanel.InitializeButtons(listBI, false);
        }
        public AbsencesPrintView ViewModel
        {
            get {
                return GetViewModel<AbsencesPrintView>();
            }
        }
        private void DoPrint() {
            documentViewer.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect);
        }
        private void zoomOutClick(object sender, EventArgs e) {
            documentViewer.Zoom -= 0.10f;
        }
        private void zoomInClick(object sender, EventArgs e) {
            documentViewer.Zoom += 0.10f;
        }
    }


    public class AbsencesPrintView : AbsencesCollectionViewModel {
        internal object GetParameter() {
            return Parameter;
        }
        public override PHRMS.Data.Absence SelectedEntity {
            get {return null;}
        }
    }
}