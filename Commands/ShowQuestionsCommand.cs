using ConsoleForum.Contracts;
using ConsoleForum.Entities;
using ConsoleForum.Entities.Posts;
using System.Linq;

namespace ConsoleForum.Commands
{
    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.Questions.Count == 0)
            {
                this.Forum.Output.AppendLine(Messages.NoQuestions);
            }
            else
            {
                this.Forum.CurrentQuestion = null;

                foreach (IQuestion question in this.Forum.Questions)
                {
                    Utility.ForumOutputUtility.QuestionToForum(this.Forum, question);
                }

                //foreach (IQuestion question in this.Forum.Questions)
                //{
                //    this.Forum.Output.AppendLine(
                //        string.Format(
                //        Messages.QuestionPost,
                //        question.Id,
                //        question.Author.Username,
                //        question.Title,
                //        question.Body)
                //        );

                //    var bestAnswer = (from a in question.Answers
                //                     where a is BestAnswer
                //                     select a).First<IAnswer>();

                //    if (bestAnswer != null)
                //    {
                //        this.Forum.Output.AppendLine(
                //            string.Format(
                //            Messages.BestAnswerPost,
                //            bestAnswer.Id,
                //            bestAnswer.Author,
                //            bestAnswer.Body)
                //            );
                //    }

                //    foreach (IAnswer answer in question.Answers)
                //    {
                //        if (bestAnswer != null && answer.Id != bestAnswer.Id)
                //        {
                //            this.Forum.Output.AppendLine(
                //                string.Format(
                //                Messages.AnswerPost,
                //                bestAnswer.Id,
                //                bestAnswer.Author,
                //                bestAnswer.Body)
                //                );
                //        }
                //        else if (bestAnswer == null)
                //        {
                //            this.Forum.Output.AppendLine(
                //                string.Format(
                //                Messages.AnswerPost,
                //                bestAnswer.Id,
                //                bestAnswer.Author,
                //                bestAnswer.Body)
                //                );
                //        }
                //    }

                //    if (question.Answers.Count == 0)
                //    {
                //        this.Forum.Output.AppendLine(Messages.NoAnswer);
                //    }
            }
        }
    }
}
