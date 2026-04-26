using Domain.Entity;

namespace Application.Services
{
    public class WeightsStore
    {
        private RatingWeights weights;

        public WeightsStore()
        {
            weights = new RatingWeights
            {
                Points = 1.0f,
                OffensiveRebounds = 1.2f,
                DefensiveRebounds = 1.0f,
                Rebounds = 1.2f,
                Assists = 1.5f,
                Turnovers = -1.5f,
                Steals = 2.0f,
                Blocks = 2.0f
            };
        }

        public RatingWeights GetWeights()
        {
            return weights;
        }

        public void UpdateWeights(RatingWeights newWeights)
        {
            weights = newWeights;
        }
    }
}
