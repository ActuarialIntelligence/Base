using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ActuarialIntelligence.Domain;

namespace KubernetesService.Controllers
{
    [Route("api/ReadWriteToInMemoryObject")]
    [ApiController]
    public class ReadWriteToInMemoryObjectController : Controller
    {
        private ObjectStorePatternObject objectStorePatternObject;
        private ObjectByteStorePatternObject objectByteStorePatternObject;
        // GET: ReadWriteToInMemoryObject/Create
        [HttpPost("CreateString")]
        public ActionResult<ObjectStorePatternObject> Create(string json)
        {
            var stringRows = JsonSerializer.Deserialize<ObjectStorePatternObject>(json);
            objectStorePatternObject = stringRows;
            return stringRows;
        }
        [HttpPost("CreateByte")]
        public ActionResult<ObjectByteStorePatternObject> Create(byte[] bytes)
        {
            var byteRows = JsonSerializer.Deserialize<ObjectByteStorePatternObject>(bytes);
            objectByteStorePatternObject = byteRows;
            return byteRows;
        }
    }
}
