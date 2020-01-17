using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Miscelanious.Interfaces;
using Assets.Scenes.Scripts.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : PickupableObject
{
    private readonly Dictionary<Constants.Enumerations.Projectile.ProjectileType, int> m_ProjectilesClips = new Dictionary<Constants.Enumerations.Projectile.ProjectileType, int>();


    //private struct Projectiles

    #region Fields
    public Constants.Enumerations.FireWeapon.ShootingMode m_ShootingMode;
    public Transform m_SpawnProjectilePoint;

    public readonly float SEMIAUTOMATICTIMESHOOT = .1F;
    public readonly float AUTOMATICTIMESHOOT = .08F;

    private bool m_IsShooting;
    private float m_ShootTimeLapse;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        m_ProjectilesClips[CurrentProjectileType] = 0;
        PickupableType = Constants.Enumerations.Pickupable.PickupableType.FireWeapon;
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
            case Constants.Enumerations.FireWeapon.ShootingMode.AUTOMATIC:
                return AUTOMATICTIMESHOOT;
            case Constants.Enumerations.FireWeapon.ShootingMode.SEMIAUTOMATIC:
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
            Instanciator.Instancia.InstantiateProjectile(m_SpawnProjectilePoint, CurrentProjectileType);
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
    public void ReloadClip(Dictionary<Constants.Enumerations.Projectile.ProjectileType, int> projectilesBag)
    {
        if (!m_ProjectilesClips.ContainsKey(CurrentProjectileType))
            m_ProjectilesClips[CurrentProjectileType] = 0;

        if (projectilesBag.ContainsKey(CurrentProjectileType))
        {
            while (m_ProjectilesClips[CurrentProjectileType] < 7)
            {
                if (projectilesBag[CurrentProjectileType] > 0)
                {
                    --projectilesBag[CurrentProjectileType];
                    ++m_ProjectilesClips[CurrentProjectileType];
                }
                else break;
            }
        }
    }
    #endregion

    #region Properties
    public int CurrentProjectileAmmo { get { return m_ProjectilesClips[CurrentProjectileType]; } }
    public Constants.Enumerations.Projectile.ProjectileType CurrentProjectileType { get; } = Constants.Enumerations.Projectile.ProjectileType.Iron;
    #endregion
}
