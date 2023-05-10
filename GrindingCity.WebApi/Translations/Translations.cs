using Riok.Mapperly.Abstractions;
using GrindingCity.WebApi.DTOs;

namespace GrindingCity.WebApi.Translations
{
    [Mapper]
    internal static partial class Translations
    {
        public static partial GetResourcesResponse Map(this Models.Resource resource);
    }
}
