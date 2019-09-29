using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GrownEnd
{

    /// <summary>
    /// Animation catcher, metods called from animations, and events handle notify to retranslate
    /// </summary>
    public class AnimationEventsCatcher : MonoBehaviour
    {
        /// <summary>
        /// Delegate to get callback from animation evenet`s
        /// </summary>
        public delegate void FunctionNotify();

        /// <summary>
        /// Event callbe when appropriate event called from animation.
        /// </summary>
        public static event FunctionNotify animationMagic1HCast;
        /// <summary>
        /// Dont call youself, need called only from animation
        /// </summary>
        public void Magic1HCast()
        {
            animationMagic1HCast();
        }


    }
}