using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFPostsViewer.Data;
using XFPostsViewer.Service;

namespace XFPostsViewer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentsListPage : ContentPage
    {
        public ObservableCollection<Comment> CommentsList { get; }

        DataRetriever _dataRetriever;
        Post _postContext;

        public CommentsListPage()
        {
            InitializeComponent();

            CommentsLoaderIndicator.IsRunning = true;
            CommentsLoaderIndicator.IsVisible = true;

        }

        public CommentsListPage(Post post) : this()
        {
            BindingContext = post;
            _postContext = BindingContext as Post;

            Title = "Comments";

            CommentsList = new ObservableCollection<Comment>();
            _dataRetriever = new DataRetriever();
            CommentsListView.ItemsSource = CommentsList;

            if (CommentsList.Count <= 0)
            {
                LoadComments();
            }

            CommentsListView.ItemSelected += CommentsListView_ItemSelected;
        }

        private async void LoadComments()
        {
            CommentsList.Clear();

            List<Comment> comments = await _dataRetriever.GetCommentsByPostAsync(_postContext.PostId);
            foreach (Comment comment in comments)
            {
                CommentsList.Add(comment);

                if (CommentsList.Count > 0)
                {
                    CommentsLoaderIndicator.IsVisible = false;
                    CommentsLoaderIndicator.IsRunning = false;
                }
            }
        }

        private void CommentsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Comment comment = e.SelectedItem as Comment;
                string mailto = "mailto:" + comment.Email;

                Device.OpenUri(new Uri(mailto));
            }

            CommentsListView.SelectedItem = null;
        }
    }
}