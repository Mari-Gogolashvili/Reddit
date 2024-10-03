using Reddit.Models;

namespace Reddit.Dtos
{
    public class CommentDto
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public int AuthorId { get; set; }

        public Comment CreateComment() {
            return new Comment() { AuthorId = AuthorId, Content = Content, PostId = PostId };
        }
    }
}
