using LearnEFCore.Application.Interfaces;

namespace LearnEFCore.Application.Services
{
    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(Query<TResponse> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResponse));
            var handler = _serviceProvider.GetRequiredService(handlerType);
            return await (Task<TResponse>)handlerType.GetMethod("Handle").Invoke(handler, new object[] { query });
        }

        public async Task Send<TCommand>(TCommand command) where TCommand : Command
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            var handler = _serviceProvider.GetRequiredService(handlerType);
            await (Task)handlerType.GetMethod("Handle").Invoke(handler, new object[] { command });
        }

        public async Task<TResponse> Send<TCommand, TResponse>(TCommand command) where TCommand : Command<TResponse>
        {
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResponse));
            var handler = _serviceProvider.GetRequiredService(handlerType);
            return await (Task<TResponse>)handlerType.GetMethod("Handle").Invoke(handler, new object[] { command });
        }
    }

    public interface ICommandHandler<TCommand> where TCommand : Command
    {
        Task Handle(TCommand command);
    }

    public interface ICommandHandler<TCommand, TResponse> where TCommand : Command<TResponse>
    {
        Task<TResponse> Handle(TCommand command);
    }

    public interface IQueryHandler<TQuery, TResponse> where TQuery : Query<TResponse>
    {
        Task<TResponse> Handle(TQuery query);
    }
}