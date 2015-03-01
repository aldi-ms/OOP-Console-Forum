using ConsoleForum.Contracts;
using ConsoleForum.Utility;
using System.Linq;

namespace ConsoleForum.Commands
{
    public class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            if (this.Forum.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            var user = from a in users
                       where a.Username == username && a.Password == password
                       select a;

            if (user.Count<IUser>() == 1)
            {
                this.Forum.CurrentUser = user.First<IUser>();

                this.Forum.Output.AppendLine(
                    string.Format(Messages.LoginSuccess, username)
                );
            }
            else
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }
        }

    }
}
