using PluginContracts;
using System;
using System.Collections.Generic;
using System.Composition.Hosting.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace electric_network_editor
{
    internal class CanvasExportProvider : ExportDescriptorProvider
    {
        private readonly CanvasWrapper _canvas;

        public CanvasExportProvider(CanvasWrapper canvas)
        {
            _canvas = canvas;
        }

        public override IEnumerable<ExportDescriptorPromise> GetExportDescriptors(
            CompositionContract contract, DependencyAccessor descriptorAccessor)
        {
            if (contract.ContractType == typeof(CanvasWrapper))
            {
                yield return new ExportDescriptorPromise(
                    contract,
                    "Canvas Export",
                    true, // No dependencies
                    () => Array.Empty<CompositionDependency>(),
                    dependencies =>
                    {
                        return ExportDescriptor.Create((c, o) => _canvas, new Dictionary<string, object>());
                    });
            }
        }
    }
}
