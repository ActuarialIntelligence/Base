using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ActuarialIntelligence.Domain;

namespace KubernetesService.Controllers
{
    public class ReadWriteToInMemoryObjectController : Controller
    {
        private ObjectStorePatternObject objectStorePatternObject;
        private ObjectByteStorePatternObject objectByteStorePatternObject;
        // GET: ReadWriteToInMemoryObject/Create
        public ActionResult<ObjectStorePatternObject> Create(string json)
        {
            var stringRows = JsonSerializer.Deserialize<ObjectStorePatternObject>(json);
            objectStorePatternObject = stringRows;
            return stringRows;
        }

        public ActionResult<ObjectByteStorePatternObject> Create(byte[] bytes)
        {
            var byteRows = JsonSerializer.Deserialize<ObjectByteStorePatternObject>(bytes);
            objectByteStorePatternObject = byteRows;
            return byteRows;
        }
    }
}
