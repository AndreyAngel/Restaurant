using MediatR;

namespace Restaurant.Auth.UseCases.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<Guid>
    {
        public UserModel Model { get; }

        public AddUserCommand(UserModel model)
        {
            Model = model;
        }
    }
}
