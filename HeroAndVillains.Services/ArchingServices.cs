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
    }
}
