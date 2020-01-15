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

        public static class InputSystem
        {
            public static class Axis
            {
                public static readonly string Horizontal = "Horizontal";
                public static readonly string Vertical = "Vertical";
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

        public static class Resources
        {
            public static readonly string ProjectilePath = "Prefabs/Prototypes/Projectile";
            public static readonly string ChineloPath = "Prefabs/Prototypes/Chinelo";
            //public static readonly string HealthPath = "Prefabs/Prototypes/Health";
            //public static readonly string SoulPath = "Prefabs/Prototypes/Soul";
        }
    }
}
