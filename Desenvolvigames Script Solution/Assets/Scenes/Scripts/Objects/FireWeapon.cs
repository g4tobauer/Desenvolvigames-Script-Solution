using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Instanciator))]

public class FireWeapon : MonoBehaviour
{
    public enum ShootingMode
    {
        RESET,
        SEMIAUTOMATIC,
        AUTOMATIC
    }

    #region Fields
    public ShootingMode m_ShootingMode;
    public Transform m_SpawnBulletPoint;

    public readonly float SEMIAUTOMATICTIMESHOOT = .1F;
    public readonly float AUTOMATICTIMESHOOT = .08F;

    private bool m_IsShooting;
    private float m_ShootTimeLapse;
    private Instanciator m_Instanciator;
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        m_Instanciator = GetComponent<Instanciator>();
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
        m_Instanciator.InstantiateBullet(m_SpawnBulletPoint);
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
    #endregion
}
