namespace Domain.Entity
{
    public class Team
    {
        public Player PointGuard { get; set; }
        public Player ShootingGuard { get; set; }
        public Player PowerForward { get; set; }
        public Player SmallForward { get; set; }
        public Player Center { get; set; }
        public int Score { get; set;  }
    }
}
