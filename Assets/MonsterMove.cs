using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{

    //Rigidbody2D rb;
    //public float accelerationTime = 2f;
    //public float maxSpeed = 5f;
    //private Vector2 movement;
    //private float timeLeft;
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;


    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        nextPos = startPos.position;
          
    }

    private void Update()
    {

        if(transform.position == pos1.position){
            nextPos = pos2.position;
        }
        if(transform.position == pos2.position){
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

        //timeLeft -= Time.deltaTime;
        //if(timeLeft <= 0)
        //{
        //    movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        //    if(movement.x * maxSpeed>=54.9f || movement.x * maxSpeed<=-15.36f){
        //        movement = Vector2.zero;
        //    }
        //    timeLeft += accelerationTime;
        //}
        //rb.AddForce(movement * maxSpeed);

    }

    private void onDrawGizmos(){
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    
}
