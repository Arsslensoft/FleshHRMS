using DevExpress.Snap;
using DevExpress.XtraGrid;
using DevExpress.XtraPivotGrid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DevExpress.DevAV.Helpers {
    public static class ItemsSourceExtensions {
        public static void SetItemsSource<T>(this GridControl grid, IList<T> itemsSource) where T : class {
            grid.DataSource = itemsSource.ToBindingList();
        }
        public static void SetItemsSource<T>(this PivotGridControl grid, IList<T> itemsSource) where T : class {
            grid.DataSource = itemsSource.ToBindingList();
        }
        public static void SetItemsSource<T>(this SnapControl snapControl, IList<T> itemsSource) where T : class {
            snapControl.DataSource = itemsSource.ToBindingList();
        }
        public static void SetItemsSource<T>(this BindingSource bindingSource, IList<T> itemsSource) where T : class {
            bindingSource.DataSource = itemsSource.ToBindingList();
        }
        public static BindingList<T> ToBindingList<T>(this IList<T> list) where T : class {
            return ObservableCollectionExtensions.ToBindingList((ObservableCollection<T>)list);
        }
    }
}
