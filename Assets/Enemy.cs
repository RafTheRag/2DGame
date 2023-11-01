using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    private SpriteRenderer sprite;
    private Color realColor;

    void Start(){
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
        realColor = sprite.color;
    }
    public void TakeDamage(int damage){
        currentHealth -= damage;
        sprite.color = Color.red;
        if(currentHealth <= 0){
            Die();
        }
        StartCoroutine(WaitHalfSecondCoroutine());
    }

    void Die(){
        Destroy(gameObject);
    }

     private IEnumerator WaitHalfSecondCoroutine()
    {
        yield return new WaitForSeconds(0.5f); 

        sprite.color = realColor;
    }
}
