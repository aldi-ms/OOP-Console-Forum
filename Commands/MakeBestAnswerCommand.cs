using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            int bestAnswerId = int.Parse(this.Data[1]);

            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            if (bestAnswerId > this.Forum.CurrentQuestion.Answers.Count)
            {
                throw new CommandException(Messages.NoAnswer);
            }

            IAnswer bestAnswer = this.Forum.CurrentQuestion.Answers[bestAnswerId - 1];

            if (this.Forum.CurrentUser != this.Forum.CurrentQuestion.Author)
            {
                throw new CommandException(Messages.NoPermission);
            }

            for (int i = 0; i < this.Forum.CurrentQuestion.Answers.Count; i++)
            {
                if (this.Forum.CurrentQuestion.Answers[i] is BestAnswer)
                {
                    this.Forum.CurrentQuestion.Answers[i] =
                        new Answer(this.Forum.CurrentQuestion.Answers[i]);
                }
            }

            this.Forum.CurrentQuestion.Answers[bestAnswerId - 1] = new BestAnswer(bestAnswer);

            this.Forum.Output.AppendLine(
                string.Format(Messages.BestAnswerSuccess, bestAnswerId)
                );
        }
    }
}
