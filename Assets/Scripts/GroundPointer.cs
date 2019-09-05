using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPointer : BaseComponent
{
    public GameObject groundPointers;
    private bool isNeedUpdate = false;
    public GroundPointer(PlayerController playerController, GameObject groudPointerPrefab) : base(playerController)
    {
        var location = playerController.controlledCharacter.transform;
        groundPointers = MonoBehaviour.Instantiate(groudPointerPrefab, location.position, location.rotation);
        groundPointers.SetActive(false);

    }
    public void Click(RaycastHit info)
    {
        Vector3 impnorm = info.normal.normalized;
        //ПО ВЕКТОРУ НОРМАЛИ НЕЛЬЗЯ НАЙТИ ВРАЩЕНИЕ ВДОЛЬ НЕГО, ТЕ ВРАЩЕНИЕ ПО UP(Y)
        float oxrot = Mathf.Atan2(impnorm.z, impnorm.y) * Mathf.Rad2Deg;
        float ozrot = Mathf.Atan2(-impnorm.x, impnorm.y) * Mathf.Rad2Deg;
        Vector3 rot = new Vector3(oxrot, 0, ozrot);
        var qrot = Quaternion.Euler(rot);

        var tpointer = groundPointers.transform;
        tpointer.position = info.point;
        tpointer.rotation = qrot;
        tpointer.gameObject.SetActive(true);
        isNeedUpdate = true;
    }
    public override void Update()
    {
        if (isNeedUpdate)
        {
            var dt = World.GetInstance().Character.transform.position - groundPointers.transform.position;
            if (dt.magnitude < 0.1f)
            {
                groundPointers.SetActive(false);
                isNeedUpdate = false;
            }
        }
    }
}
