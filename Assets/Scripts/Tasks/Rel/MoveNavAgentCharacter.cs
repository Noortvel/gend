using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace GrownEnd
{

    public class MoveNavAgentCharacter : CharacterTask
    {
        private NavMeshAgent navMesh;
        private Vector3 location = Vector3.zero;
        private bool _isMoveStart = false;
        public MoveNavAgentCharacter(CharacterTaskRunner manager) : base(manager)
        {
            navMesh = manager.character.GetComponent<NavMeshAgent>();
            isNeedUpdate = true;
            isBreakable = true;
        }
        public void SetDestanation(Vector3 location)
        {
            this.location = location;
        }
        public override void Run()
        {
            navMesh.updateRotation = true;
            navMesh.SetDestination(location);
            navMesh.isStopped = false;
            _isMoveStart = true;
        }
        private float eps = 0.2f;

        public override void UpdateTick()
        {
            if (isNeedUpdate && _isMoveStart && (navMesh.destination - character.transform.position).magnitude < eps)
            {
                Interupt();
            }
        }

        public override void Interupt()
        {
            _isMoveStart = false;
            navMesh.isStopped = true;
            navMesh.updateRotation = false;
            navMesh.SetDestination(character.transform.position);
            location = Vector3.zero;
            EndTask();
        }
    }
}