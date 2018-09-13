using System.Collections.Generic;
using System.Net;
using XFPostsViewer.Data;
using Newtonsoft.Json;
using System.Linq;

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
                string postsJson = webClient.DownloadString("https://jsonplaceholder.typicode.com/posts");

                if (!string.IsNullOrEmpty(postsJson))
                {
                    posts = JsonConvert.DeserializeObject<Post[]>(postsJson).ToList();
                }
            }
            return posts;
        }

        public List<Comment> GetCommentsByPost(int postId)
        {
            List<Comment> comments = new List<Comment>();

            using (WebClient webClient = new WebClient())
            {

                string commentsJson = webClient.DownloadString("https://jsonplaceholder.typicode.com/posts/" + postId);

                if (!string.IsNullOrEmpty(commentsJson))
                {
                    comments = JsonConvert.DeserializeObject<Comment[]>(commentsJson).ToList();
                }
            }
            return comments;
        }

        public User GetUserByPost(int userId)
        {
            User user = new User();

            using (WebClient webClient = new WebClient())
            {
                string userJson = webClient.DownloadString("https://jsonplaceholder.typicode.com/posts/" + userId + "/comments");

                if (!string.IsNullOrEmpty(userJson))
                {
                    user = JsonConvert.DeserializeObject<User>(userJson);
                }
            }

            return user;
        }
    }
}
