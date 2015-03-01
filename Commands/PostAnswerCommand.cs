using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            string body = this.Data[1];

            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            this.Forum.CurrentQuestion.Answers.Add(
                new Answer(
                    this.Forum.CurrentQuestion.Answers.Count + 1, 
                    body, 
                    this.Forum.CurrentUser)
                );

            this.Forum.Output.AppendLine(
                string.Format(Messages.PostAnswerSuccess, this.Forum.CurrentQuestion.Answers.Count)
                );
        }
    }
}
