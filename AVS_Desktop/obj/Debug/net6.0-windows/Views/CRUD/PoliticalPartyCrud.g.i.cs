﻿#pragma checksum "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E57B9FE36724A72B38363A5AC0C239BD467874C5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AVS_Desktop.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AVS_Desktop.Views {
    
    
    /// <summary>
    /// PoliticalPartyCrud
    /// </summary>
    public partial class PoliticalPartyCrud : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PartiesGrid;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox search;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createBT;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateBT;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteBT;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button refresh;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AVS_Desktop;component/views/crud/politicalpartycrud.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PartiesGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 11 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
            this.PartiesGrid.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.PartiesGrid_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.search = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
            this.search.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.search_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.createBT = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
            this.createBT.Click += new System.Windows.RoutedEventHandler(this.createBT_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.updateBT = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
            this.updateBT.Click += new System.Windows.RoutedEventHandler(this.updateBT_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.deleteBT = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
            this.deleteBT.Click += new System.Windows.RoutedEventHandler(this.deleteBT_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.refresh = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\..\Views\CRUD\PoliticalPartyCrud.xaml"
            this.refresh.Click += new System.Windows.RoutedEventHandler(this.refresh_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

