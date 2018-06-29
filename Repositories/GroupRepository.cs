namespace OpenSports.GroupsApi.Repositories
{
    using Microsoft.Extensions.Caching.Memory;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GroupRepository : IGroupRepository
    {
        private IMemoryCache cache;
        public GroupRepository(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public Task<Event> GetEvent(string group, int eventId, CancellationToken cancellationToken)
        {
            Event @event = GetGroup(group)?.Events.FirstOrDefault(x => x.Id == eventId);
            return Task.FromResult(@event);
        }

        public Task<IList<Event>> GetEvents(string group, CancellationToken cancellationToken)
        {
            IList<Event> events = GetGroup(group)?.Events;
            return Task.FromResult(events);
        }

        public Task<Details> GetDetails(string group, CancellationToken cancellationToken)
        {
            Details details = GetGroup(group)?.Details;
            return Task.FromResult(details);
        }

        private OpenSportsGroup GetGroup(string group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            if (string.IsNullOrWhiteSpace(group))
            {
                throw new ArgumentException("Must provide a group name", nameof(group));
            }

            return cache.GetOrCreate<OpenSportsGroup>(group,
                cacheEntry =>
                {
                    var repo = new OpenSportsGroup(group);
                    if (repo != null)
                    {
                        cacheEntry.SetAbsoluteExpiration(repo.LastUpdated.AddMinutes(10));
                    }
                    return repo;
                });
        }

    }
}
