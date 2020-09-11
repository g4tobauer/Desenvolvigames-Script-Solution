namespace Assets.Scenes.Miscelanious
{
    public static class Constants
    {
        public static class Gameplay
        {
            public const float GravityScale = 5;
        }

        public static class Layers
        {
            public const string Ground = "Ground";
            public const string Chinelo = "Chinelo";
            public const string Targetable = "Targetable";
            public const string Pickupable = "Pickupable";
        }
        public static class DashSystem
        {
            public const float DashTime = .1f;
            public const float DashAttack = 2;
            public const float DashDodge = 8;
        }
        public static class InputSystem
        {
            public static class Axis
            {
                public const string Horizontal = "Horizontal";
                public const string Vertical = "Vertical";
            }
        }
        public static class StatsSystem
        {
            public static class Health
            {
                public const int MaxHeath = 100;
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
                public const string IronProjectile = "Prefabs/Prototypes/Weapon/Projectiles/IronProjectile";
            }
        }

        //public static class Resources
        //{            
        //    public const string ChineloPath = "Prefabs/Prototypes/Chinelo";

        //    public static class Prefabs
        //    {
        //        public static class Projectiles
        //        {
        //            public const string ProjectilesPath = "Prefabs/Prototypes/Weapon/Projectiles/";
        //            public const string IronProjectile = "IronProjectile";
        //        }
        //    }
        //}
    }
}
