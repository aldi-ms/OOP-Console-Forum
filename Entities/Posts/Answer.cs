using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public class Answer : Post, IAnswer
    {
        public Answer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public Answer(IAnswer answer)
            : this(answer.Id, answer.Body, answer.Author)
        {

        }
    }
}
