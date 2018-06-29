namespace OpenSports.GroupsApi.ViewModels
{
    using System.Collections.Generic;
    using OpenSports.GroupsApi.ViewModelSchemaFilters;
    using Swashbuckle.AspNetCore.SwaggerGen;

    [SwaggerSchemaFilter(typeof(PageResultCarSchemaFilter))]
    public class PageResult<T>
        where T : class
    {
        public int Page { get; set; }

        public int Count { get; set; }

        public bool HasNextPage { get => this.Page < this.TotalPages; }

        public bool HasPreviousPage { get => this.Page > 1; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public List<T> Items { get; set; }
    }
}
