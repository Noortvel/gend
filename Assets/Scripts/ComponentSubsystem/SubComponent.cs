using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GrownEnd
{
    public abstract class SubComponent
    {
        public SubComponent(MasterOfComponents master)
        {
            master.RegistComponent(this);
        }
        public abstract void Update();

    }
}