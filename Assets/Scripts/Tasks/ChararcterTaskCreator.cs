﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GrownEnd
{

    public class ChararcterTaskCreator
    {
        private CharacterTaskRunner runner;
        public ChararcterTaskCreator(CharacterTaskRunner runner)
        {
            this.runner = runner;
        }
        public MoveNavAgentCharacter MoveToTask(Vector3 position)
        {
            var obj = new MoveNavAgentCharacter(runner);
            obj.SetDestanation(position);
            return obj;
        }
        public RotateCharacterToTargetIsNeed RotateIsNeedTask()
        {
            var obj = new RotateCharacterToTargetIsNeed(runner);
            return obj;
        }
        public CharacterCastSkill CastSkillTask(ActiveSkill skill)
        {
            var obj = new CharacterCastSkill(runner);
            obj.SetSkill(skill);
            return obj;
        }
    }
}