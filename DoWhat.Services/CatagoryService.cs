using DoWhat.Data;
using DoWhat.Models.CatagoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Services
{
    public class CatagoryService
    {
        private readonly Guid _userId;

        public CatagoryService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<CatagoryListItem> GetCatagories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Catagories
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new CatagoryListItem
                    {
                        CatagoryId = e.CatagoryId,
                        Name = e.Name,
                        Description = e.Description
                    }
                    );
                return query.ToArray();
            }
        }

        public CatagoryDetail GetCatagoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Catagories
                    .Single(e => e.CatagoryId == id && e.OwnerId == _userId);
                return
                    new CatagoryDetail
                    {
                        CatagoryId = entity.CatagoryId,
                        Name = entity.Name,
                        Description = entity.Description
                    };
            }
        }

        // CreateCatagory
        public bool CreateCatagory(CatagoryCreate model)
        {
            var entity = new Catagory()
            {
                OwnerId = _userId,
                Name = model.Name,
                Description = model.Description,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Catagories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // UpdateCatagory
        public bool UpdateCatagory(CatagoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Catagories
                    .Single(e => e.CatagoryId == model.CatagoryId && e.OwnerId == _userId);
                entity.Name = model.Name;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        // DeleteCatagory
        public bool DeleteCatagory(int catagoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Catagories
                    .Single(e => e.CatagoryId == catagoryId && e.OwnerId == _userId);

                ctx.Catagories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
