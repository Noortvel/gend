using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicArrow : SkillBase
{
    private Character owner;

    [SerializeField]
    private int damage;
    [SerializeField]
    private GameObject magicArrowProjectile;
    private GameObject _gameObjectInstace;

    [SerializeField]
    private AnimationClip castAnimation;

    public override void Activate()
    {
        print("Activate");
        isCasted = false;
        owner.animator.SetBool("isMagic1HCast", true);


    }

    public override void AnimationNotify()
    {
        Vector3 dt = (owner.selectedObject.transform.position - owner.rightHandSocket.position);
        float angle = Mathf.Atan2(dt.x, dt.z) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(new Vector3(0, angle, 0));
        _gameObjectInstace = MonoBehaviour.Instantiate(magicArrowProjectile, owner.rightHandSocket.position, rot);
        owner.animator.SetBool("isMagic1HCast", false);
        isCasted = true;

    }

    public override void Initialize(Character character)
    {
        owner = character;
        //owner.animationMontages.clip = castAnimation;
        //"MagicArrowCast"

        
        AnimationEventsCatcher.animationMagic1HCast += AnimationNotify;
        //owner.animator.SetBool("characterTasks", true);



    }
}
