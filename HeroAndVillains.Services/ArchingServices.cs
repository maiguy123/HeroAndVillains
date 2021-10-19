using HeroAndVillains.Data;
using HeroAndVillains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroAndVillains.Services
{
    public class ArchingServices
    {
        private readonly Guid _userId;
        public ArchingServices() { }
        public ArchingServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateArching(ArchingCreate model)
        {
            var entity =
                new Arching()
                {
                    OwnerId = _userId,
                    Story = model.Story
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Story.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ArchingListItem> GetArching()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Story
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ArchingListItem
                        {
                            Story = e.Story
                        }
                        );
                return query.ToArray();
            }

        }
        public ArchingDetail GetArchingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Story
                    .Single(e => e.ArchingID == id && e.OwnerId == _userId);
                return
                    new ArchingDetail
                    {
                        Story = entity.Story
                    };
            }
        }
            public bool UpdateArching (ArchingEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Story
                        .Single(e => e.ArchingID == model.ArchingID && e.OwnerId == _userId);

                    entity.Story = model.Story;

                    return ctx.SaveChanges() == 1;
                }
            }
            public bool DeleteArching (int archingId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Story
                        .Single(e => e.ArchingID == archingId && e.OwnerId == _userId);

                    ctx.Story.Remove(entity);

                    return ctx.SaveChanges() == 1;

                }
            }
    }
}
