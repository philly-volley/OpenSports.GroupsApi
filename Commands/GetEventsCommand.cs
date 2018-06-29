namespace OpenSports.GroupsApi.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using OpenSports.GroupsApi.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class GetEventsCommand : IGetEventsCommand
    {
        private readonly IGroupRepository eventsRepository;

        public GetEventsCommand(IGroupRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public async Task<IActionResult> ExecuteAsync(string group, CancellationToken cancellationToken)
        {
            IList<Event> events = await this.eventsRepository.GetEvents(group, cancellationToken);
            if (events == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(events);
        }
    }
}
