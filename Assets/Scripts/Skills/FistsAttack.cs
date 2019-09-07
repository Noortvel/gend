using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistsAttack : SkillBase
{
    [SerializeField]
    private AnimationClip l1, r1;
    [SerializeField]
    private int baseDamage;
    [SerializeField]
    private float scalePerStraight;
   
    private Character owner;


    private Animation cAnimation;

    private bool LeftRightPunch = false;
    public override void Activate()
    {
        if (LeftRightPunch)
        {
            owner.animationMontages.Play("PunchL1");
        }
        else
        {
            owner.animationMontages.Play("PunchR1");
        }
        LeftRightPunch = !LeftRightPunch;
    }

    public override void AnimationNotify()
    {
        throw new System.NotImplementedException();
    }

    public override void Initialize(Character character)
    {
        owner = character;
        owner.animationMontages.AddClip(l1, "PunchL1");
        owner.animationMontages.AddClip(r1, "PunchR1");
        //cAnimation = controller.GetControlledCharacter()
    }

    public override void Interrupt()
    {
        throw new System.NotImplementedException();
    }
}
