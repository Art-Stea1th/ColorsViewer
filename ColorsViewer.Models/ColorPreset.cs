using System.Collections;
using System.Collections.Generic;

namespace ColorsViewer.Models {

    public class ColorPreset : IEnumerable<NamedColor> {

        public bool IsReadOnly => true;

        public string Name { get; }
        public string Description { get; }

        public IEnumerable<NamedColor> Colors { get; }

        public ColorPreset(string name, string description, IEnumerable<NamedColor> colors) {
            Name = name; Description = description; Colors = colors;
        }
        
        IEnumerator<NamedColor> IEnumerable<NamedColor>.GetEnumerator() => Colors?.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Colors?.GetEnumerator();
    }
}