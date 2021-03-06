using IPA.Config.Stores.Attributes;
using IPA.Config.Stores.Converters;
using UnityEngine;

namespace MoreDifferentDots
{
    public class Config
    {
        public virtual bool DotsEnabled { get; set; } = true;

        [UseConverter(typeof(HexColorConverter))]
        public virtual Color Color { get; set; } = Color.white;
        public virtual float Scale { get; set; } = 0.1f;
        public virtual float Distance { get; set; } = 1f;
    }
}