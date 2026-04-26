namespace Domain.Entity
{
    public class RatingWeights
    {
        public float Points { get; set; } = 1.0f;
        public float OffensiveRebounds { get; set; } = 1.2f;
        public float DefensiveRebounds { get; set; } = 1.0f;
        public float Rebounds { get; set; } = 1.2f;
        public float Assists { get; set; } = 1.5f;
        public float Turnovers { get; set; } = -1.5f;
        public float Steals { get; set; } = 2.0f;
        public float Blocks { get; set; } = 2.0f;
    }
}
