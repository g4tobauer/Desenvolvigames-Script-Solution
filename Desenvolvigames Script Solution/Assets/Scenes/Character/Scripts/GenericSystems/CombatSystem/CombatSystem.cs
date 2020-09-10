using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class CombatSystem : MonoBehaviour
{
    public CharacterControllerScript CharacterControllerScript;

    private Collider2D RangeAttack;
    private IEnumerator Coroutine;

    // Start is called before the first frame update
    void Start()
    {
        RangeAttack = GetComponent<Collider2D>();
        RangeAttack.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        if (!IsAttacking)
        {
            Debug.Log("BeginAttack");
            IsAttacking = true;
            GravityLapse(3);
        }
    }
    
    private void GravityLapse(float attackWait)
    {
        if (Coroutine != null) StopCoroutine(Coroutine);
        Coroutine = AttackLapseCoroutine(attackWait);
        StartCoroutine(Coroutine);
    }

    private IEnumerator AttackLapseCoroutine(float attackWait)
    {
        var loop = true;
        while (loop)
        {
            loop = false;
            yield return new WaitForSeconds(attackWait);
        }
        Debug.Log("EndAttack");
        IsAttacking = false;
    }
    private bool IsAttacking { get; set; }
}
