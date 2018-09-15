using System.Collections.Generic;
using System.Net;
using XFPostsViewer.Data;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace XFPostsViewer.Service
{
    public class DataRetriever
    {
        public DataRetriever()
        {

        }

        public List<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    string postsJson = webClient.DownloadString("https://jsonplaceholder.typicode.com/posts");

                    if (!string.IsNullOrEmpty(postsJson))
                    {
                        posts = JsonConvert.DeserializeObject<Post[]>(postsJson).ToList();
                    }
                }
                catch (WebException)
                {
                    throw;
                }
            }
            return posts;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            var asyncTask = Task.Run(() => GetPosts());
            List<Post> result = await asyncTask;
            return result;
        }

        public List<Comment> GetCommentsByPost(int? postId)
        {
            List<Comment> comments = new List<Comment>();

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    string commentsJson = webClient.DownloadString("https://jsonplaceholder.typicode.com/posts/" + postId + "/comments");

                    if (!string.IsNullOrEmpty(commentsJson))
                    {
                        comments = JsonConvert.DeserializeObject<Comment[]>(commentsJson).ToList();
                    }
                }
                catch (WebException)
                {
                    throw;
                }
            }
            return comments;
        }

        public async Task<List<Comment>> GetCommentsByPostAsync(int? postId)
        {
            var asyncTask = Task.Run(() => GetCommentsByPost(postId));
            List<Comment> result = await asyncTask;
            return result;
        }

        public User GetUserByPost(int? userId)
        {
            User user = new User();

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    string userJson = webClient.DownloadString("https://jsonplaceholder.typicode.com/users/" + userId);

                    if (!string.IsNullOrEmpty(userJson))
                    {
                        user = JsonConvert.DeserializeObject<User>(userJson);
                    }
                }
                catch (WebException)
                {
                    throw;
                }
            }

            return user;
        }

        public async Task<User> GetUserByPostAsync(int? userId)
        {
            var asyncTask = Task.Run(() => GetUserByPost(userId));
            User result = await asyncTask;
            return result;
        }
    }
}
