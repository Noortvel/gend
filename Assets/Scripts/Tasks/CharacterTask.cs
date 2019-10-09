using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GrownEnd
{

    public abstract class CharacterTask
    {
        protected CharacterTask(CharacterTaskRunner manager)
        {
            this.characterTaskManager = manager;
            character = characterTaskManager.character;
        }
        protected CharacterTaskRunner characterTaskManager
        {
            get;
            set;
        }
        protected Character character
        {
            get;
            set;
        }
        public bool isNeedUpdate
        {
            get;
            set;
        }
        public bool isBreakable
        {
            protected set;
            get;
        }
        public abstract void Run();
        public abstract void UpdateTick();
        public abstract void Interupt();
        protected void EndTask()
        {
            characterTaskManager.TaskEndJob(this);
        }
    }
}