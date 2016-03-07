using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace DevExpress.XtraGrid.Views.Grid {
    public class GridViewWithButtons : GridView {
        private ButtonsPanel buttonsPanel;
        private ButtonsPanelInfo buttonsViewInfo;
        private GridColumn buttonsColumn;
        private ButtonsPanelInfoEventsProvider buttonsEventProvider;
        private bool showButtons = false;
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (buttonsEventProvider != null) {
                    buttonsEventProvider.Dispose();
                }
                buttonsEventProvider = null;
                if (buttonsPanel != null) {
                    buttonsPanel.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public ButtonsPanel ButtonsPanel {
            get {
                if (buttonsPanel == null) {
                    buttonsPanel = new ButtonsPanel();
                }
                return buttonsPanel;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public GridColumn ButtonsColumn {
            get {
                return buttonsColumn;
            }
            set {
                if (ButtonsColumn == value) {
                    return;
                }
                buttonsColumn = value;
                LayoutChangedSynchronized();
            }
        }
        protected ButtonsPanelInfoEventsProvider ButtonsEventProvider {
            get {
                return buttonsEventProvider;
            }
            set {
                if (ButtonsEventProvider == value) {
                    return;
                }
                if (buttonsEventProvider != null) {
                    buttonsEventProvider.Dispose();
                }
                buttonsEventProvider = value;
            }
        }
        protected ButtonsPanelInfo ButtonsViewInfo {
            get {
                if (buttonsViewInfo == null) {
                    buttonsViewInfo = new ButtonsPanelInfo();
                }
                if (buttonsViewInfo.ButtonsInfo.Count != ButtonsPanel.Buttons.Count) {
                    buttonsViewInfo = ButtonsPanel.Init();
                    if (buttonsEventProvider != null) {
                        buttonsEventProvider.Info = buttonsViewInfo;
                    }
                }
                return buttonsViewInfo;
            }
        }
        protected override void OnGridControlChanged(DevExpress.XtraGrid.GridControl prevControl) {
            base.OnGridControlChanged(prevControl);
            if (GridControl != null) {
                ButtonsEventProvider = new ButtonsPanelInfoEventsProvider(ButtonsViewInfo, GridControl);
            }
        }

        public bool ShowButtons {
            get {
                return showButtons;
            }
            set {
                if (ShowButtons == value) {
                    return;
                }
                showButtons = value;
                LayoutChangedSynchronized();
            }
        }
        protected override void RaiseCustomDrawCell(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
            base.RaiseCustomDrawCell(e);
            if (e.Column != null && e.Column == buttonsColumnInternal && e.RowHandle == FocusedRowHandle) {
                e.DefaultDraw();
                DrawButtonsPanel(e);
            }
        }

        private void DrawButtonsPanel(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
            var cell = e.Cell as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo;
            var bounds = cell.Bounds;
            if (cell.CellValueRect.Width > 0) {
                bounds.X = cell.CellValueRect.Right;
            }
            bounds.Width = cell.Bounds.Right - bounds.X;
            if (bounds.Width > 0) {
                ButtonsPanel.SetContext(GetRow(e.RowHandle));
                ButtonsPanel.Prepare(e.Graphics, ButtonsViewInfo, bounds);
                if (ButtonsViewInfo.IsReady) {
                    ButtonsViewInfo.Draw(e.Cache);
                }
            }
        }
        protected GridColumn buttonsColumnInternal = null;
        protected bool GetShowButtons() {
            return ShowButtons && ButtonsPanel.Buttons.Count > 0;
        }
        protected override void RefreshVisibleColumnsList() {
            base.RefreshVisibleColumnsList();
            if (GetShowButtons()) {
                var lastColumn = VisibleColumns.Count > 0 ? VisibleColumns[VisibleColumns.Count - 1] : null;
                buttonsColumnInternal = ButtonsColumn == null ? lastColumn : ButtonsColumn;
                if (ScrollInfo.IsOverlapScrollBar && buttonsColumnInternal != null && buttonsColumnInternal == lastColumn) {
                    ButtonsPanel.Padding = new System.Windows.Forms.Padding(0, 0, ScrollInfo.VScrollSize, 0);
                } else {
                    ButtonsPanel.Padding = new Padding(0, 0, 4, 0);
                }
                var bounds = ButtonsViewInfo.Bounds;
                if (bounds.IsEmpty) {
                    bounds = ViewRect;
                }
                ButtonsPanel.Prepare(null, ButtonsViewInfo, bounds);
            } else {
                buttonsColumn = null;
            }
        }
        protected override System.Windows.Forms.Padding GetRowCellPadding(GridColumn column) {
            if (column != null && column == buttonsColumnInternal) {
                if (buttonsViewInfo.Width > 0) {
                    return new System.Windows.Forms.Padding(0, 0, buttonsViewInfo.Width + 10, 0);
                }
            }
            return base.GetRowCellPadding(column);
        }
    }
}
