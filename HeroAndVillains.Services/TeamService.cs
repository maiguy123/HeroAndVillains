using HeroAndVillains.Data;
using HeroAndVillains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroAndVillains.Services
{
    public class TeamService
    {
        private readonly Guid _userId;
        public TeamService () { }
        public TeamService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTeam(TeamCreate model)
        {
            var entity =
                new Team()
                {
                    OwnerId = _userId,
                    Rating = model.Rating,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Group.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<TeamListItem> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Group
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new TeamListItem
                        {
                            Rating = e.Rating
                        }
                        );
                return query.ToArray();
            }
        }
        public TeamDeatail GetTeamById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx 
                    .Group
                    .Single(e => e.TeamID == id && e.OwnerId == _userId);
                return
                    new TeamDeatail
                    {
                        Rating = entity.Rating,
                    };

            }
            
        }
            public bool UpdateTeam(TeamEdit model)
            {
                using(var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Group
                        .Single(e => e.TeamID == model.TeamID && e.OwnerId == _userId);
                    entity.Rating = model.Rating;

                    return ctx.SaveChanges() == 1;
                }
            }
        public bool DeleteTeam (int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Group
                    .Single(e => e.TeamID == teamId && e.OwnerId == _userId);

                ctx.Group.Remove(entity);

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
