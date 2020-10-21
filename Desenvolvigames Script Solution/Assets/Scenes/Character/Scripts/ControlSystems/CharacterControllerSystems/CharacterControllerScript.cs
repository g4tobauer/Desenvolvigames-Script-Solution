using Assets.Scenes.Character.Interfaces;
using Assets.Scenes.Miscelanious;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unity Scripts
[RequireComponent(typeof(Rigidbody2D))]

public class CharacterControllerScript : MonoBehaviour, IControllable
{
    #region Fields
    public Instantiator Instantiator;

    //Propriedade de acesso ao script HudSystem
    public HudSystem HudSystem;
    //Propriedade de acesso ao script DashSystem
    public DashSystem DashSystem;
    //Propriedade de acesso ao script StatsSystem
    public StatsSystem StatsSystem;
    //Propriedade de acesso ao script InputSystem
    public InputSystem InputSystem;
    //Propriedade de acesso ao script CombatSystem
    public CombatSystem CombatSystem;
    //Propriedade de acesso ao script PickupSystem
    public PickupSystem PickupSystem;
    //Propriedade de acesso ao script WeaponSystem
    public WeaponSystem WeaponSystem;
    //Propriedade de acesso ao script InventorySystem
    public InventorySystem InventorySystem;
    //Propriedade de acesso ao script AnimationSystem
    public AnimationSystem AnimationSystem;
    //Propriedade de acesso ao script GroundCheckSystem
    public GroundCheckSystem GroundCheckSystem;
    //Velocidade do character, manipulado pelo MovementScript e pelo JumpScript
    private Vector2 m_Velocity;

    private bool Attack;
    private bool Dodge;
    private bool DodgeReseted;
    #endregion

    #region Unity Methods
    void Start()
    {
        //Inicia virado para direita
        IsFacingRight = true;
        //Inicia com o controle sobre o character
        WithControl = true;
        
        //StatsSystem = GetComponent<StatsSystem>();
        Rigidbody2D = GetComponent<Rigidbody2D>();

        Rigidbody2D.gravityScale = Constants.Gameplay.NormalGravityScale;

        //Instancias dos Scripts que serão todos acessados atravez da CharacterControllerScript
        //ChineleeMechanicsSystem = GetComponent<ChineleeMechanicsSystem>();
    }
    void Update()
    {
        if (WithControl)
        {
            Inputs();
            Rules();
        }
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
        Attack = false;
        if (InputSystem.GetKeyDown(KeyCode.Mouse0) ||
            InputSystem.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Attack = true;
        }


        //Da um Dash de esquiva na direção IsFacingRight
        Dodge = false;
        if (InputSystem.GetKeyDown(KeyCode.LeftControl))
        {
            Dodge = true;
        }
        if (InputSystem.GetAxis(Constants.InputSystem.Axis.RightTrigger) > Constants.InputSystem.Axis.TriggerThreshold)
        {
            if (DodgeReseted)
            {
                DodgeReseted = false;
                Dodge = true;
            }
        }
        else
        {
            DodgeReseted = true;
        }
    }

    private void Rules()
    {
        if (Attack && !CombatSystem.IsAttacking)
        {
            AnimationSystem.SetAnimation(Constants.AnimationSystem.Triggers.Attack);
        }
        if (Dodge)
        {
            AnimationSystem.SetAnimation(Constants.AnimationSystem.Triggers.Dodge);
        }
        AnimationSystem.SetAnimation(Constants.AnimationSystem.Floats.Speed, Mathf.Abs(Rigidbody2D.velocity.x));
        AnimationSystem.SetAnimation(Constants.AnimationSystem.Booleans.IsGrounded, GroundCheckSystem.IsTouchingGround);
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

    #endregion

    #region Properties
    //Propriedade de verificação se o character esta virado para direita
    public bool IsFacingRight { get; private set; }
    //Propriedade de acesso ao componente Rigidbody2D
    public Rigidbody2D Rigidbody2D { get; private set; }


    ////Propriedade de acesso ao script ChineleeMechanicsSystem
    //public ChineleeMechanicsSystem ChineleeMechanicsSystem { get; private set; }
    #endregion

    #region IControllable
    //Passa o controle para o script que requisitou o controle atravez do TakeControl(IControllable controllable)
    public bool PassControl()
    {
        if (WithControl)
            WithControl = false;
        else
            return false;
        return true;
    }
    //Pega o controle do IControllable controllable passado no parametro
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
    //Propriedade de verificação se o script está com o controle
    public bool WithControl { get; private set; }
    //Propriedade de verificação se o script finalizou o controle
    public bool IsFinishedControl { get; private set; }
    #endregion 
}
