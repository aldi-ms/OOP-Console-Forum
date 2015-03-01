using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public class BestAnswer : Answer
    {
        public BestAnswer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public BestAnswer(IAnswer answer)
            : this(answer.Id, answer.Body, answer.Author)
        {
        }
    }
}
