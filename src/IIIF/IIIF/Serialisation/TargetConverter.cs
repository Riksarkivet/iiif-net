using System.Linq;
using IIIF.Presentation.V2.Serialisation;
using IIIF.Presentation.V3;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IIIF.Serialisation
{
    public class TargetConverter : WriteOnlyConverter<IStructuralLocation>
    {
        public override void WriteJson(JsonWriter writer, IStructuralLocation? value, JsonSerializer serializer)
        {
            if (value is Canvas canvas)
            {
                writer.WriteValue(canvas.Id);
                return;
            }
            // TODO: add other types
        }
    }
}