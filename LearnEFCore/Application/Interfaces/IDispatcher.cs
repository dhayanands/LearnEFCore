namespace LearnEFCore.Application.Interfaces
{
    /// <summary>
    /// Defines a dispatcher for sending queries and commands to their respective handlers in a CQRS pattern.
    /// This interface acts as a mediator, decoupling controllers from business logic handlers.
    /// </summary>
    public interface IDispatcher
    {
        /// <summary>
        /// Sends a query to its handler and returns the response.
        /// Queries are read-only operations that fetch data.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response returned by the query handler.</typeparam>
        /// <param name="query">The query to send, which must implement IQuery&lt;TResponse&gt;.</param>
        /// <returns>A task representing the asynchronous operation, with the response from the handler.</returns>
        Task<TResponse> Send<TResponse>(IQuery<TResponse> query);

        /// <summary>
        /// Sends a command to its handler. Commands are write operations that change state and do not return data.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command, which must implement ICommand.</typeparam>
        /// <param name="command">The command to send.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Send<TCommand>(TCommand command) where TCommand : ICommand;

        /// <summary>
        /// Sends a command to its handler and returns the response.
        /// Commands are write operations that change state and may return data (e.g., an ID).
        /// </summary>
        /// <typeparam name="TCommand">The type of the command, which must implement ICommand&lt;TResponse&gt;.</typeparam>
        /// <typeparam name="TResponse">The type of the response returned by the command handler.</typeparam>
        /// <param name="command">The command to send.</param>
        /// <returns>A task representing the asynchronous operation, with the response from the handler.</returns>
        Task<TResponse> Send<TCommand, TResponse>(TCommand command) where TCommand : ICommand<TResponse>;
    }

    /// <summary>
    /// Marker interface for commands that do not return a response.
    /// Implement this for write operations like creating or updating data.
    /// </summary>
    public interface ICommand { }

    /// <summary>
    /// Marker interface for commands that return a response.
    /// Implement this for write operations that need to return data (e.g., the ID of a created entity).
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public interface ICommand<TResponse> : ICommand { }

    /// <summary>
    /// Marker interface for queries that return a response.
    /// Implement this for read-only operations that fetch data.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public interface IQuery<TResponse> { }
}