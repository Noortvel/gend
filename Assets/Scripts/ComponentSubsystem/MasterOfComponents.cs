using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterOfComponents : MonoBehaviour
{
    private List<BaseComponent> components = new List<BaseComponent>();
    public void RegistComponent(BaseComponent component)
    {
        components.Add(component);
    }
    protected void Update()
    {
        foreach(var x in components)
        {
            x.Update();
        }
    }
}
