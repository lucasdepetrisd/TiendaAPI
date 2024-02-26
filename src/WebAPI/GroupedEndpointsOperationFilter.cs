using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class GroupedEndpointsOperationFilter : IOperationFilter
{
    private readonly string _groupName;

    public GroupedEndpointsOperationFilter(string groupName)
    {
        _groupName = groupName;
    }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Add a tag to group endpoints
        operation.Tags ??= new List<OpenApiTag>();
        operation.Tags.Add(new OpenApiTag { Name = _groupName });
    }
}
