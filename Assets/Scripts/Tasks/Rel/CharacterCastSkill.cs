using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GrownEnd
{

    public class CharacterCastSkill : CharacterTask
    {
        private SkillBase skill;
        public CharacterCastSkill(CharacterTaskRunner manager) : base(manager)
        {
            isNeedUpdate = true;
            isBreakable = false;
        }
        public void SetSkill(SkillBase skill)
        {
            this.skill = skill;
        }
        public override void Run()
        {
            Debug.Log("CharacterCastSkill Run");
            skill.Activate();
            character.currentCastingSkill = skill;

        }

        public override void Stop()
        {
            skill.Interrupt();
            character.currentCastingSkill = null;
            EndTask();
        }

        public override void UpdateTick()
        {
            if (skill.isCasted)
            {
                Stop();
            }
        }
    }
}