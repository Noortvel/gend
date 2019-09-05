using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacter : CharacterTask
{
    private bool isRotate = false;
    private Vector3 targetRotation;
    public RotateCharacter(CharacterTaskRunner manager) : base(manager)
    {

    }

    public override void Run()
    {
        throw new System.NotImplementedException();
    }

    public override void Stop()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateTick()
    {
        if (isRotate)
        {
            Vector3 rot = Vector3.Slerp(character.transform.rotation.eulerAngles, targetRotation, 0.1f);
            if (rot.magnitude < 0.1f)
            {
                isRotate = false;
            }
            rot *= Time.deltaTime;
            character.transform.rotation = Quaternion.Euler(rot);
        }
    }
}
