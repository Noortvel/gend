using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GrownEnd
{

    public class MagicArrow : SkillBase
    {

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
            //InvokeThroughTime
            character.animationsController.Magic1HCastAnimation_Play();
        }

        public override void AnimationNotify()
        {
            Vector3 dt = (character.selectedObject.transform.position - character.rightHandSocket.position);
            float angle = Mathf.Atan2(dt.x, dt.z) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(new Vector3(0, angle, 0));
            _gameObjectInstace = MonoBehaviour.Instantiate(magicArrowProjectile, character.rightHandSocket.position, rot);

            character.animationsController.Magic1HCastAnimation_Stop();
            isCasted = true;

        }

        public override void Initialize(Character character)
        {
            this.character = character;
            AnimationEventsCatcher.animationMagic1HCast += AnimationNotify;

        }

        public override void Interrupt()
        {
            character.animationsController.Magic1HCastAnimation_Stop();
            isCasted = true;

        }
    }
}