using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Miscelanious.Interfaces;
using Assets.Scenes.Scripts.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Instanciator))]

public class FireWeapon : PickupableObject
{
    private readonly Dictionary<Constants.Projectile.ProjectileType, int> m_ProjectilesClips = new Dictionary<Constants.Projectile.ProjectileType, int>();

    public enum ShootingMode
    {
        RESET,
        SEMIAUTOMATIC,
        AUTOMATIC
    }

    //private struct Projectiles

    #region Fields
    public ShootingMode m_ShootingMode;
    public Transform m_SpawnProjectilePoint;

    public readonly float SEMIAUTOMATICTIMESHOOT = .1F;
    public readonly float AUTOMATICTIMESHOOT = .08F;

    private bool m_IsShooting;
    private float m_ShootTimeLapse;
    private Instanciator m_Instanciator;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        m_ProjectilesClips[CurrentProjectileType] = 0;
        m_Instanciator = GetComponent<Instanciator>();
        PickupableType = Constants.Pickupable.PickupableType.FireWeapon;
        gameObject.layer = LayerMask.NameToLayer(Constants.Layers.Pickupable);
    }
    // Update is called once per frame
    void Update()
    {
        FireWeaponRules();
    }
    #endregion

    #region Methods
    private void FireWeaponRules()
    {
        if (ShootTimeLapsePassed())
            StopShoot();
    }
    private bool ShootTimeLapsePassed()
    {
        if (m_ShootTimeLapse > 0)
        {
            m_ShootTimeLapse -= (Time.deltaTime);
            if (m_ShootTimeLapse > 0) return false;
            else return true;
        }
        else return true;
    }
    private float GetShootTime()
    {
        switch (m_ShootingMode)
        {
            case ShootingMode.AUTOMATIC:
                return AUTOMATICTIMESHOOT;
            case ShootingMode.SEMIAUTOMATIC:
                return SEMIAUTOMATICTIMESHOOT;
            default:
                return 0;
        }
    }
    private void StartShoot()
    {
        m_IsShooting = true;
        m_ShootTimeLapse = GetShootTime();

        if (m_ProjectilesClips[CurrentProjectileType] > 0)
        {
            m_Instanciator.InstantiateProjectile(m_SpawnProjectilePoint, CurrentProjectileType);
            m_ProjectilesClips[CurrentProjectileType] -= 1;
        }
    }
    private void StopShoot()
    {
        m_ShootTimeLapse = 0;
        m_IsShooting = false;
    }

    public void ResetShoot()
    {
        StopShoot();
    }
    public void Shoot()
    {
        if (!m_IsShooting && (m_ShootTimeLapse == 0))
        {
            //Atira na direção IsFacingRight
            StartShoot();
        }
    }    
    public void ReloadClip(Dictionary<Constants.Projectile.ProjectileType, int> projectilesBag)
    {
        if (!m_ProjectilesClips.ContainsKey(CurrentProjectileType))
            m_ProjectilesClips[CurrentProjectileType] = 0;

        while(m_ProjectilesClips[CurrentProjectileType] < 7)
        {
            if (projectilesBag.ContainsKey(CurrentProjectileType))
            {
                if (projectilesBag[CurrentProjectileType] > 0)
                {
                    --projectilesBag[CurrentProjectileType];
                    ++m_ProjectilesClips[CurrentProjectileType];
                }
                else break;
            }
            else break;
        }
    }
    #endregion

    #region Properties
    public int CurrentProjectileAmmo { get { return m_ProjectilesClips[CurrentProjectileType]; } }
    public Constants.Projectile.ProjectileType CurrentProjectileType { get; } = Constants.Projectile.ProjectileType.Iron;
    #endregion
}
