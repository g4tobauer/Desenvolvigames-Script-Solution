namespace Assets.Scenes.Miscelanious
{
    public static class Constants
    {
        public static class Gameplay
        {
            public const float ZeroGravityScale = 0;
            public const float NormalGravityScale = 5;
            public const float JumpStartPosition = 0;
            public const float JumpHeight = 1;
            public const float JumpMaxCount = 2;
        }

        public static class Layers
        {
            public const string Ground = "Ground";
            public const string Chinelo = "Chinelo";
            public const string Targetable = "Targetable";
            public const string Pickupable = "Pickupable";
        }
        public static class AnimationSystem
        {
            public static class Triggers
            {
                public const string Attack = "Attack";
                public const string Dodge = "Dodge";
                public const string Jump = "Jump";
            }
            public static class Booleans
            {
                public const string IsGrounded = "IsGrounded";
            }
            public static class Floats
            {
                public const string Speed = "Speed";
            }
        }
        public static class DashSystem
        {
            public const float DashTime = .1f;
            public static class Attack
            {
                public const float UpDashAttack = .3f;
                public const float DashAttackSpeed = 2;
            }
            public static class Dodge
            {
                public const float UpDashDodge = .5f;
                public const float DashDodgeSpeed = 8;
            }
        }
        public static class InputSystem
        {
            public static class Axis
            {
                public const string Horizontal = "Horizontal";
                public const string Vertical = "Vertical";
                public const string RightTrigger = "RightTrigger";
                public const float TriggerThreshold = .5f;
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
