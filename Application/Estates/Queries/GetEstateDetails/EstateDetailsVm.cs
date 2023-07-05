using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.Queries.GetEstateDetails
{
    public class EstateDetailsVm 
    {
        public int Id { get; set; }
        public float Square { get; set; }
    }
}
