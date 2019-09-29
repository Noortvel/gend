using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrownEnd { 

/// <summary>
/// Light sub update system on top MonoBehaviour,
/// Calls BaseComponentUpdate
/// </summary>
public abstract class MasterOfComponents : MonoBehaviour
{
    private List<SubComponent> components = new List<SubComponent>();

    /// <summary>
    /// Add to update list base component
    /// </summary>
    /// <param name="component"></param>
    public void RegistComponent(SubComponent component)
    {
        components.Add(component);
    }
    private void Update()
    {
        UpdateTickMaster();
        foreach (var x in components)
        {
            x.Update();
        }
    }
    /// <summary>
    /// Dont write Update, it use in base class to update SubComponent
    /// </summary>
    protected abstract void UpdateTickMaster();
    }
}
