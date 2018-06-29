namespace OpenSports.GroupsApi.Commands
{
    using OpenSports.GroupsApi.ViewModels;
    using Boxed.AspNetCore;

    public interface IGetCarPageCommand : IAsyncCommand<PageOptions>
    {
    }
}
