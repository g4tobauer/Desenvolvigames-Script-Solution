using Assets.Scenes.Character.Interfaces;
using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]
public class ChineleeMechanicsSystem : MonoBehaviour, IControllable
{
    private enum ActionMechanics
    {
        NONE,
        CHINELOONFEET,
        JUMPTOCHINELO
    }
    #region Fields
    private Chinelo m_Chinelo;
    private Vector3 m_KickDirection;
    private ActionMechanics m_ActionMechanicsCurrent;
    private CharacterControllerScript m_CharacterControllerScript;
    #endregion

    #region Unity Methods
    void Start()
    {
        m_ActionMechanicsCurrent = ActionMechanics.CHINELOONFEET;
        m_CharacterControllerScript = GetComponent<CharacterControllerScript>();
    }
    void Update()
    {
        ChineleeMechanicsRules();
    }
    private void FixedUpdate()
    {
        if (WithControl)
        {
            if (m_ActionMechanicsCurrent == ActionMechanics.JUMPTOCHINELO)
            {
                m_KickDirection = (m_Chinelo.Position - m_CharacterControllerScript.Rigidbody2D.transform.position).normalized;
                m_CharacterControllerScript.Rigidbody2D.MovePosition(m_CharacterControllerScript.Rigidbody2D.transform.position + m_KickDirection * 20 * Time.fixedDeltaTime);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (WithControl)
        {
            if(m_ActionMechanicsCurrent == ActionMechanics.JUMPTOCHINELO)
            {
                if ((LayerMask.NameToLayer(Constants.Layers.Chinelo) == col.gameObject.layer))
                {
                    m_CharacterControllerScript.Rigidbody2D.velocity = Vector2.zero;
                    m_CharacterControllerScript.TakeControl(this);
                    m_ActionMechanicsCurrent = ActionMechanics.CHINELOONFEET;
                    Destroy(m_Chinelo.gameObject);
                }
            }
        }
    }

    #endregion

    #region Methods
    private void ChineleeMechanicsRules()
    {
    }

    public void ChineloPower()
    {
        if (m_ActionMechanicsCurrent == ActionMechanics.CHINELOONFEET)
        {
            ThrowChinelo();
        }
        else if (m_ActionMechanicsCurrent == ActionMechanics.NONE)
        {
            JumpToChinelo();
        }
    }

    private void ThrowChinelo()
    {
        m_ActionMechanicsCurrent = ActionMechanics.NONE;
        //m_Chinelo = m_CharacterControllerScript.Instanciator.InstantiateChinelo(m_CharacterControllerScript.gameObject.transform);
    }

    private void JumpToChinelo()
    {
        TakeControl(m_CharacterControllerScript);
        if(WithControl && (m_ActionMechanicsCurrent == ActionMechanics.NONE))
            m_ActionMechanicsCurrent = ActionMechanics.JUMPTOCHINELO;
    }
    #endregion

    #region IControllable
    public bool PassControl()
    {
        if (WithControl) WithControl = false;
        else return false;
        return true;
    }
    public void TakeControl(IControllable controllable)
    {
        if (!WithControl)
        {
            if (IsFinishedControl && controllable.PassControl())
            {
                WithControl = true;
            }
        }
    }
    public bool WithControl { get; private set; }
    public bool IsFinishedControl { get { return m_ActionMechanicsCurrent == ActionMechanics.NONE; } }
    #endregion 
}
