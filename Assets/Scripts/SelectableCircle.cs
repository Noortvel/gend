using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrownEnd
{
    public class SelectableCircle : SubComponent
    {
        private Character owner;
        private bool isTargeting = false;
        private GameObject circle;
        private GameObject target;
        public SelectableCircle(PlayerController controller, GameObject circlePrefab) : base(controller)
        {
            owner = controller.controlledCharacter;
            circle = MonoBehaviour.Instantiate(circlePrefab, controller.transform.position, controller.transform.rotation);
            circle.SetActive(false);
        }
        public void Targeting(GameObject target)
        {
            this.target = target;
            isTargeting = true;
            circle.transform.position = target.transform.position;
            circle.transform.rotation = target.transform.rotation;
            circle.SetActive(true);

        }
        public void UnTargeting()
        {
            if (isTargeting)
            {
                isTargeting = false;
                circle.SetActive(false);
                this.target = null;
            }

        }
        public override void Update()
        {
            if (isTargeting)
            {
                circle.transform.position = target.transform.position;
                circle.transform.rotation = target.transform.rotation;
            }
        }
    }
}