using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



namespace GrownEnd
{

    public enum Clan
    {
        Light, Dark
    }
    public class CharacterHealthComponent
    {
        private Character character;
        private int hp
        {
            set;
            get;
        }
        public CharacterHealthComponent(Character character)
        {
            this.character = character;
        }
        public void ApplyDamage(int damage)
        {
            int dt = hp - damage;
            if (dt <= 0)
            {
                hp = 0;

            }
            else
            {
                hp -= dt;
            }
        }
        public void Heal(int hp)
        {
            this.hp += hp;
        }

    }
    /// <summary>
    /// Main class for characters
    /// </summary>
    public class Character : MonoBehaviour
    {

        private Clan clan;
        /// <summary>
        /// Type of character for select animation state, IN FUTURE WILL BE REMAKED
        /// </summary>
        public enum CharacterType
        {
            Empty,
            Magic,
            Archer
        }

        [SerializeField]
        private CharacterType characterType;
        /// <summary>
        /// Health system propery
        /// </summary>
        public CharacterHealthComponent health
        {
            set;
            get;
        }

        [SerializeField]
        private List<ActiveSkill> _skills;
        /// <summary>
        /// Skill list propery propery
        /// </summary>
        public List<ActiveSkill> skills
        {
            get
            {
                return _skills;
            }
        }
        /// <summary>
        /// Сharacter that is selected from raycast from player controller
        /// </summary>
        public Character selectedObject
        {
            get;
            set;
        }
        /// <summary>
        /// Current casted skill
        /// </summary>
        public ActiveSkill currentCastingSkill
        {
            get;
            set;
        }
        /// <summary>
        /// AngularSpeed, follow from navmesh
        /// </summary>
        public float angularSpeed
        {
            get { return navMesh.angularSpeed; }
        }
        /// <summary>
        /// Animator
        /// </summary>
        public Animator animator
        {
            get;
            set;
        }
        [SerializeField]
        private Transform _leftHandSocket, _rightHandSocket;

        /// <summary>
        /// Transform left hand socket on skeleton
        /// </summary>
        public Transform leftHandSocket
        {
            get { return _leftHandSocket; }
        }
        /// <summary>
        /// Transform right hand socket on skeleton
        /// </summary>
        public Transform rightHandSocket
        {
            get { return _rightHandSocket; }

        }
        /// <summary>
        /// CharacterAnimationsController prop 
        /// </summary>
        public CharacterAnimationsController animationsController
        {
            private set;
            get;
        }
        private NavMeshAgent navMesh;
        private void Awake()
        {
            navMesh = GetComponent<NavMeshAgent>();
            animationsController = GetComponent<CharacterAnimationsController>();
            if (animationsController != null)
            {
                animationsController.SetType(characterType);
                animator = animationsController.animator;
            }
            foreach (var x in skills)
            {
                x.Initialize(this);
            }
        }

    }
}