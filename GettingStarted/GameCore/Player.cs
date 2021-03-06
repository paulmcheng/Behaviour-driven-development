﻿using System.Collections.Generic;
using System.Linq;

namespace GameCore
{
    public class Player
    {
        public Player()
        {
            Health = 100;
            IsDead = false;
            CharacterClass = CharacterClass.None;
            Weapons = new List<Weapon>();
            MagicItems = new List<MagicItem>();
        }

        public void Hit(int damage)
        {
            Health -= System.Math.Abs(Resistance - damage);
            if (Health <= 0 ) { IsDead =  true; }
        }

        public int WeaponValue
        {
            get { return Weapons.Sum(x => x.Value); }
        }

        public void AddWeapon(Weapon item)
        {
            Weapons.Add(item);
        }

        public int MagicPower
        {
            get { return MagicItems.Sum(x => x.Power); }
        }

        public void CastHealingSpell()
        {
            if (CharacterClass == CharacterClass.Healer) { Health = 100; }
        }

        public void UseMagicalItem(string itemName)
        {
            int powerReduction = 10;

            var itemToReduce = MagicItems.First(item => item.Name == itemName && item.Power > 0);

            if (itemToReduce != null)
            {
                itemToReduce.Power -= powerReduction;
            }
        }

        public void AddMagicItem(MagicItem item)
        {
            MagicItems.Add(item);
        }

        public int Health { get; private set; }
        public bool IsDead { get; private set; }
        public string Race { get; set; }
        public int Resistance { get; set; }
        public CharacterClass CharacterClass { get; set; }
        public List<Weapon> Weapons { get; private set; }
        public List<MagicItem> MagicItems { get; private set; }
    }
}
