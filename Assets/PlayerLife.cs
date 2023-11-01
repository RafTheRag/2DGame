using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private Health playerHealth;

    [SerializeField] private AudioSource deathSoundEffect;
    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void update(){
        if(playerHealth.getHealth() <= 0 && !PlayerMovement.god){
            Die();
        }

        if(Input.GetKeyDown("r")){
            RestartLevel();
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Trap") && !PlayerMovement.god){
            Die();
        }
    }

    private void Die(){
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }

    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
