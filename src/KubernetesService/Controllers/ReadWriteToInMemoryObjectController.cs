using System;
using System.Diagnostics;
using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.Financial_Instrument_Objects;
using ActuarialIntelligence.Domain.Mathematical_Technique_Objects;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ActuarialIntelligence.Domain;

namespace KubernetesService.Controllers
{
    public class ReadWriteToInMemoryObjectController : Controller
    { 
        // GET: ReadWriteToInMemoryObject/Create
        public ActionResult<ObjectStorePatternObject> Create(string json)
        {
            var stringRows = JsonSerializer.Deserialize<ObjectStorePatternObject>(json);
            return stringRows;
        }
    }
}
