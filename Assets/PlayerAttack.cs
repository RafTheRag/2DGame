using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private Rigidbody2D rb;
    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Swipe();
        }
        
        if(Input.GetMouseButtonDown(1)){
            Slash();
        }

        if(attacking){
            timer += Time.deltaTime;

            if(timer >= timeToAttack){
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Swipe(){
        attacking = true;
        attackArea.SetActive(attacking);
    }

    private void Slash(){
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
