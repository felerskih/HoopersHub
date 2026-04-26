using Application.Services;
using Domain.Entity;

namespace Application.Factory
{
    public class DefaultsFactory
    {
        private readonly RatingService _ratingService;

        public DefaultsFactory(RatingService ratingService)
        {
            _ratingService = ratingService;
        }

        public Game CreateGame()
        {
            return new Game
            {
                HomeTeam = CreateHomeTeam(),
                AwayTeam = CreateAwayTeam()
            };
        }

        private Team CreateHomeTeam()
        {
            return new Team
            {
                Score = 90,
                PointGuard = CreatePlayer("Liam", "Murray", points: 22, ast: 9, reb: 4, oreb: 1, stl: 2, blk: 0, to: 3, fgPct: 0.471, eFgPct: 0.529, tsPct: 0.561, ftPct: 0.857),
                ShootingGuard = CreatePlayer("Jordan", "Hayes", points: 18, ast: 3, reb: 5, oreb: 1, stl: 1, blk: 1, to: 2, fgPct: 0.432, eFgPct: 0.511, tsPct: 0.548, ftPct: 0.800),
                SmallForward = CreatePlayer("Marcus", "Bell", points: 24, ast: 4, reb: 7, oreb: 2, stl: 1, blk: 2, to: 2, fgPct: 0.489, eFgPct: 0.543, tsPct: 0.572, ftPct: 0.778),
                PowerForward = CreatePlayer("DeShawn", "Carter", points: 14, ast: 2, reb: 9, oreb: 3, stl: 0, blk: 3, to: 1, fgPct: 0.512, eFgPct: 0.512, tsPct: 0.558, ftPct: 0.667),
                Center = CreatePlayer("Tyrone", "Wallace", points: 12, ast: 1, reb: 11, oreb: 4, stl: 0, blk: 4, to: 2, fgPct: 0.556, eFgPct: 0.556, tsPct: 0.601, ftPct: 0.600),
            };
        }

        private Team CreateAwayTeam()
        {
            return new Team
            {
                Score = 99,
                PointGuard = CreatePlayer("Darius", "Webb", points: 28, ast: 8, reb: 3, oreb: 0, stl: 2, blk: 0, to: 4, fgPct: 0.445, eFgPct: 0.518, tsPct: 0.556, ftPct: 0.833),
                ShootingGuard = CreatePlayer("Carlos", "Vega", points: 21, ast: 3, reb: 4, oreb: 1, stl: 1, blk: 0, to: 2, fgPct: 0.423, eFgPct: 0.506, tsPct: 0.541, ftPct: 0.789),
                SmallForward = CreatePlayer("Elijah", "Grant", points: 19, ast: 5, reb: 6, oreb: 2, stl: 2, blk: 1, to: 3, fgPct: 0.461, eFgPct: 0.521, tsPct: 0.549, ftPct: 0.750),
                PowerForward = CreatePlayer("Nathan", "Cross", points: 17, ast: 2, reb: 8, oreb: 3, stl: 0, blk: 2, to: 1, fgPct: 0.478, eFgPct: 0.478, tsPct: 0.531, ftPct: 0.700),
                Center = CreatePlayer("Jalen", "Simms", points: 14, ast: 1, reb: 10, oreb: 4, stl: 0, blk: 3, to: 2, fgPct: 0.521, eFgPct: 0.521, tsPct: 0.574, ftPct: 0.583),
            };
        }

        private Player CreatePlayer(
            string firstName, string lastName,
            int points, int ast, int reb, int oreb,
            int stl, int blk, int to,
            double fgPct, double eFgPct, double tsPct, double ftPct)
        {
            var stats = new StatLine
            {
                Points = points,
                Assists = ast,
                Rebounds = reb,
                OffensiveRebounds = oreb,
                DefensiveRebounds = reb - oreb,
                Steals = stl,
                Blocks = blk,
                Turnovers = to,
                FieldGoalPercentage = fgPct,
                EffectiveFieldGoalPercentage = eFgPct,
                TrueShootingPercentage = tsPct,
                FreeThrowPercentage = ftPct,
                Rating = 0
            };

            stats.Rating = _ratingService.ComputeRating(stats);

            return new Player
            {
                User = new User { Name = $"{firstName} {lastName}", Stats = stats },
                Stats = stats
            };
        }
    }
}
