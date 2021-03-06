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
        public MetaHumanServices () { }
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
                    ArchingID = model.ArchingID,
                    TeamID = model.TeamID
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

                            ArchingID = e.ArchingID,
                            TeamID = e.TeamID,
                            MetaHumanID = e.MetaHumanID,

                        }
                        );
                return query.ToArray();
            }

        }
        public MetaHumanDetail GetMetaHumansById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PoweredPeople
                    .Single(e => e.MetaHumanID == id);
                return
                    new MetaHumanDetail
                    {
                        PowerType = entity.PowerType,
                        Rating = entity.Rating,
                        Home = entity.Home,

                    };
            }
        }
            public bool UpdateMetaHuman(MetaHumanEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PoweredPeople
                    .Single(e => e.MetaHumanID == model.MetaHumanID && e.OwnerId == _userId);

                entity.PowerType = model.PowerType;
                entity.Rating = model.Rating;
                entity.Home = model.Home;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMetaHuman (int metaHumanId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PoweredPeople
                    .Single(e => e.MetaHumanID == metaHumanId && e.OwnerId == _userId);

                ctx.PoweredPeople.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}


