using DoWhat.Data;
using DoWhat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Services
{
    public class ThingService
    {
        private readonly Guid _userId;

        public ThingService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<ThingListItem> GetThings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Things
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new ThingListItem
                    {
                        ThingId = e.ThingId,
                        Heading = e.Heading,
                        SubHeading = e.SubHeading,
                        TimeAlloted = (ThingListItem.AllottedTime)e.TimeAllotted, // no idea if this is the right "fix" or not. 
                        CreatedUtc = e.CreatedUtc
                    }
                    );
                return query.ToArray();
            }
        }

        public ThingDetail GetThingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Things
                    .Single(e => e.ThingId == id && e.OwnerId == _userId);
                return
                    new ThingDetail
                    {
                        ThingId = entity.ThingId,
                        Heading = entity.Heading,
                        SubHeading = entity.SubHeading,
                        TimeAllotted = (Models.AllottedTime)entity.TimeAllotted,
                        IsCompleted = entity.IsCompleted,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }

        // CreateThing
        public bool CreateThing(ThingCreate model)
        {
            var entity = new Thing()
            {
                OwnerId = _userId,
                Heading = model.Heading,
                SubHeading = model.SubHeading,
                TimeAllotted = (Data.AllottedTime)model.TimeAllotted,
                CreatedUtc = DateTime.UtcNow
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Things.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // UpdateThing
        public bool UpdateThing(ThingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Things
                    .Single(e => e.ThingId == model.ThingId && e.OwnerId == _userId);
                entity.Heading = model.Heading;
                entity.SubHeading = model.SubHeading;
                entity.TimeAllotted = (Data.AllottedTime)model.TimeAllotted;
                entity.IsCompleted = model.IsCompleted;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        // DeleteThing
        public bool DeleteThing(int thingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Things
                    .Single(e => e.ThingId == thingId && e.OwnerId == _userId);

                ctx.Things.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
