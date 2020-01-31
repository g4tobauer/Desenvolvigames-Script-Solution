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
        public static class StatsSystem
        {
            public static class Health
            {
                public static readonly int MaxHeath = 100;
            }
        }
        public static class Enumerations
        {
            public static class Weapon
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
                public static class MeleeWeapon
                {
                    public enum MeleeWeaponType
                    {
                        Iron
                    }
                }
                public static class Projectile
                {
                    public enum ProjectileType
                    {
                        Iron
                    }
                }
            }
            public static class Pickupable
            {
                public enum PickupableType
                {
                    FireWeapon,
                    MeleeWeapon,
                    Health,
                    Soul,
                    Ammo
                }
            }
        }

        public static class Path
        {
            public static class ProjectilesPath
            {
                public static readonly string IronProjectile = "Prefabs/Prototypes/Weapon/Projectiles/IronProjectile";
            }
        }

        //public static class Resources
        //{            
        //    public static readonly string ChineloPath = "Prefabs/Prototypes/Chinelo";

        //    public static class Prefabs
        //    {
        //        public static class Projectiles
        //        {
        //            public static readonly string ProjectilesPath = "Prefabs/Prototypes/Weapon/Projectiles/";
        //            public static readonly string IronProjectile = "IronProjectile";
        //        }
        //    }
        //}
    }
}
