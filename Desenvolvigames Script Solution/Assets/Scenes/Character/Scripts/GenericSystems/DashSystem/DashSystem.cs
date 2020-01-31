using Assets.Scenes.Character.Interfaces;
using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSystem : MonoBehaviour, IControllable
{
    #region Fields
    public CharacterControllerScript CharacterControllerScript;

    private float m_DashTime;
    private Vector2 m_DashVelocity;
    #endregion

    #region Unity Methods
    private void Start()
    {
        IsFinishedControl = true;
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
            //Para fazer o dash precisamente, é necessário desabilitar a gravidade
            CharacterControllerScript.Rigidbody2D.gravityScale = 0;
            CharacterControllerScript.Rigidbody2D.velocity = m_DashVelocity * 2;
        }
    }
    #endregion

    #region Methods
    //Enquanto não passar o dashTime, continua aplicando a velocidade de dash até terminar o dashTime, devolvendo o controle para o CharacterControllerScript
    private void DashRules()
    {
        if (WithControl)
        {
            m_DashTime -= Time.deltaTime;
            if (m_DashTime <= 0)
            {
                m_DashTime = 0;
                //ao termino do dash, a gravidade é retornada
                CharacterControllerScript.Rigidbody2D.gravityScale = 3;
                CharacterControllerScript.TakeControl(this);
                IsFinishedControl = true;
            }
        }
    }
    //Aplica o Dash de ataque
    public void DashAttack(IControllable controllable)
    {
        Dash(controllable, Constants.DashSystem.DashAttack);
    }
    //Aplica o Dash de esquiva
    public void DashDodge(IControllable controllable)
    {
        Dash(controllable, Constants.DashSystem.DashDodge);
    }

    //Toma o Controle, adiciona a velocidade atual a velocidade de Dash, verifica qual o lado do dash e atribui a velocidade e o tempo do dash.
    private void Dash(IControllable controllable, float dashSpeed)
    {
        TakeControl(controllable);
        if (WithControl)
        {
            var dashVelocity = new Vector2();
            dashSpeed += (Mathf.Abs(CharacterControllerScript.Rigidbody2D.velocity.x) * .5f);
            if (CharacterControllerScript.IsFacingRight)
                dashVelocity.Set(dashSpeed, 0);
            else
                dashVelocity.Set(-dashSpeed, 0);
            m_DashTime = Constants.DashSystem.DashTime;
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
