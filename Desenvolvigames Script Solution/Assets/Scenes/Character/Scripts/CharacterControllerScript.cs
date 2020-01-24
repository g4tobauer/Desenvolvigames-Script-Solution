using Assets.Scenes.Character.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unity Scripts
[RequireComponent(typeof(Rigidbody2D))]

//Custom Scripts
[RequireComponent(typeof(HudSystem))]
[RequireComponent(typeof(DashSystem))]
[RequireComponent(typeof(InputSystem))]
[RequireComponent(typeof(StatsSystem))]
[RequireComponent(typeof(WeaponSystem))]
[RequireComponent(typeof(PickupSystem))]
[RequireComponent(typeof(InventorySystem))]
[RequireComponent(typeof(GroundCheckSystem))]
//[RequireComponent(typeof(ChineleeMechanicsSystem))]

public class CharacterControllerScript : MonoBehaviour, IControllable
{
    #region Fields
    public Instantiator Instantiator;

    private Vector2 m_Velocity;
    //Velocidade do character, manipulado pelo MovementScript e pelo JumpScript
    #endregion

    #region Unity Methods
    private void Start()
    {
        IsFacingRight = true;
        //Inicia virado para direita

        WithControl = true;
        //Inicia com o controle sobre o character

        HudSystem = GetComponent<HudSystem>();
        DashSystem = GetComponent<DashSystem>();
        InputSystem = GetComponent<InputSystem>();
        StatsSystem = GetComponent<StatsSystem>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        WeaponSystem = GetComponent<WeaponSystem>();
        PickupSystem = GetComponent<PickupSystem>();
        InventorySystem = GetComponent<InventorySystem>();
        GroundCheckSystem = GetComponent<GroundCheckSystem>();
        //ChineleeMechanicsSystem = GetComponent<ChineleeMechanicsSystem>();
        //Instancias dos Scripts que serão todos acessados atravez da CharacterControllerScript
    }
    void Update()
    {
        Inputs();
        //Debugs();
    }
    void FixedUpdate()
    {
        if (WithControl)
        {
            Rigidbody2D.velocity = m_Velocity;
        }
    }
    #endregion

    #region Methods
    //Entrada de Dados do usuário
    private void Inputs()
    {
        //Da um microDash em direção IsFacingRight
        if (InputSystem.GetKeyDown(KeyCode.Mouse0))
            DashSystem.DashAttack(this);

        //Da um Dash de esquiva na direção IsFacingRight
        if (InputSystem.GetKeyDown(KeyCode.LeftControl))
            DashSystem.DashDodge(this);

        ////Pula em direção ao Chinelo
        //if (InputSystem.GetKeyDown(KeyCode.Mouse2))
        //    ChineleeMechanicsSystem.ChineloPower();
    }


    public void JumpUpdate(float jumpForce)
    {
        //Velocidade do character, manipulado pelo JumpScript
        if (WithControl)
            m_Velocity.Set(m_Velocity.x, jumpForce);
    }
    public void MovementUpdate(float moveSpeed)
    {
        if (WithControl)
        {
            //Velocidade do character, manipulado pelo MovementScript
            m_Velocity.Set(moveSpeed, m_Velocity.y);
            if (moveSpeed > 0)
                IsFacingRight = true;
            if (moveSpeed < 0)
                IsFacingRight = false;
        }
    }
    private void Debugs()
    {
        Debug.Log(StatsSystem.Health.ToString());
    }
    #endregion
    
    #region Properties
    public bool IsFacingRight { get; private set; }
    //Propriedade de verificação se o character esta virado para direita
    public HudSystem HudSystem { get; private set; }
    //Propriedade de acesso ao script HudSystem
    public DashSystem DashSystem { get; private set; }
    //Propriedade de acesso ao script DashSystem
    public InputSystem InputSystem { get; private set; }
    //Propriedade de acesso ao script InputSystem
    public StatsSystem StatsSystem { get; private set; }
    //Propriedade de acesso ao script StatsSystem
    public Rigidbody2D Rigidbody2D { get; private set; }
    //Propriedade de acesso ao componente Rigidbody2D
    public WeaponSystem WeaponSystem { get; private set; }
    //Propriedade de acesso ao script WeaponSystem
    public PickupSystem PickupSystem { get; private set; }
    //Propriedade de acesso ao script PickupSystem
    public InventorySystem InventorySystem { get; private set; }
    //Propriedade de acesso ao script InventorySystem
    public GroundCheckSystem GroundCheckSystem { get; private set; }
    //Propriedade de acesso ao script GroundCheckSystem   
    //public ChineleeMechanicsSystem ChineleeMechanicsSystem { get; private set; }
    ////Propriedade de acesso ao script ChineleeMechanicsSystem
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
    //Passa o controle para o script que requisitou o controle atravez do TakeControl(IControllable controllable)
    public void TakeControl(IControllable controllable)
    {
        if (!WithControl)
        {
            if (controllable.Equals(this))
                WithControl = true;
            else
                WithControl = controllable.PassControl();
        }
    }
    //Pega o controle do IControllable controllable passado no parametro
    public bool WithControl { get; private set; }
    //Propriedade de verificação se o script está com o controle
    public bool IsFinishedControl { get; private set; }
    //Propriedade de verificação se o script finalizou o controle
    #endregion 
}
