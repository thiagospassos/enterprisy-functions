using Microsoft.Azure.WebJobs.Host.Config;

namespace AzureFunctions.Autofac
{
    public class InjectExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly InjectBindingProvider bindingProvider;
        public InjectExtensionConfigProvider()
        {
            this.bindingProvider = new InjectBindingProvider();
        }
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<InjectAttribute>().Bind(this.bindingProvider);
        }
    }
}