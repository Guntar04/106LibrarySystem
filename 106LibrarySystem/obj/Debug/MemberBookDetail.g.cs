﻿#pragma checksum "..\..\MemberBookDetail.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F39010D596FE651CB5D3000C35E8FADCE2295A1DCD1933E7679EF6EB60428ADF"
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
    /// MemberBookDetail
    /// </summary>
    public partial class MemberBookDetail : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 87 "..\..\MemberBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image BookImage;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\MemberBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock BookName;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\MemberBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Author;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\MemberBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Availability;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\MemberBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Genre;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\MemberBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Language;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\MemberBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PageNum;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\MemberBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Date;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\MemberBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Borrow;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\MemberBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Pre_Book;
        
        #line default
        #line hidden
        
        
        #line 206 "..\..\MemberBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Description;
        
        #line default
        #line hidden
        
        
        #line 258 "..\..\MemberBookDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl BookDetails;
        
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
            System.Uri resourceLocater = new System.Uri("/106LibrarySystem;component/memberbookdetail.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MemberBookDetail.xaml"
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
            
            #line 31 "..\..\MemberBookDetail.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Home_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 38 "..\..\MemberBookDetail.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Catalogue_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BookImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.BookName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Author = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.Availability = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Genre = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.Language = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.PageNum = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.Date = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.Borrow = ((System.Windows.Controls.Button)(target));
            
            #line 138 "..\..\MemberBookDetail.xaml"
            this.Borrow.Click += new System.Windows.RoutedEventHandler(this.Borrow_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Pre_Book = ((System.Windows.Controls.Button)(target));
            
            #line 146 "..\..\MemberBookDetail.xaml"
            this.Pre_Book.Click += new System.Windows.RoutedEventHandler(this.Pre_Book_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Description = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.BookDetails = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

