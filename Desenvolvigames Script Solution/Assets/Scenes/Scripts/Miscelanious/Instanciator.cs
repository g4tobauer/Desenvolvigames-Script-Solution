using Assets.Scenes.Character.Interfaces;
using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciator : MonoBehaviour
{
    private static Projectile m_Projectile;
    private static Chinelo m_Chinelo;

    void Start()
    {
        LoadProjectile();
        LoadChinelo();
    }

    private void LoadProjectile()
    {
        if (m_Projectile == null)
        {
            m_Projectile = Resources.Load<GameObject>(Constants.Resources.ProjectilePath).GetComponent<Projectile>();
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

    public Projectile InstantiateProjectile(Transform transform)
    {
        return Instantiate(m_Projectile, transform.position, transform.rotation);
    }
}
