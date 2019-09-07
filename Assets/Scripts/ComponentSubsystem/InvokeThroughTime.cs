using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InvokeThroughTime : MonoBehaviour
{
    private class PairActionFloat
    {
        public Action action;
        public float time;
    }
    private static List<PairActionFloat> invokens = new List<PairActionFloat>();

    public static void Invoke(Action cb, float time)
    {
        invokens.Add(new PairActionFloat{ action = cb, time = time});
    }

    // Update is called once per frame
    void Update()
    {
        if (invokens.Count > 0)
        {
            for (int i = 0; i < invokens.Count; i++)
            {

                invokens[i].time -= Time.deltaTime;
                if (invokens[i].time < 0)
                {
                    invokens[i].action();
                    invokens.RemoveAt(i);
                }
            }
        }
    }
}
