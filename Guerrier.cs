using System;


namespace Game
{
    public class Guerrier : Personnage
    {
        public Guerrier(string name) : base(name)
        {
            HP = 120;
            min_atk = 10;
            max_atk = 15;
        }

    }
}