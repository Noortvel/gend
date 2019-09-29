using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GrownEnd
{

    public class SkillsSlots : SubComponent
    {
        private struct SkillMap
        {
            public SkillBase skill;
            public KeyCode key;
        }
        private PlayerController playerController;
        private List<SkillMap> skillMap;
        public SkillsSlots(PlayerController controller) : base(controller)
        {
            skillMap = new List<SkillMap>();
            playerController = controller;
        }
        public void AddSkill(SkillBase skill, KeyCode key)
        {
            var t = new SkillMap();
            t.skill = skill;
            t.key = key;
            skillMap.Add(t);
        }
        public void RemoveSkill(SkillBase skill)
        {
            foreach (var x in skillMap)
            {
                if (x.skill == skill)
                {
                    skillMap.Remove(x);
                }
            }
        }
        public override void Update()
        {
            foreach (var x in skillMap)
            {
                if (Input.GetKeyDown(x.key))
                {
                    playerController.characterController.CastSkill(x.skill);
                }
            }
        }
    }
}