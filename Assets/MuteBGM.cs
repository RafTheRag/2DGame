using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteBGM : MonoBehaviour
{
    [SerializeField] private AudioSource BGM;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("m") && !muted){
            muted = true;
            BGM.Stop();
        }
        else if(Input.GetKeyDown("m") && muted){
            muted = false;
            BGM.Play();
        }
    }
}
