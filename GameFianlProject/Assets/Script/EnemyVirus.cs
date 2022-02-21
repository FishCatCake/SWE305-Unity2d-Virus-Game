using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyVirus : Enemy
{
    public float speed;

    public float startWaitTime;

    private float waitTime;

    public Transform movePos;

    public Transform leftDownPos;

    public Transform rightUpPos;

    //public int damage;
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        movePos.position = GetRandomPosition();
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position,
            target: movePos.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPosition();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    Vector2 GetRandomPosition()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x),
            Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }
    
}
