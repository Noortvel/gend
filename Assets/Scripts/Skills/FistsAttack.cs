using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GrownEnd
{

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

        }

        public override void AnimationNotify()
        {
            throw new System.NotImplementedException();
        }

        public override void Initialize(Character character)
        {
            owner = character;

            //cAnimation = controller.GetControlledCharacter()
        }

        public override void Interrupt()
        {
            throw new System.NotImplementedException();
        }
    }
}