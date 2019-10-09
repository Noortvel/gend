using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GrownEnd
{

    public abstract class ActiveSkill : MonoBehaviour
    {
        private List<System.Action> endCastCallbacks;
        private List<System.Action> startCastCallbacks;

        public void AddStartCastCallback(System.Action a)
        {
            startCastCallbacks.Add(a);
        }
        public void AddEndCastCallback(System.Action a)
        {
            endCastCallbacks.Add(a);
        }
        protected void EndCastCallbackExecute()
        {
            foreach (var x in endCastCallbacks)
            {
                x();
            }
        }
        protected void StartCastCallbackExecute()
        {
            foreach (var x in startCastCallbacks)
            {
                x();
            }
        }
        protected void ClearStartCastCallbacks()
        {
            startCastCallbacks.Clear();
        }
        protected void ClearEndCastCallbacks()
        {
            endCastCallbacks.Clear();
        }


        [SerializeField]
        protected string diplayName = "None";
        [SerializeField]
        protected string description = "None";
        public bool isCasting
        {
            protected set;
            get;
        }
        public enum SkillEntity
        {
            Item,
            Perc
        }
        [SerializeField]
        protected SkillEntity entity;
        [SerializeField]
        protected float _coolDown = 0;
        [SerializeField]
        protected float _distance = 0;
        public float coolDown
        {
            get { return _coolDown; }
        }
        public float distance
        {
            get { return _distance; }
        }
        protected Character character
        {
            get;
            set;
        }
        public abstract void Activate();
        public abstract void Interrupt();
        protected abstract void AnimationNotify();
        public abstract void Initialize(Character character);
        protected void InitalizeSkillBase()
        {
            startCastCallbacks = new List<System.Action>();
            endCastCallbacks = new List<System.Action>();
        }
    }
}