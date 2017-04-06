using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ColorsViewer.Views.Properties {

    [GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [DebuggerNonUserCodeAttribute()]
    [CompilerGeneratedAttribute()]
    internal class Resources {

        private static ResourceManager resourceMan;

        private static CultureInfo resourceCulture;

        [SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() { }

        [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
            => resourceMan
            ?? (resourceMan = new ResourceManager("ColorsViewer.Views.Properties.Resources", typeof(Resources).Assembly));

        [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture {
            get => resourceCulture;
            set => resourceCulture = value;
        }
    }
}