using System.ComponentModel.Composition;

namespace FluentJdf.Visualizer {
    [Export(typeof(IShell))]
    public class ShellViewModel : IShell {}
}
