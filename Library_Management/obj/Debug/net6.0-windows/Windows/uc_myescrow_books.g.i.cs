﻿#pragma checksum "..\..\..\..\Windows\uc_myescrow_books.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3A1945727061490A3B37D438BD188EDE2A5FB20B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Bu kod araç tarafından oluşturuldu.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
//     kod yeniden oluşturulursa kaybolur.
// </auto-generated>
//------------------------------------------------------------------------------

using Library_Management.Windows;
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


namespace Library_Management.Windows {
    
    
    /// <summary>
    /// uc_myescrow_books
    /// </summary>
    public partial class uc_myescrow_books : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Windows\uc_myescrow_books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrd_duedatebook1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Windows\uc_myescrow_books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ısbn_txtbx;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Windows\uc_myescrow_books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox escrowdate_txtbx;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Windows\uc_myescrow_books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox booktitle_txtbx1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Windows\uc_myescrow_books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox author_txtbx;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Windows\uc_myescrow_books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox duedate_txtbx;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Windows\uc_myescrow_books.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label total_lbl;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Library_Management;component/windows/uc_myescrow_books.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\uc_myescrow_books.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\Windows\uc_myescrow_books.xaml"
            ((Library_Management.Windows.uc_myescrow_books)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.datagrd_duedatebook1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\..\..\Windows\uc_myescrow_books.xaml"
            this.datagrd_duedatebook1.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.datagrd_duedatebook_MouseUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ısbn_txtbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.escrowdate_txtbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.booktitle_txtbx1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.author_txtbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.duedate_txtbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.total_lbl = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

