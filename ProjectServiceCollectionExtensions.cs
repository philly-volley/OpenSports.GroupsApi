namespace OpenSports.GroupsApi
{
    using System;
    using OpenSports.GroupsApi.Commands;
    using OpenSports.GroupsApi.Mappers;
    using OpenSports.GroupsApi.Repositories;
    using OpenSports.GroupsApi.Services;
    using OpenSports.GroupsApi.ViewModels;
    using Boxed.Mapping;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods add project services.
    /// </summary>
    /// <remarks>
    /// AddSingleton - Only one instance is ever created and returned.
    /// AddScoped - A new instance is created and returned for each request/response cycle.
    /// AddTransient - A new instance is created and returned each time.
    /// </remarks>
    public static class ProjectServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectCommands(this IServiceCollection services) =>
            services
                .AddSingleton<IDeleteCarCommand, DeleteCarCommand>()
                .AddSingleton(x => new Lazy<IDeleteCarCommand>(() => x.GetRequiredService<IDeleteCarCommand>()))
                .AddSingleton<IGetCarCommand, GetCarCommand>()
                .AddSingleton(x => new Lazy<IGetCarCommand>(() => x.GetRequiredService<IGetCarCommand>()))
                .AddSingleton<IGetCarPageCommand, GetCarPageCommand>()
                .AddSingleton(x => new Lazy<IGetCarPageCommand>(() => x.GetRequiredService<IGetCarPageCommand>()))
                .AddSingleton<IPatchCarCommand, PatchCarCommand>()
                .AddSingleton(x => new Lazy<IPatchCarCommand>(() => x.GetRequiredService<IPatchCarCommand>()))
                .AddSingleton<IPostCarCommand, PostCarCommand>()
                .AddSingleton(x => new Lazy<IPostCarCommand>(() => x.GetRequiredService<IPostCarCommand>()))
                .AddSingleton<IPutCarCommand, PutCarCommand>()
                .AddSingleton(x => new Lazy<IPutCarCommand>(() => x.GetRequiredService<IPutCarCommand>()))
                .AddSingleton<IGetEventCommand, GetEventCommand>()
                .AddSingleton(x => new Lazy<IGetEventCommand>(() => x.GetRequiredService<IGetEventCommand>()))
                .AddSingleton<IGetEventsCommand, GetEventsCommand>()
                .AddSingleton(x => new Lazy<IGetEventsCommand>(() => x.GetRequiredService<IGetEventsCommand>()))
                .AddSingleton<IGetDetailsCommand, GetDetailsCommand>()
                .AddSingleton(x => new Lazy<IGetDetailsCommand>(() => x.GetRequiredService<IGetDetailsCommand>()));

        public static IServiceCollection AddProjectMappers(this IServiceCollection services) =>
            services
                .AddSingleton<IMapper<Models.Car, Car>, CarToCarMapper>()
                .AddSingleton<IMapper<Models.Car, SaveCar>, CarToSaveCarMapper>()
                .AddSingleton<IMapper<SaveCar, Models.Car>, CarToSaveCarMapper>();

        public static IServiceCollection AddProjectRepositories(this IServiceCollection services) =>
            services
                .AddSingleton<ICarRepository, CarRepository>()
                .AddSingleton<IGroupRepository, GroupRepository>();

        public static IServiceCollection AddProjectServices(this IServiceCollection services) =>
            services
                .AddSingleton<IClockService, ClockService>();
    }
}
