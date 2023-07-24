using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyHoming : Enemy
{
    private float speed = 5f;
    protected override void Move()
    {
        base.FindPlayer();
        transform.Translate(direction.normalized * Time.deltaTime * speed);
    }
}
