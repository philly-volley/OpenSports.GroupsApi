namespace OpenSports.GroupsApi.Repositories
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IGroupRepository
    {
        Task<Event> GetEvent(string group, int eventId, CancellationToken cancellationToken);
        Task<IList<Event>> GetEvents(string group, CancellationToken cancellationToken);
        Task<Details> GetDetails(string group, CancellationToken cancellationToken);
    }
}
