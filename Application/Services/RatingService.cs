using Domain.Entity;

namespace Application.Services
{
    public class RatingService
    {
        private WeightsStore _weightsStore;

        public RatingService(WeightsStore weightsStore)
        {
            _weightsStore = weightsStore;
        }

        public double ComputeRating(StatLine stats)
        {
            var weights = _weightsStore.GetWeights();

            return Math.Round(stats.Points * weights.Points
                + stats.Assists * weights.Assists
                + stats.Rebounds * weights.Rebounds
                + stats.Steals * weights.Steals
                + stats.Blocks * weights.Blocks
                + stats.Turnovers * weights.Turnovers);
        }
    }
}
