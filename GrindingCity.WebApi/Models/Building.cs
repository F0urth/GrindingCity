using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace GrindingCity.WebApi.Models
{
    public class Building
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public BuildingType Type { get; set; }
    }
}
