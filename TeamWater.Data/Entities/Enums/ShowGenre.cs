using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeamWater.Data.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    //^^This nifty line will show in swagger what the options are for genre so that the spelled out genre can be typed in as opposed to the number assigned to the genre in the enum array.
    

    public enum ShowGenre
    {
        ACTION,
        ADVENTURE,
        SCI_FI,
        ROMANTIC_COMEDY,
        SITCOM,
        DRAMA
    }
}