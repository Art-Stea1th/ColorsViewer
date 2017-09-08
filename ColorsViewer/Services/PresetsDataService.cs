using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Reflection;
using System.Xml.Serialization;

namespace ColorsViewer.Services {

    using Models;

    internal sealed class PresetsDataService {

        private static readonly Lazy<PresetsDataService> instance
            = new Lazy<PresetsDataService>(() => new PresetsDataService());

        private readonly IList<ColorPreset> presets;

        public static PresetsDataService Instance => instance.Value;
        public IEnumerable<ColorPreset> Presets => presets;

        private PresetsDataService() {

            var path = "ColorsViewer.Data";
            presets = new List<ColorPreset> {
                ResolvePreset($"{path}.WPColors"),
                ResolvePreset($"{path}.WFColors"),
                ResolvePreset($"{path}.VSColorsDark"),
                ResolvePreset($"{path}.VSColorsBlue"),
                ResolvePreset($"{path}.VSColorsLight"),
                ResolvePreset($"{path}.WPSystemColors"),
                ResolvePreset($"{path}.WFSystemColors"),
            };
        }

        private ColorPreset ResolvePreset(string resourceName) {

            var assembly = Assembly.GetExecutingAssembly();
            var serializer = new XmlSerializer(typeof(ColorPreset));

            using (var resource = assembly.GetManifestResourceStream(resourceName))
            using (var decompressed = new DeflateStream(resource, CompressionMode.Decompress)) {
                return (ColorPreset)serializer.Deserialize(decompressed);
            }
        }
    }
}