using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(currentRunnable != null)
        {
            currentRunnable.Stop();
        }
        currentRunnable = null;
        characterTasks.Clear();
    }
    public void RunQueue()
    {
        Debug.Log("Run Queue");
        foreach(var x in characterTasks)
        {
            Debug.Log(x);
        }
        Debug.Log("Queue Size: " + characterTasks.Count);

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


        Debug.Log("Task End: " + task);
        Debug.Log("Queue size: " + characterTasks.Count);

        if (characterTasks.Count > 0)
        {

            currentRunnable = characterTasks.Dequeue();
            currentRunnable.Run();
            //Debug.Log("Task ended: " + (t == task));
        }
        else if(isUpdateTick)
        {
            isUpdateTick = false;
            currentRunnable = null;
        }
    }


}
