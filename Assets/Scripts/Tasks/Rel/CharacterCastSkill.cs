using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GrownEnd
{

    public class CharacterCastSkill : CharacterTask
    {
        private ActiveSkill skill;
        public CharacterCastSkill(CharacterTaskRunner manager) : base(manager)
        {
            isNeedUpdate = false;
            isBreakable = true;
        }
        public void SetSkill(ActiveSkill skill)
        {
            this.skill = skill;
        }
        public override void Run()
        {
            skill.Activate();
            skill.AddEndCastCallback(EndCast);
            character.currentCastingSkill = skill;
        }
        private void EndCast()
        {
            character.currentCastingSkill = null;
            EndTask();
        }
        public override void Interupt()
        {
            skill.Interrupt();
        }
        public override void UpdateTick()
        {
          
        }
    }
}