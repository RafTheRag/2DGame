using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.CompareTag("Enemy") && health <= 0){
            Destroy(gameObject);
        }
    }

    public void Damage(int amount){

        health -= Math.Abs(amount);
    }

    public int getHealth(){
        return health;
    }

    public void setHealth(int health){
        this.health = health;
    }
}
