using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using XFPostsViewer.Data;
using XFPostsViewer.Service;
using System.Collections.Generic;

namespace XFPostsViewer
{
    public partial class PostsListPage : ContentPage
    {
        public ObservableCollection<Post> PostsList { get; }

        DataRetriever _dataRetriever;

        public PostsListPage()
        {
            InitializeComponent();

            Title = "Posts";

            PostsList = new ObservableCollection<Post>();
            _dataRetriever = new DataRetriever();
            PostsListView.ItemsSource = PostsList;

            LoadPosts();

        }

        private void LoadPosts()
        {
            PostsList.Clear();

            List<Post> posts = _dataRetriever.GetPosts();
            foreach (Post post in posts)
            {
                PostsList.Add(post);
            }
        }
    }
}
