using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseComponent 
{
    public BaseComponent(MasterOfComponents master)
    {
        master.RegistComponent(this);
    }
    public abstract void Update();

}
