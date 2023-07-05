using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;

    private int currentHealth;
    private Knockback knockBack;
    private Flash flash;

    private void Awake() 
    {
        flash = GetComponent<Flash>();
        knockBack = GetComponent<Knockback>();    
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Debug.Log(currentHealth);
        knockBack.GetKnockBack(PlayerController.Instance.transform, 15f);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeath());
    }

    private IEnumerator CheckDetectDeath()
    {
        yield return new WaitForSeconds(flash.GetRetoreMatTime());
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
