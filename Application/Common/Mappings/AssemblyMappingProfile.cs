using AutoMapper;
using System.Reflection;
using System.Linq;

namespace RealtService.Application.Common.Mappings;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly) =>
        ApplyMappingsFromAssembly(assembly);

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        IEnumerable<Type> types = assembly.GetExportedTypes()
            .Where(type => type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>)));

        foreach (Type type in types)
        {
            object instance = Activator.CreateInstance(type)!;
            MethodInfo methodInfo = type.GetMethod(nameof(IMapWith<object>.Mapping))!;
            methodInfo.Invoke(instance, new object[] { this });
        }
    }
}
