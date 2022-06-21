using Fllr.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Fllr.Controllers
{
    public class BaseImageController : ControllerBase
    {        
        protected FileResult BuildResponse(PlaceholdImage image)
        {            
            return File(image.Payload, image.MimeType);
        }
    }
}