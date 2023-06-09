﻿using System.Runtime.ExceptionServices;
using UnityEngine;


public class Weapon : GameUnit
{   

    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isFire;

    public Vector3 direction;
    public bool IsFire { get => isFire; set => isFire = value; }

    private float timeSelfDestroy;

    private void Update()
    {
        SelfDestroy();

        MoveToTargetStraight();
    }

    public void SetDirection(Vector3 dir) 
    {
        direction = dir;
        IsFire = true;
    }

    public void MoveToTargetStraight()
    {
        if (IsFire)
        {
            transform.Translate(this.direction.normalized * this.moveSpeed * Time.deltaTime);
           
        }
    }  

    public override void OnDespawn()
    {
        this.IsFire = false;

        SimplePool.Despawn(this);
    }

    public void SetTimeDestroy(float attackRange)
    {
        this.timeSelfDestroy = attackRange / moveSpeed;
    }

    public override void OnInit()
    {
        this.IsFire = false;

        moveSpeed = 4.5f;

        this.timeSelfDestroy = 10f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            this.OnDespawn();
        }
    }

    private void SelfDestroy()
    {
        timeSelfDestroy -= Time.deltaTime;
        if (timeSelfDestroy > 0) return;

        this.OnDespawn();
    }
}
