using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ProjectileObject : ScriptableObject
{
    public float Damage;
    public float Velocity;
    public Sprite Sprite;
    public Constants.Enumerations.Projectile.ProjectileType ProjectileType;
}
