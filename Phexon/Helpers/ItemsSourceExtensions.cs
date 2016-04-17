﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;
using DevExpress.Snap;
using DevExpress.XtraGrid;
using DevExpress.XtraPivotGrid;

namespace PHRMS.Helpers
{
    public static class ItemsSourceExtensions
    {
        public static void SetItemsSource<T>(this GridControl grid, IList<T> itemsSource) where T : class
        {
            grid.DataSource = itemsSource.ToBindingList();
        }

        public static void SetItemsSource<T>(this PivotGridControl grid, IList<T> itemsSource) where T : class
        {
            grid.DataSource = itemsSource.ToBindingList();
        }

        public static void SetItemsSource<T>(this SnapControl snapControl, IList<T> itemsSource) where T : class
        {
            snapControl.DataSource = itemsSource.ToBindingList();
        }

        public static void SetItemsSource<T>(this BindingSource bindingSource, IList<T> itemsSource) where T : class
        {
            bindingSource.DataSource = itemsSource.ToBindingList();
        }

        public static BindingList<T> ToBindingList<T>(this IList<T> list) where T : class
        {
            return ObservableCollectionExtensions.ToBindingList((ObservableCollection<T>) list);
        }
    }
}