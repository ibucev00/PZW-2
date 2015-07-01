using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1.Controls
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        public User()
        {
            InitializeComponent();
        }

        private void User_Loaded(object sender, RoutedEventArgs e)
        {
            this.EditImg.MouseDown += EditImg_MouseDown;
            this.DeleteImg.MouseDown += DeleteImg_MouseDown;
        }

        void EditImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseEditEvent();
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs REA = new RoutedEventArgs(User.EventDelete);   
            RaiseEvent(REA);
        }

        void RaiseEditEvent()
        {
            RoutedEventArgs REA = new RoutedEventArgs(User.EventEdit);
            RaiseEvent(REA);
        }


        void DeleteImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseDeleteEvent();
        }

       


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register
            (
            "Title",
            typeof(string),
            typeof(User),
            new PropertyMetadata("Title")
            );



        public static readonly RoutedEvent EventEdit = EventManager.RegisterRoutedEvent
        (
           "Edit",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(User)
        );


        public static readonly RoutedEvent EventDelete = EventManager.RegisterRoutedEvent
        (
           "Delete", 
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(User) 
        );

        public event RoutedEventHandler Delete  
        {
            add { AddHandler(EventDelete, value); } 
            remove { RemoveHandler(EventDelete, value); }
        }


        
        public event RoutedEventHandler Edit 
        {
            add { AddHandler(EventEdit, value); }
            remove { RemoveHandler(EventEdit, value); }
        }
    }
}
