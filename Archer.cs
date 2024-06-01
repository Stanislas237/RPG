using System;


namespace Game
{
    public class Archer: Personnage
    {
        public Archer(string name) : base(name)
        {
            HP = 105;
            min_atk = 10;
            max_atk = 20;
        }

    }
}