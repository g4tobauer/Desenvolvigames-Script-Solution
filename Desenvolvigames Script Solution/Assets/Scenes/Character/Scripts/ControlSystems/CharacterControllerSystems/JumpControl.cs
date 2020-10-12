using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]

public class JumpControl : MonoBehaviour
{
    #region Fields
    [SerializeField] float m_jumpForce = 200.0f;
    private float m_JumpCount;
    private bool m_IsJumping;
    private float m_JumpStartPosition;
    private CharacterControllerScript CharacterControllerScript;
    #endregion
       
    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        m_JumpCount = Constants.Gameplay.JumpMaxCount;
        CharacterControllerScript = GetComponent<CharacterControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        JumpRule();
    }
    #endregion

    #region Methods
    private void Inputs()
    {
        if (CharacterControllerScript.InputSystem.GetKeyDown(KeyCode.Space) ||
        CharacterControllerScript.InputSystem.GetKeyDown(KeyCode.Joystick1Button0))
        {
            m_IsJumping = true;
            if((m_JumpCount > 0)) CharacterControllerScript.AnimationSystem.SetAnimation(Constants.AnimationSystem.Triggers.Jump);
        }
        if (CharacterControllerScript.InputSystem.GetKeyUp(KeyCode.Space) ||
            CharacterControllerScript.InputSystem.GetKeyUp(KeyCode.Joystick1Button0))
            m_IsJumping = false;
    }

    private void JumpRule()
    {
        float jumpForce = CharacterControllerScript.Rigidbody2D.velocity.y;
        if(m_IsJumping)
        {
            if (m_JumpStartPosition == Constants.Gameplay.JumpStartPosition)
            {
                if (!CharacterControllerScript.GroundCheckSystem.IsTouchingGround && m_JumpCount == Constants.Gameplay.JumpMaxCount) --m_JumpCount;
                --m_JumpCount;
                m_JumpStartPosition = CharacterControllerScript.Rigidbody2D.position.y;
            }
            if (Mathf.Abs(CharacterControllerScript.Rigidbody2D.position.y - m_JumpStartPosition) < Constants.Gameplay.JumpHeight)
            {
                //se ele puder continuar pulando, entao continua pulando
                if (!(m_JumpCount < 0))
                {
                    jumpForce = (m_jumpForce * Time.fixedDeltaTime);
                }
            }
            else
            {
                //se ele atingir a altura maxima, nao pode pular mais
                m_IsJumping = false;
            }
        }
        else
        {
            m_JumpStartPosition = Constants.Gameplay.JumpStartPosition;
            if (CharacterControllerScript.GroundCheckSystem.IsTouchingGround)
            {
                //se tiver no chao resetar o pulo
                m_JumpCount = Constants.Gameplay.JumpMaxCount;
            }
            else
            {
                //se nao tiver no chao e nao tiver mais pulando, nao pode pular mais
                m_IsJumping = false;
            }
        }
        CharacterControllerScript.JumpUpdate(jumpForce);
    }
    #endregion
}
