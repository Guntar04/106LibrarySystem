﻿#pragma checksum "..\..\AdminBookDetail.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "14715D0FCE53C6E13CEFDD02CBD5B5D147A9A4E2464412DAE28991F9EB4FA039"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using _106LibrarySystem;


namespace _106LibrarySystem {
    
    
    /// <summary>
    /// AdminBookDetail
    /// </summary>
    public partial class AdminBookDetail : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 89 "..\..\AdminBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image BookImage;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\AdminBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock BookName;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\AdminBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Author;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\AdminBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Availability;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\AdminBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Genre;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\AdminBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Language;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\AdminBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PageNum;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\AdminBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Date;
        
        #line default
        #line hidden
        
        
        #line 189 "..\..\AdminBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Description;
        
        #line default
        #line hidden
        
        
        #line 241 "..\..\AdminBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl AdminBookContent;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/106LibrarySystem;component/adminbookdetail.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminBookDetail.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 31 "..\..\AdminBookDetail.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Home_Admin);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 38 "..\..\AdminBookDetail.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Catalouge_Admin);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 70 "..\..\AdminBookDetail.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Profile_Admin);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BookImage = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.BookName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.Author = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Availability = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.Genre = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.Language = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.PageNum = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.Date = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.Description = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.AdminBookContent = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

