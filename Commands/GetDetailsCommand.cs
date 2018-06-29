namespace OpenSports.GroupsApi.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using OpenSports.GroupsApi.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class GetDetailsCommand : IGetDetailsCommand
    {
        private readonly IGroupRepository detailsRepository;

        public GetDetailsCommand(IGroupRepository detailsRepository)
        {
            this.detailsRepository = detailsRepository;
        }

        public async Task<IActionResult> ExecuteAsync(string group, CancellationToken cancellationToken)
        {
            Details details = await this.detailsRepository.GetDetails(group, cancellationToken);
            if (details == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(details);
        }
    }
}
