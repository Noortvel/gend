using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationEventsCatcher : MonoBehaviour
{
    public delegate void FunctionNotify();

    public static event FunctionNotify animationMagic1HCast;
  
    public void Magic1HCast()
    {
        animationMagic1HCast();
    }

   
}
