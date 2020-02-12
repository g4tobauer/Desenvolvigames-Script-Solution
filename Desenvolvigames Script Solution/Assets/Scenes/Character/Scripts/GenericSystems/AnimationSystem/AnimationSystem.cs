using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSystem : MonoBehaviour
{
    #region Fields
    public CharacterControllerScript CharacterControllerScript;

    private Animator Animator;
    private SpriteRenderer SpriteRenderer;
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
}
