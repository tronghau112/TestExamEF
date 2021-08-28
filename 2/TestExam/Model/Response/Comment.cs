namespace Model.Response
{
    public class Comment
    {
        public string Content { get; set; }
        public User User { get; set; }
    }

    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}