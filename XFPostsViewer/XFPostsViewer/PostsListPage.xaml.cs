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
            PostsListView.ItemSelected += PostsListView_ItemSelected;
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
       
        private void PostsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                CommentsListPage commentsPage = new CommentsListPage(e.SelectedItem as Post);
                Navigation.PushAsync(commentsPage);
            }

            // Clear selection
            PostsListView.SelectedItem = null;
        }

    }
}
