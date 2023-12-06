using FloraAPI.Domain.Entities.User;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FloraAPI.Application.Features.UsersFeatures.Commands
{
    public class DeleteUserRequest:IRequest
    { 
        public User User { get; set; }
    }

    public class DeleteUserConsumer :IConsumer<DeleteUserRequest>
    {
        readonly UserManager<User> _userManager;
        private readonly IPublishEndpoint _publishEndpoint;

        public DeleteUserConsumer(UserManager<User> userManager, IPublishEndpoint publishEndpoint)
        {
            _userManager = userManager;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<DeleteUserRequest> context)
        {
            User user = await _userManager.FindByIdAsync(context.Message.User.Id.ToString());
            _userManager.DeleteAsync(user);

            if (user==null)
            {
                throw new Exception($"Customer with id {context.Message.User.Id} not found");
            }

            _userManager.DeleteAsync(user);

            _publishEndpoint.Publish(new { User = context.Message.User });
            //var customer = _repository.GetById(context.Message.CustomerId);

            //if (customer == null)
            //{
            //    throw new Exception($"Customer with id {context.Message.CustomerId} not found");
            //}

            //_repository.Delete(customer);

            //await _publishEndpoint.Publish<CustomerDeletedEvent>(new { CustomerId = context.Message.CustomerId });
        }
    }  

}
