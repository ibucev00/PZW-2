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
using WpfApplication1.Controls;

namespace WpfApplication1
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            for (var i = 0; i < this.RightRectangleContainer.Children.Count; i++) 
            {
                var item = this.RightRectangleContainer.Children[i];
                if (item is Post)
                {
                    var postItem = (Post)item;
                    postItem.userCtrl.Edit += userCtrl_Edit; 
                    postItem.userCtrl.Delete +=userCtrl_Delete; 
                    postItem.EditPostHandle += postItem_EditPostHandle; 
                }
            }

            for (var i = 0; i < this.LeftRectangleContainer.Children.Count; i++) 
            {
                var item = this.LeftRectangleContainer.Children[i];
                if (item is User)
                {
                    var userItem = (User)item;
                    userItem.Edit += userItem_Edit; 
                    userItem.Delete += userItem_Delete; 
                }
            }
        }

        private void leftBttn_Click(object sender, RoutedEventArgs e) 
        {
            this.LeftRectangleContainer.Children.Add(new User()
            {
                Width = 100,
                Height = 100,
                Margin = new Thickness(5)
            });

            var item = this.LeftRectangleContainer.Children[this.LeftRectangleContainer.Children.Count - 1];
            if (item is User)
            {
                var userItem = (User)item;
                userItem.Delete += new RoutedEventHandler(userItem_Delete);
                userItem.Edit += new RoutedEventHandler(userItem_Edit);
            }
        }

        private void rightBttn_Click(object sender, RoutedEventArgs e) 
        {

            this.RightRectangleContainer.Children.Add(new Post()
            {
                Height = 100,
                Margin = new Thickness(10),
                HorizontalAlignment = 0
            });

            var item = this.RightRectangleContainer.Children[this.RightRectangleContainer.Children.Count - 1];
            if (item is Post)
            {
                var postItem = (Post)item;
                postItem.userCtrl.Delete += userCtrl_Delete;
                postItem.userCtrl.Edit += userCtrl_Edit;
                postItem.EditPostHandle += postItem_EditPostHandle;
            }
        }


        void userCtrl_Edit(object sender, RoutedEventArgs e)
        {
            if (!(sender is User)) { return; }
            var userItem = sender as User;
            var imgItem = userItem.Parent as Grid;
            var a = imgItem.Parent as Viewbox;
            var b = a.Parent as Post;

            var indexOfElement = this.RightRectangleContainer.Children.IndexOf(b);
            if (indexOfElement == -1) { return; }

            string editorContent = EditorBox.ShowDialog("Promjenite ime: ", "Editor");
            if (editorContent != "")
                userItem.Title = editorContent;
        }


        void postItem_EditPostHandle(object sender, RoutedEventArgs e)
        {
            if (!(sender is Post)) { return; }
            var postItem = sender as Post;

            var index = this.RightRectangleContainer.Children.IndexOf(postItem);
            if (index == -1) { return; }

            string editorContent = EditorBox.ShowDialog("Uredite objavu: ", "Post editor"); 
            if (editorContent != "") 
                postItem.Tekst = editorContent; 
        }

        

        void userCtrl_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is User)) { return; }
            var mediaItem = sender as User;
            var imgItem = mediaItem.Parent as Grid;
            var itemA = imgItem.Parent as Viewbox;
            var itemB = itemA.Parent as Post;

            var index = this.RightRectangleContainer.Children.IndexOf(itemB);
            if (index == -1) { return; }

            this.RightRectangleContainer.Children.RemoveAt(index);
        }

       



        void userItem_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is User)) { return; }
            var userItem = sender as User;

            var index = this.LeftRectangleContainer.Children.IndexOf(userItem);
            if (index == -1) { return; }

            this.LeftRectangleContainer.Children.RemoveAt(index);
        }

        void userItem_Edit(object sender, RoutedEventArgs e)
        {
            if (!(sender is User)) { return; }
            var userItem = sender as User;

            var index = this.LeftRectangleContainer.Children.IndexOf(userItem);
            if (index == -1) { return; }

            string editorContent = EditorBox.ShowDialog("Promjenite ime korisnika: ", "Editor");
            if (editorContent != "")
                userItem.Title = editorContent;
        }

        private void Post_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

