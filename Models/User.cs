using System.ComponentModel.DataAnnotations;

namespace Reddit.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual List<Post> Posts { get; set; } = new List<Post>();
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
        public virtual List<Community>? OwnedCommunities { get; set; }
        public virtual List<Community> SubscribedCommunities { get; set; } = new List<Community>();
    }
}
