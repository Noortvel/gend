using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacterToTargetIsNeed : CharacterTask
{
    public RotateCharacterToTargetIsNeed(CharacterTaskRunner manager) : base(manager)
    {
        isNeedUpdate = true;
    }
    private bool isRotate = false;
    private Vector3 targetRotation = Vector3.zero;
    private float rotationAngle = 0;
    private int rotDirection = 1;
    public override void Run()
    {
        Debug.Log("RotateCharacterToTargetIsNeed");
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
        Debug.Log("rot angle" + angle);
        rotationAngle = Mathf.Abs(angle);
        if (rotationAngle > 90)
        {
            rotDirection = (int)Mathf.Sign(angle);
            isRotate = true;
        }
        else
        {
            EndTask();
        }
    }
    public override void Stop()
    {
        isRotate = false;
        EndTask();
    }
    public override void UpdateTick()
    {
        if (isNeedUpdate && isRotate)
        {
            Vector3 rot = Vector3.zero; //character.transform.rotation.eulerAngles;
            float val = Time.deltaTime * 200;
            rot.y += val * rotDirection;
            rotationAngle -= val;
            
            character.transform.Rotate(rot);
            Debug.Log(rotationAngle);
            if (rotationAngle <= 0)
            {
                Stop();
                return;
            }
        }
    }

    
}
