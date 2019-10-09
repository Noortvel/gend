using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateScaleToZeroAndDestroy : MonoBehaviour
{
    [SerializeField]
    private float liveTime;
    private float _liveTime;
    private Vector3 scaler;
    private void Start()
    {
        Destroy(gameObject, liveTime);
        scaler = new Vector3();
    }
    // Update is called once per frame
    void Update()
    {
        float scale = _liveTime / liveTime;
        _liveTime -= Time.deltaTime;
        scaler.x = scale;
        scaler.y = scale;
        scaler.z = scale;
        transform.localScale = scaler;
    }
}
