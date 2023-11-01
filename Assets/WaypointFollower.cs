using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaypointFollower : MonoBehaviour{

    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private SpriteRenderer sprite;

    void Start(){

        sprite = GetComponent<SpriteRenderer>();
    }

    [SerializeField] private float speed = 2f;

    private void Update(){
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f){
            currentWaypointIndex++;
            if(currentWaypointIndex > waypoints.Length - 1){
                currentWaypointIndex = 0;
            }
            if(!sprite.flipX) sprite.flipX = true;
            else sprite.flipX = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
