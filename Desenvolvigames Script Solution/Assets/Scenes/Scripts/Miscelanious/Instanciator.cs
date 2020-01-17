using Assets.Scenes.Character.Interfaces;
using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public sealed class Instanciator
{
    static Instanciator _instancia;
    public static Instanciator Instancia
    {
        get { return _instancia ?? (_instancia = new Instanciator()); }
    }
    private Instanciator() { }

    public Projectile InstantiateProjectile(Transform transform, Constants.Enumerations.Projectile.ProjectileType projectileType)
    {
        switch (projectileType)
        {
            case Constants.Enumerations.Projectile.ProjectileType.Iron:
                return Object.Instantiate(Loader.Instancia.GetPrefab(Constants.Resources.Prefabs.Projectiles.IronProjectile).GetComponent<Projectile>(), transform.position, transform.rotation);
            default:
                return null;
        }
    }
}