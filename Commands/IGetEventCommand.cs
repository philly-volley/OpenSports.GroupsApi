namespace OpenSports.GroupsApi.Commands
{
    using Boxed.AspNetCore;

    public interface IGetEventCommand : IAsyncCommand<string, int>
    {
    }
}
