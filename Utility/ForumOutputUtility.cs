using ConsoleForum.Commands;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleForum.Utility
{
    public static class ForumOutputUtility
    {
        public static void QuestionToForum(IForum forum, IQuestion question)
        {
            forum.Output.AppendLine(
                       string.Format(
                       Messages.QuestionPost,
                       question.Id,
                       question.Author.Username,
                       question.Title,
                       question.Body)
                       );

            if (question.Answers.Count == 0)
            {
                forum.Output.AppendLine(Messages.NoAnswers);
            }
            else
            {
                forum.Output.AppendLine("Answers:");

                var bestAnswer = (from a in question.Answers
                                  where a is BestAnswer
                                  select a).FirstOrDefault<IAnswer>();

                if (bestAnswer != default(IEnumerable<IAnswer>))
                {
                    forum.Output.AppendLine(
                        string.Format(
                        Messages.BestAnswerPost,
                        bestAnswer.Id,
                        bestAnswer.Author.Username,
                        bestAnswer.Body)
                        );
                }

                foreach (IAnswer answer in question.Answers)
                {
                    if (bestAnswer == null)
                    {
                        forum.Output.AppendLine(
                            string.Format(
                            Messages.AnswerPost,
                            answer.Id,
                            answer.Author.Username,
                            answer.Body)
                            );
                    }
                    else if (answer.Id != bestAnswer.Id)
                    {
                        forum.Output.AppendLine(
                            string.Format(
                            Messages.AnswerPost,
                            answer.Id,
                            answer.Author.Username,
                            answer.Body)
                            );
                    }
                }
            }
        }
    }
}
