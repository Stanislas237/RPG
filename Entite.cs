using System;


namespace Game
{
    public abstract class Entite
    {
        protected string name;
        protected bool dead = false;
        protected int HP;
        protected int max_atk;
        protected int min_atk;
        protected Random random = new Random()

        public Entite(string name)
        {
            this.name = name;
        }

        public void Attaquer(Entite perso)
        {
            int damages = random.Next(min_atk, max_atk);
            perso.damage(damages);

            Console.WriteLine(this.name + "(" + HP + " PV) attaque " + perso.name);
            Console.WriteLine(perso.name + " a perdu " + damages + " PV");
            Console.WriteLine("Il reste " + perso.HP + " PV à " + perso.name);

            if (perso.die)
            {
                Console.foregroundColor = ConsoleColor.Red;
                Console.WriteLine(perso.name + " est mort");
            }
        }

        protected damage(int PV)
        {
            HP -= PV;
            if (HP <= 0)
            {
                HP = 0
                dead = true;
            }
        }

        public bool die()
        {
            return this.dead;
        }
    }
}