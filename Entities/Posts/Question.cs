using ConsoleForum.Contracts;
using System.Collections.Generic;

namespace ConsoleForum.Entities.Posts
{
    public class Question : Post, IQuestion
    {
        public Question(int id, string title, string body, IUser author)
            : base(id, body, author)
        {
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public string Title { get; set; }

        public IList<IAnswer> Answers { get; private set; }
    }
}
