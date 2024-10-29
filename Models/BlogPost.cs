namespace BlogAPI.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublishedDate {get ; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public bool IsPublished { get; set; }
    }
}

