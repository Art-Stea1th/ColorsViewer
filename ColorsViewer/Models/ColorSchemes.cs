using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Reflection;
using System.Xml.Serialization;

namespace ColorsViewer.Models {

    public sealed class ColorSchemes : IEnumerable<ColorPreset> {

        private readonly IList<ColorPreset> presets;
        public IEnumerator<ColorPreset> GetEnumerator() => presets.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => presets.GetEnumerator();

        public ColorSchemes() {

            var path = "ColorsViewer.Assets.Data";
            var extension = "bin";

            presets = new List<ColorPreset> {
                GetColorPreset($"{path}.WPColors.{extension}"),
                GetColorPreset($"{path}.WFColors.{extension}"),
                GetColorPreset($"{path}.VSColorsDark.{extension}"),
                GetColorPreset($"{path}.VSColorsBlue.{extension}"),
                GetColorPreset($"{path}.VSColorsLight.{extension}"),
                GetColorPreset($"{path}.WPSystemColors.{extension}"),
                GetColorPreset($"{path}.WFSystemColors.{extension}"),
            };
        }

        private ColorPreset GetColorPreset(string resourceName) {

            var assembly = Assembly.GetExecutingAssembly();
            var serializer = new XmlSerializer(typeof(ColorPreset));

            using (var resource = assembly.GetManifestResourceStream(resourceName))
            using (var decompressed = new DeflateStream(resource, CompressionMode.Decompress)) {
                return (ColorPreset)serializer.Deserialize(decompressed);
            }
        }
    }

    [Serializable]
    public struct ColorPreset {
        public string Name;
        public string Description;
        public List<NamedColor> Colors;
    }

    [Serializable]
    public struct NamedColor {
        [XmlAttribute] public string Name;
        [XmlAttribute] public string Color;
    }
}