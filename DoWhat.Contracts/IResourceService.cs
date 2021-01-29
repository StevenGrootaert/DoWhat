using DoWhat.Data;
using DoWhat.Models.ResourceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Contracts
{
    public interface IResourceService
    {
        IEnumerable<ResourceListItem> GetResources();

        ResourceDetail GetResourceById(int id);

        List<Thing> ThingsToList();

        IEnumerable<ResourceListByThing> GetResourceListByThing(int id);

        bool CreateResource(ResourceCreate model);

        bool UpdateResource(ResourceEdit model);

        bool DeleteResource(int thingId);

    }
}
