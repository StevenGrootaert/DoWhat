using DoWhat.Data;
using DoWhat.Models.ThingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Contracts
{
    // An interface is a type that defines a contract between an object and the interface
    // your service must have AT LEAST what's in the interface. If something is missing from the service you can implement that intot eh service
    // this is useful for depandancy injection (Autofac) this program allows dependancy injection - in the startup.cs file in MVC
    public interface IThingService
    {
        // properties with {get; set;}


        // method signatures
        IEnumerable<ThingListItem> GetThings();

        IEnumerable<ThingListItem> GetAllCompletedThings();

        IEnumerable<ThingListItem> GetSelectedThing(ThingSelection model);

        IEnumerable<ThingListByCatagory> GetThingListByCatagory(int id);

        ThingDetail GetThingById(int id);

        List<Catagory> CatagoriesToList();

        bool CreateThing(ThingCreate model);

        bool UpdateThing(ThingEdit model);

        bool DeleteThing(int thingId);

    }
}
