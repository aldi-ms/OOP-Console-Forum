using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;
using System.Text;

namespace ConsoleForum.Commands
{
    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            string title = this.Data[1];
            string body = this.Data[2];

            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            this.Forum.Questions.Add(
                new Question(
                    this.Forum.Questions.Count + 1,
                    title,
                    body,
                    this.Forum.CurrentUser)
                );

            this.Forum.Output.AppendLine(
                string.Format(Messages.PostQuestionSuccess, this.Forum.Questions.Count)
                );
        }
    }
}
