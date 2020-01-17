using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes.Miscelanious
{
    public static class Constants
    {
        public static class Layers
        {
            public static readonly string Ground = "Ground";
            public static readonly string Chinelo = "Chinelo";
            public static readonly string Targetable = "Targetable";
            public static readonly string Pickupable = "Pickupable";
        }
        public static class DashSystem
        {
            public static readonly float DashTime = .1f;
            public static readonly float DashAttack = 2;
            public static readonly float DashDodge = 8;
        }
        public static class InputSystem
        {
            public static class Axis
            {
                public static readonly string Horizontal = "Horizontal";
                public static readonly string Vertical = "Vertical";
            }
        }

        public static class Enumerations
        {
            public static class FireWeapon
            {
                public enum ShootingMode
                {
                    RESET,
                    SEMIAUTOMATIC,
                    AUTOMATIC
                }
            }
            public static class Projectile
            {
                public enum ProjectileType
                {
                    Iron
                }
            }
            public static class Pickupable
            {
                public enum PickupableType
                {
                    FireWeapon,
                    Health,
                    Soul,
                    Ammo
                }

                public static class Amount
                {
                    public enum Size
                    {
                        Small,
                        Medium,
                        Large
                    }
                }
            }
        }
        public static class Resources
        {            
            public static readonly string IronProjectilePath = "Prefabs/Prototypes/Weapon/Projectiles/IronProjectile";
            public static readonly string ChineloPath = "Prefabs/Prototypes/Chinelo";

            public static class Prefabs
            {
                public static class Projectiles
                {
                    public static readonly string ProjectilesPath = "Prefabs/Prototypes/Weapon/Projectiles/";
                    public static readonly string IronProjectile = "IronProjectile";
                }
            }
            public static class Sprites
            {
                public static class Health
                {                    
                    public static readonly string HealthPath = "Sprites/Health/";                    
                    public static readonly string HealthSmall = "HealthSmall";
                    public static readonly string HealthMedium = "HealthMedium";
                    public static readonly string HealthLarge = "HealthLarge";
                }
                public static class Weapons
                {
                    public static readonly string WeaponsPath = "Sprites/Weapons/";
                    public static readonly string ShotGun = "ShotGun";
                }
            }
            //public static readonly string HealthPath = "Prefabs/Prototypes/Health";
            //public static readonly string SoulPath = "Prefabs/Prototypes/Soul";
        }


    }
}
