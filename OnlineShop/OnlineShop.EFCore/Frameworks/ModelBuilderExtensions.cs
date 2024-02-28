using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EFCore.Frameworks
{
    public static class ModelBuilderExtensions
    {
        public static void RegisterAllEntities<IDbSetEntity>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var entityTypes = assembly.GetExportedTypes()
                    .Where(type => typeof(IDbSetEntity).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);

                foreach (var entityType in entityTypes)
                {
                    if (entityType.GetInterfaces().Any(i => i == typeof(IDbSetEntity)))
                    {
                        modelBuilder.Entity(entityType);
                    }
                    else
                    {
                        // Handle incorrect implementation of IDbSetEntity interface
                        // You can log the issue or handle it in any appropriate way
                        Console.WriteLine($"Warning: {entityType.Name} does not implement IDbSetEntity correctly.");
                    }
                }
            }
        }
    }
}