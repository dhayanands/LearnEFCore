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
        /// <param name="query">The query to send, which must inherit from Query&lt;TResponse&gt;.</param>
        /// <returns>A task representing the asynchronous operation, with the response from the handler.</returns>
        Task<TResponse> Send<TResponse>(Query<TResponse> query);

        /// <summary>
        /// Sends a command to its handler. Commands are write operations that change state and do not return data.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command, which must inherit from Command.</typeparam>
        /// <param name="command">The command to send.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Send<TCommand>(TCommand command) where TCommand : Command;

        /// <summary>
        /// Sends a command to its handler and returns the response.
        /// Commands are write operations that change state and may return data (e.g., an ID).
        /// </summary>
        /// <typeparam name="TCommand">The type of the command, which must inherit from Command&lt;TResponse&gt;.</typeparam>
        /// <typeparam name="TResponse">The type of the response returned by the command handler.</typeparam>
        /// <param name="command">The command to send.</param>
        /// <returns>A task representing the asynchronous operation, with the response from the handler.</returns>
        Task<TResponse> Send<TCommand, TResponse>(TCommand command) where TCommand : Command<TResponse>;
    }

    /// <summary>
    /// Base class for commands that do not return a response.
    /// Inherit from this for write operations like creating or updating data.
    /// </summary>
    public abstract class Command { }

    /// <summary>
    /// Base class for commands that return a response.
    /// Inherit from this for write operations that need to return data (e.g., the ID of a created entity).
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public abstract class Command<TResponse> : Command { }

    /// <summary>
    /// Base class for queries that return a response.
    /// Inherit from this for read-only operations that fetch data.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public abstract class Query<TResponse> { }
}