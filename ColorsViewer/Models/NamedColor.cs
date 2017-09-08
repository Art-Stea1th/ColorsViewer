using System;
using System.Xml.Serialization;

namespace ColorsViewer.Models {

    [Serializable]
    public struct NamedColor {

        [XmlAttribute] public string Name;
        [XmlAttribute] public string Color;
    }
}