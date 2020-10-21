using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class CombatSystem : MonoBehaviour
{
    public CharacterControllerScript CharacterControllerScript;

    private IEnumerator Coroutine;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var teste = Physics2D.OverlapBoxAll(transform.position + new Vector3(CharacterControllerScript.IsFacingRight ? 1.2f : -1.2f, 0), new Vector3(1, .5f),0);
        foreach(var t in teste)
        {
            Debug.LogError(t.name);
        }

    }

    public void Attack()
    {
        if (!IsAttacking)
        {
            Debug.Log("BeginAttack");
            IsAttacking = true;
            AttackLapse(25);
        }
    }

    private void AttackLapse(float attackWait)
    {
        if (Coroutine != null) StopCoroutine(Coroutine);
        Coroutine = AttackLapseCoroutine(attackWait);
        StartCoroutine(Coroutine);
    }

    private IEnumerator AttackLapseCoroutine(float attackWait)
    {
        yield return new WaitForSeconds(Time.deltaTime * attackWait);
        Debug.Log("EndAttack");
        IsAttacking = false;
    }
    public bool IsAttacking { get; private set; }

    void OnDrawGizmos()
    {        
        //if (IsAttacking)
            Gizmos.DrawWireCube(transform.position + new Vector3(CharacterControllerScript.IsFacingRight ? 1.2f : -1.2f, 0), new Vector3(1, .5f));
    }
}
