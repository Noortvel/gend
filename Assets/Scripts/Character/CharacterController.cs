using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

namespace GrownEnd
{


    public enum CharacterActions
    {
        Idle,
        Move,
        Cast,

    }

    public class CharacterController : MonoBehaviour
    {

        private Character character;

        private CharacterTaskRunner taskRunner;
        private ChararcterTaskCreator taskCreator;




        public void Awake()
        {

            character = GetComponent<Character>();
            taskRunner = new CharacterTaskRunner(character);
            taskCreator = new ChararcterTaskCreator(taskRunner);



        }
        public void RotateToSelectedObject()
        {

        }
        public void RotateToTargetIsNeed()
        {

            taskRunner.RunTaskImmediately(taskCreator.RotateIsNeedTask());
        }
        public void MoveTo(Vector3 position)
        {
            taskRunner.RunTaskImmediately(taskCreator.MoveToTask(position));
        }
        public bool isTargetInSeeSector()
        {
            if (character.selectedObject == null)
            {
                return false;
            }
            Vector3 dt = (character.selectedObject.transform.position - character.transform.position);
            float vm = Vector3.Dot(character.transform.forward, dt);

            return vm > 0 ? true : false;
        }
        public void PickItem()
        {
            if (character.selectedObject.tag == "Item")
            {
                //TODO:PickItem
            }
        }

        public void CastSkill(SkillBase skill)
        {
            print("Cast skill " + skill);
            print("Current casted skill " + character.currentCastingSkill);
            print("Is Equal " + (skill == character.currentCastingSkill));
            if (character.currentCastingSkill != skill)
            {
                PreapareToSkill(skill);
            }
        }
        public void PreapareToSkill(SkillBase skill)
        {
            //print(character);
            //print(character.selectedObject);
            if (character.selectedObject == null)
            {
                return;
            }

            if (taskRunner.CoutTask != 0)
            {
                taskRunner.BreakQueue();
            }

            Vector3 dt = character.selectedObject.transform.position - character.transform.position;
            float sdt = skill.distance / dt.magnitude;
            if (sdt < 1)
            {
                Vector3 dest = ((1 - sdt) * dt) + character.transform.position;
                taskRunner.AddTask(taskCreator.MoveToTask(dest));
            }
            taskRunner.AddTask(taskCreator.RotateIsNeedTask());
            taskRunner.AddTask(taskCreator.CastSkillTask(skill));
            taskRunner.RunQueue();
        }
        public void Update()
        {
            taskRunner.Update();
        }
    }
}