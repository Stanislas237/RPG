using System;


namespace Game
{
    public class Sorcier: Personnage
    {
        public Sorcier(string name) : base(name)
        {
            HP = 80;
            min_atk = 15;
            max_atk = 25;
        }

    }
}