using System;


namespace Game
{
    public class Monstre : Entite
    {
        public Monstre(string name): base(name)
        {
            this.name = name;
            HP = 60;
            min_atk = 5;
            max_atk = 10;
        }

    }
}