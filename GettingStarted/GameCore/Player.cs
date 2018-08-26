namespace GameCore
{
    public class Player
    {
        public Player()
        {
            Health = 100;
            IsDead = false;
        }

        public void Hit(int damage)
        {
            Health -= System.Math.Abs(Resistance - damage);
            if (Health <= 0 ) { IsDead =  true; }
        }

        public int Health { get; private set; }
        public bool IsDead { get; private set; }
        public string Race { get; set; }
        public int Resistance { get; set; }
    }
}
