using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GrownEnd
{

    public abstract class SkillBase : MonoBehaviour
    {
        [SerializeField]
        protected string diplayName = "None";
        [SerializeField]
        protected string description = "None";
        [SerializeField]
        protected Texture2D icon = null;

        public bool isCasted
        {
            protected set;
            get;
        }

        public enum SkillType
        {
            None,
            Active,
            Passive,
            AutoCast

        }
        public enum SkillEntity
        {
            None,
            Item,
            Perc
        }

        [SerializeField]
        protected SkillType type = SkillType.None;
        [SerializeField]
        protected SkillEntity entity = SkillEntity.None;
        [SerializeField]
        protected float _coolDown = 0;
        [SerializeField]
        protected float _distance = 0;

        public float coolDown
        {
            get { return _coolDown; }
        }
        public bool isReadyToCast
        {
            protected set;
            get;
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
        protected void SetCastingStatus()
        {

        }
        public abstract void Activate();
        public abstract void Interrupt();
        public abstract void AnimationNotify();
        public abstract void Initialize(Character character);


    }
}