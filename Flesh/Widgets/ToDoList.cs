using System;
using System.Collections.Generic;
using FHRMS.Data;

using FHRMS.ViewModels;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using FHRMS.Common.Utils;
using DevExpress.Mvvm;
using FHRMS.Modules;
using System.Windows.Forms;
using FHRMS.Helpers;
namespace FHRMS.Widgets
{
    interface IDashboardWidget
    {
        Dashboard Dashboard { set; }
    }

    public partial class ToDoList : UserControl, IDashboardWidget
    {
        public Dashboard Dashboard
        { 
            set {
           
                gridControl1.SetItemsSource(value.ViewModel.Entities);
            }
        
        }
  
        public ToDoList()
        {
            InitializeComponent();
     
    
        }
    }
}
