using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.Queries.GetEstateList
{
    public class EstateLookupDto
    {
        public int Id { get; set; }
        public float Square { get; set; }
    }
}
