using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Agathas.StorefrontController.JSONDTOs
{
    public class JsonModelBinder :IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
            }
            var serializer = new DataContractJsonSerializer(bindingContext.ModelType);
            return serializer.ReadObject(controllerContext.HttpContext.Request.InputStream);
        }
    }
}
