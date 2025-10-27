namespace LearnEFCore.Application.Interfaces
{
    public interface IDispatcher
    {
        Task<TResponse> Send<TResponse>(IQuery<TResponse> query);
        Task Send<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResponse> Send<TCommand, TResponse>(TCommand command) where TCommand : ICommand<TResponse>;
    }

    public interface ICommand { }
    public interface ICommand<TResponse> : ICommand { }
    public interface IQuery<TResponse> { }
}