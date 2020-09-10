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

    private bool Mouse0Input;
    private bool LeftControlInput;
    private IEnumerator Coroutine;
    #endregion

    #region Unity Methods
    private void Start()
    {
        //Inicia virado para direita
        IsFacingRight = true;
        //Inicia com o controle sobre o character
        WithControl = true;
        //StatsSystem = GetComponent<StatsSystem>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.gravityScale = Constants.Gameplay.GravityScale;

        //ChineleeMechanicsSystem = GetComponent<ChineleeMechanicsSystem>();
        //Instancias dos Scripts que serão todos acessados atravez da CharacterControllerScript
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
        Mouse0Input = false;
        if (InputSystem.GetKeyDown(KeyCode.Mouse0))
        {
            Mouse0Input = true;
        }

        //Da um Dash de esquiva na direção IsFacingRight
        LeftControlInput = false;
        if (InputSystem.GetKeyDown(KeyCode.LeftControl))
        {
            LeftControlInput = true;
        }
    }
    private void Rules()
    {
        var gravityLapse = 20;

        if (Mouse0Input)
        {
            Rigidbody2D.gravityScale = 0;
            AnimationSystem.SetAnimation("Attack");
            CombatSystem.Attack();
            DashSystem.DashAttack(this);
            GravityLapse(gravityLapse);
        }
        if (LeftControlInput)
        {
            AnimationSystem.SetAnimation("Dash");
            Rigidbody2D.gravityScale = 0;
            DashSystem.DashDodge(this);
            GravityLapse(gravityLapse);
        }
        AnimationSystem.SetAnimation("Speed", Mathf.Abs(Rigidbody2D.velocity.x));
        AnimationSystem.SetAnimation("IsGrounded", GroundCheckSystem.IsTouchingGround);

        //if(IsFacingRight) CombatSystem.transform.eulerAngles = new Vector3(0, 0, 0);
        //else CombatSystem.transform.eulerAngles = new Vector3(0, 180, 0);

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

    private void GravityLapse(int gravityLapse)
    {
        if (Coroutine != null) StopCoroutine(Coroutine);
        Coroutine = GravityLapseCoroutine(gravityLapse);
        StartCoroutine(Coroutine);
    }

    private IEnumerator GravityLapseCoroutine(int gravityLapse)
    {
        while (Rigidbody2D.gravityScale != Constants.Gameplay.GravityScale)
        {
            Rigidbody2D.gravityScale += (Time.deltaTime * gravityLapse);
            if (Rigidbody2D.gravityScale >= Constants.Gameplay.GravityScale)
                Rigidbody2D.gravityScale = Constants.Gameplay.GravityScale;

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    #endregion

    #region Properties
    public bool IsFacingRight { get; private set; }
    //Propriedade de verificação se o character esta virado para direita
    public Rigidbody2D Rigidbody2D { get; private set; }

    //Propriedade de acesso ao componente Rigidbody2D

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
