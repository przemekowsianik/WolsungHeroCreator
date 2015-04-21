using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolsungHeroCreator
{
    public class AttributesHandler
    {
        public int Strenght { get; private set; }
        public int Agility { get; private set; }
        public int Perception { get; private set; }
        public int Charisma { get; private set; }
        public int Composure { get; private set; }
        public int Endurance { get; private set; }
        public int Reputation { get; private set; }
        public int Defence { get; private set; }
        public int Stamina { get; private set; }
        public int SelfConfidence { get; private set; }
        private int wealth = 3;
        public int Wealth { get { return wealth; } }




        public void SetStrength(int strength)
        {
            this.Strenght = strength;
        }

        public void SetAgility(int agility)
        {
            this.Agility = agility;
        }

        public void SetCharisma(int charisma)
        {
            this.Charisma = charisma;
        }

        public void SetPerception(int perception)
        {
            this.Perception = perception;
        }

        public void SetComposure(int composure)
        {
            this.Composure = composure;
        }

        public void SetEndurance()
        {
            if (Strenght > Agility)
                Endurance = Strenght;
            else
                Endurance = Agility;
        }

        public void SetReputation()
        {
            if (Charisma > Composure)
                Reputation = Charisma;
            else
                Reputation = Composure;
        }

        public void SetDefenceAndStamina()
        {
            Defence = Stamina = 10 + (2 * Endurance);
        }

        public void SetSelfConfidence()
        {
            SelfConfidence = 10 + (2 * Reputation);
        }
    }
}
