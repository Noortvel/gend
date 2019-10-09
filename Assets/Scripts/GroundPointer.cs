using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrownEnd
{

    public class GroundPointer : SubComponent
    {
        private GameObject groundPointers;
        private bool isNeedUpdate = false;
        private float lifeTime = 0.5f;
        private float _lifeTime;
        private Vector3 scaler;
        private Vector3 defaultScale;
        public GroundPointer(PlayerController playerController, GameObject groudPointerPrefab) : base(playerController)
        {
            var location = playerController.controlledCharacter.transform;
            groundPointers = MonoBehaviour.Instantiate(groudPointerPrefab, location.position, location.rotation);
            groundPointers.SetActive(false);
            _lifeTime = lifeTime;
            scaler = new Vector3();
            defaultScale = groudPointerPrefab.transform.localScale;

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
            tpointer.localScale = defaultScale;
            tpointer.gameObject.SetActive(true);
            _lifeTime = lifeTime;
            isNeedUpdate = true;
        }
        public override void Update()
        {
            if (isNeedUpdate)
            {
                if (_lifeTime > 0)
                {
                    float scale = _lifeTime / lifeTime;
                    _lifeTime -= Time.deltaTime;
                    scaler.x = scale;
                    scaler.y = scale;
                    scaler.z = scale;
                    groundPointers.transform.localScale = scaler;
                }
                else
                {
                    groundPointers.SetActive(false);
                    isNeedUpdate = false;
                }
                //var dt = World.GetInstance().Character.transform.position - groundPointers.transform.position;
                //if (dt.magnitude < 0.1f)
                //{
                    
                //}
            }
        }
    }
}