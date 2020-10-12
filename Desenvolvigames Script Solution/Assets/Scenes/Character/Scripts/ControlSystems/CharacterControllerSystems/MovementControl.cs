using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControllerScript))]

public class MovementControl : MonoBehaviour
{
    #region Fields
    [SerializeField] float m_speed = 1.0f;

    private float m_InputAxis;
    private CharacterControllerScript m_CharacterControllerScript;
    #endregion

    #region Unity Methods
    void Start()
    {
        m_CharacterControllerScript = GetComponent<CharacterControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        MovementRule();
    }
    #endregion

    #region Methods
    private void Inputs()
    {
        m_InputAxis = m_CharacterControllerScript.InputSystem.GetAxis(Constants.InputSystem.Axis.Horizontal);
    }
    private void MovementRule()
    {
        var moveSpeed = (m_InputAxis * m_speed * Time.fixedDeltaTime);
        m_CharacterControllerScript.MovementUpdate(moveSpeed);
    }
    #endregion
}
