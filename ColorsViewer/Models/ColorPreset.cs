using System;
using System.Collections.Generic;

namespace ColorsViewer.Models {

    [Serializable]
    public struct ColorPreset {
        public string Name;
        public string Description;
        public List<NamedColor> Colors;
    }
}