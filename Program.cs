using System;
using System.Collections.Generic;
using System.Linq;


namespace Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Jouer(Personnage perso)
        {
            Monstre monstre = new Monstre("Loup enragé");
            bool victoire = true;
            bool next = false;

            while(!monstre.die())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                monstre.Attaquer(perso);
                Console.WriteLine();
                Console.ReadKey(true);

                if(perso.die())
                {
                    victoire = false;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                perso.Attaquer(monstre);
                Console.WriteLine();
                Console.ReadKey(true);
            }

            if (victoire)
            {
                perso.win_exp(5);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.WriteLine(perso.stats());

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Salle suivante ? (O/N)");
                while (!next)
                {
                    string saisie = Console.ReadLine().ToUpper();
                    if(Convert.ToString(saisie) == Convert.ToString('O'))
                    {
                        next = true;
                        Jouer(perso);
                    }
                    else if(Convert.ToString(saisie) == Convert.ToString('N'))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Environment.Exit(0);
                    }
                }
            }
            else {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("C'est perdu...");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("RPG");
            Console.WriteLine();
            Console.WriteLine("Choisis ta classe :");
            Console.WriteLine("1. Guerrier");
            Console.WriteLine("2. Sorcier");
            Console.WriteLine("3. Archer");
            Console.WriteLine("4. Quitter");
            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Vous avez choisi Guerrier !");
                    Console.WriteLine();
                    Jouer(new Guerrier("Guerrier"));
                    break;
                case "2":
                    Console.WriteLine("Vous avez choisi Sorcier !");
                    Console.WriteLine();
                    Jouer(new Sorcier("Sorcier"));
                    break;
                case "3":
                    Console.WriteLine("Vous avez choisi Archer !");
                    Console.WriteLine();
                    Jouer(new Archer("Archer"));
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }


    public class Personnage: Entite
    {
        private int lvl;
        private int exp;

        public Personnage(string name) : base(name)
        {
            this.name = name;
            lvl = 1;
            exp = 0;
        }

        public void win_exp(int xp)
        {
            this.exp += xp;
            while(this.exp >= required_exp())
            {
                lvl++;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Bravo, vous avez atteint le niveau " + lvl + "!");

                HP += 10;
                min_atk += 2;
                max_atk += 2;
            }
        }

        public double required_exp()
        {
            return 4 * Math.Pow(lvl, 3)/5;
        }

        public string stats()
        {
            return this.name +
                    "\n points de vie : " + HP +
                    "\n niveau : " + lvl +
                    "\n points d'expérience : (" + exp + "/" + required_exp() + ")" +
                    "\nDégâts : [" + min_atk + "....." + max_atk + "]";
        }

    }


    public abstract class Entite
    {
        protected string name;
        protected bool dead = false;
        protected int HP;
        protected int max_atk;
        protected int min_atk;
        protected Random random = new Random();

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

            if (perso.die())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(perso.name + " est mort");
            }
        }

        protected void damage(int PV)
        {
            HP -= PV;
            if (HP <= 0)
            {
                HP = 0;
                dead = true;
            }
        }

        public bool die()
        {
            return this.dead;
        }
    }


    public class Monstre: Entite
    {
        public Monstre(string name): base(name)
        {
            this.name = name;
            HP = 60;
            min_atk = 5;
            max_atk = 10;
        }

    }


    public class Archer: Personnage
    {
        public Archer(string name) : base(name)
        {
            HP = 105;
            min_atk = 10;
            max_atk = 20;
        }

    }


    public class Guerrier : Personnage
    {
        public Guerrier(string name) : base(name)
        {
            HP = 120;
            min_atk = 10;
            max_atk = 15;
        }

    }


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