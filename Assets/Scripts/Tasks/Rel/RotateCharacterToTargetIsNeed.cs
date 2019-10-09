using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GrownEnd
{

    public class RotateCharacterToTargetIsNeed : CharacterTask
    {
        public RotateCharacterToTargetIsNeed(CharacterTaskRunner manager) : base(manager)
        {
            isNeedUpdate = true;
            isBreakable = true;
        }
        private bool isRotate = false;
        private Vector3 targetRotation = Vector3.zero;
        private float rotationAngle = 0;
        private int rotDirection = 1;
        public override void Run()
        {
            if (character.selectedObject == null)
            {
                EndTask();
                return;
            }
            Vector3 dt = (character.selectedObject.transform.position - character.transform.position);
            Vector3 fwd = character.transform.forward;
            //fwd.y = 0;
            //dt.y = 0;
            float angle = -Vector3.SignedAngle(dt, fwd, Vector3.up); ;//Mathf.Atan2(dt.x, dt.z) * Mathf.Rad2Deg;
            rotationAngle = Mathf.Abs(angle);
            if (rotationAngle > 3)
            {
                rotDirection = (int)Mathf.Sign(angle);
                isRotate = true;
            }
            else
            {
                EndTask();
            }
        }
        public override void Interupt()
        {
            isRotate = false;
            EndTask();
        }
        public override void UpdateTick()
        {
            if (isNeedUpdate && isRotate)
            {
                Vector3 rot = character.transform.eulerAngles;
                float val = Time.deltaTime * character.angularSpeed;
                rot.y += (val * rotDirection);
                rotationAngle -= val;
                character.transform.rotation = Quaternion.Euler(rot);
                if (rotationAngle <= 0)
                {
                    Interupt();
                    return;
                }
            }
        }
    }
}