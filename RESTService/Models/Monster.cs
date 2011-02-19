using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace RESTService.Models
{
    public enum WeaponType
    {
        Club,
        Mace,
        Rapier,
        Scythe
    };

    public enum ArmorType
    {
        Scales,
        Cloth,
        Leather,
        Chainmail
    };

    public class Monster
    {
        public int Id;
        public string MonsterName { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public WeaponType Weapon;
        public ArmorType Armor;

        public Monster()
        {
        }

        public Monster(string name, int age, string description, WeaponType weapon, ArmorType armor)
        {
            MonsterName = name;
            Age = age;
            Description = description;
            Weapon = weapon;
            Armor = armor;
        }
    }
}