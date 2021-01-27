using DoWhat.Data;
using DoWhat.Models.ThingModels;
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
                   //.Where(e => e.OwnerId == _userId)
                    .Where(e => e.OwnerId == _userId && e.IsCompleted.Equals(false))
                    .Select(e => new ThingListItem
                    {
                        ThingId = e.ThingId,
                        CatagoryId = e.CatagoryId,
                        Catagory = e.Catagory, // If I comment this out I can see Things that don't belong to catagories when that category gets deleted
                        Heading = e.Heading,
                        TimeAlloted = e.TimeAllotted,
                        IsCompleted = e.IsCompleted,
                        CreatedUtc = e.CreatedUtc
                    }
                    );
                return query.ToArray();
            }
        }

        public IEnumerable<ThingListItem> GetAllCompletedThings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Things
                    //.Where(e => e.OwnerId == _userId)
                    .Where(e => e.OwnerId == _userId && e.IsCompleted.Equals(true))
                    .Select(e => new ThingListItem
                    {
                        ThingId = e.ThingId,
                        CatagoryId = e.CatagoryId,
                        Catagory = e.Catagory, // If I comment this out I can see Things that don't belong to catagories when that category gets deleted
                        Heading = e.Heading,
                        TimeAlloted = e.TimeAllotted,
                        IsCompleted = e.IsCompleted,
                        CreatedUtc = e.CreatedUtc
                    }
                    );
                return query.ToArray();
            }
        }

        // **Assign a thing by join and querry syntax. I want a Thing that is of AllottedTime and of CatagoryId.. 
        // Need varaibles for CatagoryId and TimeAllotted that are passed in via drop downs... 
        // TellMeWhatToDo(model?) model of inforamtion that gets made to make this work?
        // TellmeWhatToDo(CatagoryInt int, AllottedTime int)

        // write the method that returns the same as in the controller ctx
        public IEnumerable<ThingListByCatagory> GetThingListByCatagory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Things
                    .Where(e => e.CatagoryId == id && e.OwnerId == _userId)
                    .Select(e => new ThingListByCatagory
                    {
                        ThingId = e.ThingId,
                        Heading = e.Heading,
                        TimeAlloted = e.TimeAllotted,
                        IsCompleted = e.IsCompleted,
                        CatagoryId = e.CatagoryId,
                        Catagory = e.Catagory,
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
                        CatagoryId = entity.CatagoryId,
                        Catagory = entity.Catagory,
                        TimeAllotted = entity.TimeAllotted,
                        IsCompleted = entity.IsCompleted,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc, 
                    };
            }
        }

        // helper method for Catagory View drop down
        public List<Catagory> CatagoriesToList()
        {
            var ctx = new ApplicationDbContext();
            //return ctx.Catagories.ToList();
            return ctx.Catagories.Where(e => e.OwnerId == _userId).ToList();
        }

        // CreateThing
        public bool CreateThing(ThingCreate model)
        {
            var entity = new Thing()
            {
                OwnerId = _userId,
                Heading = model.Heading,
                TimeAllotted = model.TimeAllotted,
                CatagoryId = model.CatagoryId,
                CreatedUtc = DateTime.UtcNow,
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
                entity.TimeAllotted = model.TimeAllotted;
                entity.IsCompleted = model.IsCompleted;
                entity.CatagoryId = model.CatagoryId;
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
