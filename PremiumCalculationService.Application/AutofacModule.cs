using Autofac;
using PremiumCalculationService.Common;

namespace PremiumCalculationService.Application
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMatchingTypeAsImplementedInterfaces(typeof(AutofacModule).Assembly,
                new[] { ".+Command$", ".+Query$", ".+Service$" });
        }
    }
}
