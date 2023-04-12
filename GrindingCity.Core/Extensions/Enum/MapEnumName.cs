using GrindingCity.Domain.Entities.Resource.Enums;
using GrindingCity.Domain.Entities.Resources.Enums;

namespace GrindingCity.Core.Extensions.Enum
{
    public static class MapEnumName
    {
        private static readonly Dictionary<string, RawResourcesNames> RawResources = new Dictionary<string, RawResourcesNames>
        {
            { "Wheat", RawResourcesNames.Wheat },
            { "Wood", RawResourcesNames.Wood }
        };

        private static readonly Dictionary<string, EndResourceNames> EndResources = new Dictionary<string, EndResourceNames>
        {
            { "Beer", EndResourceNames.Beer }
        };

        public static RawResourcesNames MapRawEnumName(string name)
        {
            RawResources.TryGetValue(name, out RawResourcesNames result);

            return result;
        }

        public static EndResourceNames MapEndEnumName(string name)
        {
            EndResources.TryGetValue(name, out EndResourceNames result);

            return result;
        }
    }
}
