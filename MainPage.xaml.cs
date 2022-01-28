using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Text.RegularExpressions;

namespace WebVApp
{
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Bookmark> Bookmarks { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            Bookmarks = new ObservableCollection<Bookmark>();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";
            if (Regex.IsMatch(textBox.Text, pattern))
            {
                Uri uri = new Uri(textBox.Text);
                webView.Navigate(uri);
            }
        }

        private void bookmarksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Bookmark bookmarksel = bookmarksList.SelectedItem as Bookmark;
            if (bookmarksel != null)
            {
                textBox.Text = bookmarksel.Url;
            }
        }

        private void Bookmarks_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string url = textBox.Text;
            Bookmarks.Add(new Bookmark { Url = url });
            textBox.Text = String.Empty;
        }
    }
}
