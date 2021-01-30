using DoWhat.Data;
using DoWhat.Models.ResourceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Services
{
    public class ResourceService
    {
        private readonly Guid _userId;

        public ResourceService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<ResourceListItem> GetResources()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Resources
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new ResourceListItem
                    {
                        ResourceId = e.ResourceId,
                        ThingId = e.ThingId,
                        Thing = e.Thing,
                        Title = e.Title,
                        CreatedUtc = e.CreatedUtc
                    }
                    );
                return query.ToArray();
            }
        }

        public ResourceDetail GetResourceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Resources
                    .Single(e => e.ResourceId == id && e.OwnerId == _userId);
                return
                    new ResourceDetail
                    {
                        ResourceId = entity.ResourceId,
                        ThingId = entity.ThingId,
                        Thing = entity.Thing,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        // helper method for Thing Drop Down
        public List<Thing> ThingsToList()
        {
            var ctx = new ApplicationDbContext();
            return ctx.Things.Where(e => e.OwnerId == _userId).ToList();
        }

        //get ResourceByThingId
        public IEnumerable<ResourceListByThing> GetResourceListByThing(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Resources
                    .Where(e => e.ThingId == id && e.OwnerId == _userId)
                    .Select(e => new ResourceListByThing
                     {
                         ResourceId = e.ResourceId,
                         ThingId = e.ThingId,
                         Thing = e.Thing,
                         Title = e.Title,
                         Content = e.Content,
                         CreatedUtc = e.CreatedUtc
                     }
                     );
                return query.ToArray();
            }
        }

        // CreateResource ** might be intresting to create a resource within the detail view of a thing
        public bool CreateResource(ResourceCreate model)
        {
            var entity = new Resource()
            {
                OwnerId = _userId,
                ThingId = model.ThingId,
                Title = model.Title,
                Content = model.Content,
                CreatedUtc = DateTime.UtcNow
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Resources.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // UpdateResource
        public bool UpdateResource(ResourceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Resources
                    .Single(e => e.ResourceId == model.ResourceId && e.OwnerId == _userId);
                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ThingId = model.ThingId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        // DeleteResource
        public bool DeleteResource(int thingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Resources
                    .Single(e => e.ResourceId == thingId && e.OwnerId == _userId);

                ctx.Resources.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
