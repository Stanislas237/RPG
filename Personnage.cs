using System;
using System.Collections.Generic;
using System.Linq;
using System.Test;
using System.Threating.Tasks;

namespace Game
{
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
                Console.foregroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Bravo, vous avez atteint le niveau " + lvl + "!");

                HP += 10;
                min_atk += 2;
                max_atk += 2;
            }
        }

        public double required_exp()
        {
            return Math.ceiling(4 * Math.Pow(lvl, 3)/5);
        }

        public stats()
        {
            return this.name +
                    "\n points de vie : " + HP +
                    "\n niveau : " + lvl +
                    "\n points d'expérience : (" + exp + "/" + required_exp() + ")" +
                    "\nDégâts : [" + min_atk + "....." + max_atk + "]";
        }

    }
}