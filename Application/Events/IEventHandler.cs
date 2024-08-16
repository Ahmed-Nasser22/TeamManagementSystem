namespace Application.Events
{
    public interface IEventHandler<TEvent>
    {
        Task Handle(TEvent eventMessage);
    }
}
