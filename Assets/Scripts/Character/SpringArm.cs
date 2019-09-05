using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringArm : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform _target;
    public Transform target
    {
        get { return _target; }
        set { _target = value; }
    }
    private Vector3 offset;
    //Start On Character
    void Start()
    {
        //target = transform.parent;
        //offset = transform.localPosition;
        //transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
