using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]

public class JumpSystem : MonoBehaviour
{
    #region Fields
    [SerializeField] float m_jumpForce = 2.0f;
    private float m_JumpCount;
    private bool m_IsJumping;
    private float m_JumpStartPosition;
    private CharacterControllerScript m_CharacterControllerScript;
    #endregion
       
    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        m_JumpCount = 2;
        m_CharacterControllerScript = GetComponent<CharacterControllerScript>();
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
        if (m_CharacterControllerScript.InputSystem.GetKeyDown(KeyCode.Space))
            m_IsJumping = true;
        if (m_CharacterControllerScript.InputSystem.GetKeyUp(KeyCode.Space))
            m_IsJumping = false;
        //m_IsJumping = m_CharacterControllerScript.InputSystem.GetKey(KeyCode.Space);
    }

    private void JumpRule()
    {
        float jumpForce = m_CharacterControllerScript.Rigidbody2D.velocity.y;
        if(m_IsJumping)
        {
            if (m_JumpStartPosition == 0)
            {
                --m_JumpCount;
                m_JumpStartPosition = m_CharacterControllerScript.Rigidbody2D.position.y;
                m_CharacterControllerScript.Rigidbody2D.velocity = new Vector2(m_CharacterControllerScript.Rigidbody2D.position.x, 0);
            }
            if (Mathf.Abs(m_CharacterControllerScript.Rigidbody2D.position.y - m_JumpStartPosition) < 1)
            {
                //se ele puder continuar pulando, entao continua pulando
                if (!(m_JumpCount < 0)) jumpForce = (m_jumpForce * Time.fixedDeltaTime);
            }
            else
            {
                //se ele atingir a altura maxima, nao pode pular mais
                m_IsJumping = false;
            }
        }
        else
        {
            m_JumpStartPosition = 0;
            if (!m_CharacterControllerScript.GroundCheckSystem.IsTouchingGround)
            {
                //se nao tiver no chao e nao tiver mais pulando, nao pode pular mais
                m_IsJumping = false;
            }
            else
            {
                //se tiver no chao resetar o pulo
                m_JumpCount = 2;
            }
        }
        m_CharacterControllerScript.JumpUpdate(jumpForce);
    }
    #endregion
}
