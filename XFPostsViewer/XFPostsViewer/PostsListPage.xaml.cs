using Xamarin.Forms;
using System.Collections.ObjectModel;
using XFPostsViewer.Data;
using XFPostsViewer.Service;
using System.Collections.Generic;
using System.Net;

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

            //Connectivity. 
            // using Xamarin.Essentials;

            PostsLoaderIndicator.IsRunning = true;
            PostsLoaderIndicator.IsVisible = true;

            PostsList = new ObservableCollection<Post>();
            _dataRetriever = new DataRetriever();
            PostsListView.ItemsSource = PostsList;

            LoadPosts();

            PostsListView.ItemSelected += PostsListView_ItemSelected;
            PostsListView.RefreshCommand = new Command(() =>
            {
                LoadPosts();
                PostsListView.IsRefreshing = false;
            });
        }

        private async void LoadPosts()
        {
            PostsList.Clear();

            try
            {
                List<Post> posts = await _dataRetriever.GetPostsAsync();
                foreach (Post post in posts)
                {
                    PostsList.Add(post);

                    if (PostsList.Count > 10)
                    {
                        PostsLoaderIndicator.IsVisible = false;
                        PostsLoaderIndicator.IsRunning = false;
                    }
                }
            }
            catch (WebException)
            {
                PostsLoaderIndicator.IsVisible = false;
                PostsLoaderIndicator.IsRunning = false;
                await DisplayAlert("Not Connected", "You are not connected to the Internet. Please Connect and Pull down the page to Refresh", "OK");
            }
        }

        private void PostsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                CommentsListPage commentsPage = new CommentsListPage(e.SelectedItem as Post);
                Navigation.PushAsync(commentsPage);
            }

            PostsListView.SelectedItem = null;
        }
    }
}
