using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EnemyStagger : Enemy
{
    private int moveTime = 120;
    private int moveCount;
    private bool moving = false;

    // POLYMORPHISM
    protected override void Move()
    {
        if (!moving)
        {
            FindPlayer();
            moving = true;
        }

        transform.Translate(direction / moveTime);
        moveCount++;

        if (moveCount == moveTime)
        {
            moving = false;
            moveCount = 0;
        }
    }
}
