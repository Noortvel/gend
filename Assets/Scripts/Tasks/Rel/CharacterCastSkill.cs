using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCastSkill : CharacterTask
{
    private SkillBase skill;
    public CharacterCastSkill(CharacterTaskRunner manager) : base(manager)
    {
        isNeedUpdate = true;
    }
    public void SetSkill(SkillBase skill)
    {
        this.skill = skill;
    }
    public override void Run()
    {
        Debug.Log("CharacterCastSkill Run");
        skill.Activate();
    }

    public override void Stop()
    {
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
