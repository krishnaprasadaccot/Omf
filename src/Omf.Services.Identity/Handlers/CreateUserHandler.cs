using Omf.Common.Commands;
using Omf.Common.Events;
using Omf.Common.Exceptions;
using Omf.Services.Identity.Domain.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Identity.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private IBusClient _busClient;
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public CreateUserHandler(IBusClient busClient,IUserService userService)
        {
            _busClient = busClient;
            _userService = userService;
        }
        public async Task HandleAsync(CreateUser command)
        {
            Console.WriteLine($"Creating User: {command.Name} {command.Email}");
            try
            {
                await _userService.RegisterAsync(command.Email, command.Password, command.Name);
                await _busClient.PublishAsync(new UserCreated(command.Email,command.Name));
                return;
            }
            catch (OmfException ex)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Email, ex.Code, ex.Message));
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Email, "error", ex.Message));
                Console.WriteLine(ex.Message);
            }
        }
    }
}
