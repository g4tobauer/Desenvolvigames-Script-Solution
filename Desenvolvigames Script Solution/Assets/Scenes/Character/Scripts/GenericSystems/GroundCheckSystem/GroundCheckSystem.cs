using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundCheckSystem : MonoBehaviour
{
    #region Fields
    private Collider2D m_Collider2D;
    #endregion

    #region Unity Methods

    private void Start()
    {
        m_Collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        GroundCheckRules();
    }
    #endregion

    #region Methods
    private void GroundCheckRules()
    {
        IsTouchingGround = m_Collider2D.IsTouchingLayers(LayerMask.GetMask(Constants.Layers.Ground));
    }
    #endregion

    #region Fields
    public bool IsTouchingGround
    {
        get; private set;
    }
    #endregion
}
