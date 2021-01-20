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
                        Title = e.Title,
                        Content = e.Content,
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
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc
                        // modifiedUtc??
                    };
            }
        }

        // CreateResource
        public bool CreateResource(ResourceCreate model)
        {
            var entity = new Resource()
            {       // how to I add the ThingId when creating a Resource? (or select from a list of things?) almost crazt to do it that way 
                // is there a way to create this within the details of a thing?
                OwnerId = _userId,
                ThingId = model.ThingId, // this isnt working too well. 
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
