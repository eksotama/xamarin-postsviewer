using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFPostsViewer.Data;

namespace XFPostsViewer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentsListPage : ContentPage
    {
        public CommentsListPage()
        {
            InitializeComponent();
        }

        public CommentsListPage(Post post) : this()
        {
            BindingContext = post;
        }

    }
}