using Assets.Scenes.Character.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]

public class DashSystem : MonoBehaviour, IControllable
{
    #region Fields
    private float DASHATTACK = 2;
    private float DASHDODGE = 8;

    private float m_DashTime;
    private Vector2 m_DashVelocity;
    private CharacterControllerScript m_CharacterControllerScript;
    #endregion

    #region Unity Methods
    private void Start()
    {
        IsFinishedControl = true;
        m_CharacterControllerScript = GetComponent<CharacterControllerScript>();
    }
    private void Update()
    {
        DashRules();
        //Debugs();
    }
    private void FixedUpdate()
    {
        if (WithControl)
        {
            m_CharacterControllerScript.Rigidbody2D.gravityScale = 0;
            m_CharacterControllerScript.Rigidbody2D.velocity = m_DashVelocity * 2;
        }
    }
    #endregion

    #region Methods
    private void DashRules()
    {
        if (WithControl)
        {
            m_DashTime -= Time.deltaTime;
            if (m_DashTime <= 0)
            {
                m_DashTime = 0;
                m_CharacterControllerScript.Rigidbody2D.gravityScale = 3;
                m_CharacterControllerScript.TakeControl(this);
                IsFinishedControl = true;
            }
        }
    }
    public void DashAttack(IControllable controllable)
    {
        Dash(controllable, DASHATTACK);
    }
    public void DashDodge(IControllable controllable)
    {
        Dash(controllable, DASHDODGE);
    }

    private void Dash(IControllable controllable, float dashSpeed)
    {
        TakeControl(controllable);
        if (WithControl)
        {
            var dashVelocity = new Vector2();
            dashSpeed += (Mathf.Abs(m_CharacterControllerScript.Rigidbody2D.velocity.x) * .5f);
            if (m_CharacterControllerScript.IsFacingRight)
                dashVelocity.Set(dashSpeed, 0);
            else
                dashVelocity.Set(-dashSpeed, 0);
            m_DashTime = .1f;
            m_DashVelocity = dashVelocity;
        }
    }

    private void Debugs()
    {
        Debug.Log(WithControl);
    }
    #endregion

    #region IControllable
    public bool PassControl()
    {
        if (WithControl)
            WithControl = false;
        else
            return false;
        return true;
    }
    public void TakeControl(IControllable controllable)
    {
        if (!WithControl)
        {
            if (IsFinishedControl && controllable.PassControl())
            {
                IsFinishedControl = false;
                WithControl = true;
            }
        }
    }
    public bool WithControl { get; private set; }
    public bool IsFinishedControl { get; private set; }
    #endregion 
}
