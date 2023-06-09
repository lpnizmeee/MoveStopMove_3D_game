using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Characters : GameUnit
{
    protected float speed;
    protected float rotationSpeed;

    public float attackRange;
    public bool IsMoving { get => isMoving; set => isMoving = value; }
    public bool IsAttack { get => isAttack; set => isAttack = value; }
    public Animator anim;
    public Transform Target;

    private bool isMoving;
    private bool isAttack;
    private string currentAnim;


    private void Update()
    {
        this.CharactersUpdate();
    }

    public Vector3 TargetDirection()
    {
        Vector3 direction = Target.position - this.transform.position;
        direction.y = 0f;
        return direction;
    }

    public void ChangeRotation()
    {     
        Quaternion rotation = Quaternion.LookRotation(TargetDirection());
        this.transform.rotation = rotation;
    }

    public override void OnInit()
    {
        IsMoving = false;
        IsAttack= false;

        speed = 7f;
        this.rotationSpeed = 100f;
        this.attackRange = 5f;
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(currentAnim);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }
    public override void OnDespawn()
    {
        throw new NotImplementedException();
    }

    protected virtual void CharactersUpdate()
    {
        
    }
}
