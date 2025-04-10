using System;
using System.Collections.Generic;
using System.Composition.Hosting.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace electric_network_editor.Utils
{

    public class UnityExportDescriptorProvider : ExportDescriptorProvider
    {
        private readonly IUnityContainer _unity;

        public UnityExportDescriptorProvider(IUnityContainer unity)
        {
            _unity = unity;
        }

        public override IEnumerable<ExportDescriptorPromise> GetExportDescriptors(
            CompositionContract contract, DependencyAccessor descriptorAccessor)
        {
            var type = contract.ContractType;
            if (_unity.IsRegistered(type))
            {
                return new[]
                {
            new ExportDescriptorPromise(
                contract,
                type.FullName,
                true,
                NoDependencies,
                _ => ExportDescriptor.Create((c, o) => _unity.Resolve(type), NoMetadata))
        };
            }

            return Enumerable.Empty<ExportDescriptorPromise>();
        }
    }
    
}
