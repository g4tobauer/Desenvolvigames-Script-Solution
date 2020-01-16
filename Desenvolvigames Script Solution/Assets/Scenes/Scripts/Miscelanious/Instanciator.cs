using Assets.Scenes.Character.Interfaces;
using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciator : MonoBehaviour
{
    private static Projectile m_IronProjectile;
    private static Chinelo m_Chinelo;

    void Start()
    {
        LoadProjectiles();
        LoadChinelo();
    }

    private void LoadProjectiles()
    {
        if (m_IronProjectile == null)
        {
            m_IronProjectile = Resources.Load<GameObject>(Constants.Resources.IronProjectilePath).GetComponent<Projectile>();
        }
    }
    public Projectile InstantiateProjectile(Transform transform, Constants.Projectile.ProjectileType projectileType)
    {
        switch (projectileType)
        {
            case Constants.Projectile.ProjectileType.Iron:
                return Instantiate(m_IronProjectile, transform.position, transform.rotation);
            default:
                return null;
        }
    }

    private void LoadChinelo()
    {
        if (m_Chinelo == null)
        {
            m_Chinelo = Resources.Load<GameObject>(Constants.Resources.ChineloPath).GetComponent<Chinelo>();
        }
    }
    public Chinelo InstantiateChinelo(Transform transform)
    {
        return Instantiate(m_Chinelo, transform.position, transform.rotation);
    }
}
