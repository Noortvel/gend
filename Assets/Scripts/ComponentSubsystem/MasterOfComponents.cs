using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MasterOfComponents : MonoBehaviour
{
    private List<BaseComponent> components = new List<BaseComponent>();
    public void RegistComponent(BaseComponent component)
    {
        components.Add(component);
    }
    private void Update()
    {
        UpdateTick();
        foreach (var x in components)
        {
            x.Update();
        }
    }
    protected abstract void UpdateTick();
    
}
