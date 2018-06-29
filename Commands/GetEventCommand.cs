namespace OpenSports.GroupsApi.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using OpenSports.GroupsApi.Repositories;
    using Boxed.Mapping;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.Extensions.Primitives;
    using Microsoft.Net.Http.Headers;

    public class GetEventCommand : IGetEventCommand
    {
        private readonly IGroupRepository eventRepository;

        public GetEventCommand(IGroupRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task<IActionResult> ExecuteAsync(string group, int eventId, CancellationToken cancellationToken)
        {
            Event @event = await this.eventRepository.GetEvent(group, eventId, cancellationToken);
            if (@event == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(@event);
        }
    }
}
