using Newtonsoft.Json;

namespace XFPostsViewer.Data
{
    public class Comment
    {
        [JsonProperty(PropertyName = "postId")]
        public int? PostId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int? CommentId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }
    }
}
