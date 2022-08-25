using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Domain.Models;

namespace Api.Config
{
    public static class EdmModelBuilder
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            //builder.EntitySet<crime>(nameof(crime)).EntityType.HasKey(x => x.id);
            builder.EntitySet<Users>(nameof(Users)).EntityType.HasKey(x => x.UserId);
            return builder.GetEdmModel();
        }
    }
}
