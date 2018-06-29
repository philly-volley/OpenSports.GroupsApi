namespace OpenSports.GroupsApi.Controllers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using OpenSports.GroupsApi.Commands;
    using OpenSports.GroupsApi.Constants;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Route("{group}/[controller]")]
    [ApiVersion("1.0")]
    public class EventsController : ControllerBase
    {
        private readonly Lazy<IGetEventCommand> getEventCommand;
        private readonly Lazy<IGetEventsCommand> getEventsCommand;

        public EventsController(
            Lazy<IGetEventCommand> getEventCommand,
            Lazy<IGetEventsCommand> getEventsCommand)
        {
            this.getEventCommand = getEventCommand;
            this.getEventsCommand = getEventsCommand;
        }

        /// <summary>
        /// Gets the list of events for the specified group.
        /// </summary>
        /// <param name="group">The group ID.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel the HTTP request.</param>
        /// <returns>A 200 OK response containing the event or a 404 Not Found if a event with the specified ID was not
        /// found.</returns>
        /// <response code="200">The event with the specified ID.</response>
        /// <response code="304">The event has not changed since the date given in the If-Modified-Since HTTP header.</response>
        /// <response code="404">A event with the specified ID could not be found.</response>
        [HttpGet(Name = EventsControllerRoute.GetEvents)]
        [HttpHead]
        [ProducesResponseType(typeof(IList<Event>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status304NotModified)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public Task<IActionResult> Get([FromRoute] string group, CancellationToken cancellationToken) =>
            this.getEventsCommand.Value.ExecuteAsync(group);

        /// <summary>
        /// Gets the event with the specified ID.
        /// </summary>
        /// <param name="group">The group ID.</param>
        /// <param name="eventId">The event ID.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel the HTTP request.</param>
        /// <returns>A 200 OK response containing the event or a 404 Not Found if a event with the specified ID was not
        /// found.</returns>
        /// <response code="200">The event with the specified ID.</response>
        /// <response code="304">The event has not changed since the date given in the If-Modified-Since HTTP header.</response>
        /// <response code="404">A event with the specified ID could not be found.</response>
        [HttpGet("{eventId}", Name = EventsControllerRoute.GetEvent)]
        [HttpHead("{eventId}")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status304NotModified)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public Task<IActionResult> Get([FromRoute] string group, [FromRoute] int eventId, CancellationToken cancellationToken) =>
            this.getEventCommand.Value.ExecuteAsync(group, eventId);
    }
}
