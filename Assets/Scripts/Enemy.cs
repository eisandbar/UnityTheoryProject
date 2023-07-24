using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private PlayerController player;
    protected Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    protected void FindPlayer()
    {
        direction = player.position - transform.position;
    }

    protected abstract void Move();
}
