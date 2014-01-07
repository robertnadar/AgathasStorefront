using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Controller.JSONDTOs
{
    public class JsonBasketQtyUpdateRequest
    {
        [DataMember]
        public JsonBasketItemUpdateRequest[] Items { get; set; }
    }
}
