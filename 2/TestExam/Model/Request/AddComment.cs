namespace Model.Request
{
    public class AddComment
    {
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public string Content { get; set; }
    }
}