﻿using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Miscelanious.Interfaces;
using Assets.Scenes.Scripts.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : PickupableObject
{
    private readonly Dictionary<Constants.Enumerations.Weapon.Projectile.ProjectileType, int> m_ProjectilesClips = new Dictionary<Constants.Enumerations.Weapon.Projectile.ProjectileType, int>();

    #region Fields
    public Instantiator Instantiator;
    public Transform SpawnProjectilePoint;
    public FireWeaponObject FireWeaponObject;

    //m_IsShooting nem precisaria existir, mas acabei deixando eles
    private bool m_IsShooting;
    private float m_ShootTimeLapse;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        CurrentProjectileType = FireWeaponObject.ProjectileTypeDefault;
        m_ProjectilesClips[CurrentProjectileType] = 0;
        PickupableType = FireWeaponObject.PickupableType;
        SpriteRenderer.sprite = FireWeaponObject.Sprite;
        gameObject.layer = Converter.LayerMaskToInt(FireWeaponObject.LayerMask);
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
        switch (FireWeaponObject.ShootingMode)
        {
            case Constants.Enumerations.Weapon.FireWeapon.ShootingMode.AUTOMATIC:
                return FireWeaponObject.AutomaticTimeShoot;
            case Constants.Enumerations.Weapon.FireWeapon.ShootingMode.SEMIAUTOMATIC:
                return FireWeaponObject.SemiAutomaticTimeShoot;
            default:
                return 0;
        }
    }
    //Atira e iicia o contador para o intervalo entre tiros
    private void StartShoot()
    {
        if (m_ProjectilesClips[CurrentProjectileType] > 0)
        {
            m_IsShooting = true;
            m_ShootTimeLapse = GetShootTime();
            Instantiator.InstantiateObject(SpawnProjectilePoint, Instantiator.IronProjectile.gameObject);
            m_ProjectilesClips[CurrentProjectileType] -= 1;
        }
    }
    //Para de atirar
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
    public void ReloadClip(Dictionary<Constants.Enumerations.Weapon.Projectile.ProjectileType, int> projectilesBag)
    {
        if (!m_ProjectilesClips.ContainsKey(CurrentProjectileType))
            m_ProjectilesClips[CurrentProjectileType] = 0;

        if (projectilesBag.ContainsKey(CurrentProjectileType))
        {
            while (m_ProjectilesClips[CurrentProjectileType] < FireWeaponObject.WeaponClipSize)
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
    public Constants.Enumerations.Weapon.Projectile.ProjectileType CurrentProjectileType { get; private set; }
    #endregion
}
