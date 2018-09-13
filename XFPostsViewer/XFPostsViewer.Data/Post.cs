using Newtonsoft.Json;

namespace XFPostsViewer.Data
{
    public class Post
    {
        [JsonProperty(PropertyName = "userId")]
        public int? UserId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int? PostId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }
    }
}
