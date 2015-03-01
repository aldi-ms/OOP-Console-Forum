using ConsoleForum.Contracts;
using ConsoleForum.Utility;

namespace ConsoleForum.Commands
{
    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            int questionId = int.Parse(this.Data[1]);

            if (questionId > this.Forum.Questions.Count)
            {
                throw new CommandException(Messages.NoQuestion);
            }

            this.Forum.CurrentQuestion = this.Forum.Questions[questionId - 1];

            ForumOutputUtility.QuestionToForum(this.Forum, this.Forum.CurrentQuestion);
        }
    }
}
