using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFPostsViewer.Data;
using XFPostsViewer.Service;
using System.Net;

namespace XFPostsViewer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorProfilePage : ContentPage
    {
        DataRetriever _dataRetriever;

        public AuthorProfilePage()
        {
            InitializeComponent();
        }

        public AuthorProfilePage(int? authorId) : this()
        {
            Title = "Author " + authorId + "'s Profile";
            _dataRetriever = new DataRetriever();
            LoadUser(authorId);
        }

        private async void LoadUser(int? authorId)
        {
            try
            {
                User user = await _dataRetriever.GetUserByPostAsync(authorId);
                BindingContext = user;

            }
            catch (WebException)
            {
                await DisplayAlert("Not Connected", "You are not connected to the Internet. Please Connect, Go back and Try Again!", "OK");
            }
        }
    }
}