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
    /// Interaction logic for Post.xaml
    /// </summary>
    public partial class Post : UserControl
    {
        public Post()
        {
            InitializeComponent();
        }

        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register
        (
          "UserName",
          typeof(string),
          typeof(Post),
          new UIPropertyMetadata("New User")
        );

        public string Tekst
        {
            get { return (string)GetValue(TekstProperty); }
            set { SetValue(TekstProperty, value); }
        }

        public static readonly DependencyProperty TekstProperty = DependencyProperty.Register
        (
          "Tekst",
          typeof(string),
          typeof(Post),
          new UIPropertyMetadata("Unesite tekst:")
        );

        void EditBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RaiseEditEvent();
        }

        private void Post_Loaded(object sender, RoutedEventArgs e)
        {
            this.EditBtn.MouseLeftButtonUp += EditBtn_MouseLeftButtonUp;
        }

        

        private void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.Edit);
            RaiseEvent(newEventArgs);
        }

        public static readonly RoutedEvent Edit = EventManager.RegisterRoutedEvent
        (
           "EditPost", 
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(Post) 
        );

        public event RoutedEventHandler EditPostHandle 
        {
            add { AddHandler(Edit, value); }
            remove { RemoveHandler(Edit, value); }
        }
    }
}
