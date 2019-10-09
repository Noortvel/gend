using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GrownEnd
{

    public class CharacterTaskRunner
    {
        private Queue<CharacterTask> characterTasks;
        private CharacterTask currentRunnable;
        private bool isUpdateTick = false;
        public Character character
        {
            get;
            private set;
        }
        public int CoutTask
        {
            get { return characterTasks.Count; }
        }

        public CharacterTaskRunner(Character character)
        {
            this.character = character;
            characterTasks = new Queue<CharacterTask>();
        }
        public void AddTask(CharacterTask task)
        {
            characterTasks.Enqueue(task);
        }
        public void RunTaskImmediately(CharacterTask task)
        {
            BreakQueue();
            currentRunnable = task;
            currentRunnable.Run();
            isUpdateTick = true;
        }
        public void BreakQueue()
        {
            isUpdateTick = false;
            characterTasks.Clear();
            if (currentRunnable != null)
            {
                currentRunnable.Interupt();
            }
            currentRunnable = null;
            
        }
        public void RunQueue()
        {
            if (currentRunnable != null)
            {
                currentRunnable.Interupt();
                isUpdateTick = true;
                return;
            }
            //Debug.Log("Run Queue, size: " + characterTasks.Count + "tasks: ");
            //foreach (var x in characterTasks)
            //{
            //    Debug.Log(x);
            //}
            currentRunnable = characterTasks.Dequeue();
            currentRunnable.Run();
            isUpdateTick = true;
        }
        public void Update()
        {
            if (isUpdateTick)
            {
                if (currentRunnable.isNeedUpdate)
                {
                    currentRunnable.UpdateTick();
                }
            }
        }
        public void TaskEndJob(CharacterTask task)
        {
            //Debug.Log("Task End: " + task + "Queue size: " + characterTasks.Count);
            if (characterTasks.Count > 0)
            {
                currentRunnable = characterTasks.Dequeue();
                currentRunnable.Run();
            }
            else if (isUpdateTick)
            {
                isUpdateTick = false;
                currentRunnable = null;
            }
        }
    }
}