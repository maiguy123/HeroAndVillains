using HeroAndVillains.Data;
using HeroAndVillains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroAndVillains.Services
{
    public class MetaHumanServices
    {
        private readonly Guid _userId;
        public MetaHumanServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMetaHuman(MetaHumanCreate model)
        {
            var entity =
                new MetaHumans()
                {
                    OwnerId = _userId,
                    PowerType = model.PowerType,
                    Rating = model.Rating,
                    Home = model.Home,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PoweredPeople.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MetaHumanListItem> GetMetaHuman()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .PoweredPeople
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new MetaHumanListItem
                        {
                            PowerType = e.PowerType,
                            Rating = e.Rating,
                            Home = e.Home,

                        }
                        );
                return query.ToArray();
            }

        }
        public MetaHumanDetail GetMetaHumansById(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PoweredPeople
                    .Single(e => e.MetaHumanID == id && e.OwnerId == _userId);
                return
                    new MetaHumanDetail
                    {
                        PowerType = entity.PowerType,
                        Rating = entity.Rating,
                        Home = entity.Home,

                    };
            }
        }

    }
}


