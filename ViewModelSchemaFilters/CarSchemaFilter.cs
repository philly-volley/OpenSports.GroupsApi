namespace OpenSports.GroupsApi.ViewModelSchemaFilters
{
    using OpenSports.GroupsApi.ViewModels;
    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public class CarSchemaFilter : ISchemaFilter
    {
        public void Apply(Schema model, SchemaFilterContext context)
        {
            var car = new Car()
            {
                CarId = 1,
                Cylinders = 6,
                Make = "Honda",
                Model = "Civic"
            };
            model.Default = car;
            model.Example = car;
        }
    }
}
