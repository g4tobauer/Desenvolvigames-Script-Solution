using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSystem : MonoBehaviour
{
    #region Fields
    public CharacterControllerScript CharacterControllerScript;

    private Animator Animator;
    private SpriteRenderer SpriteRenderer;

    private float prevSpeed;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        SpriteRenderer.flipX = !CharacterControllerScript.IsFacingRight;
    }

    public void PauseAnimation()
    {
        if (Animator.speed != 0) prevSpeed = Animator.speed;
        Animator.speed = 0;
    }
    public void ResumeAnimation()
    {
        Animator.speed = prevSpeed;
    }

    public void SetAnimation(string trigger)
    {
        Animator.SetTrigger(trigger);
    }
    public void SetAnimation(string name, bool value)
    {
        Animator.SetBool(name, value);
    }
    public void SetAnimation(string name, int value)
    {
        Animator.SetInteger(name, value);
    }
    public void SetAnimation(string name, float value)
    {
        Animator.SetFloat(name, value);
    }

    #region Actions Events
    public void Attack()
    {
        CharacterControllerScript.CombatSystem.Attack();
        CharacterControllerScript.DashSystem.DashAttack(CharacterControllerScript);
    }

    public void Dodge()
    {
        CharacterControllerScript.DashSystem.DashDodge(CharacterControllerScript);
    }
    #endregion
}
