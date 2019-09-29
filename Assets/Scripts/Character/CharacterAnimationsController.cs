using UnityEngine;
using UnityEngine.AI;
namespace GrownEnd
{

    [RequireComponent(typeof(Character))]
    public class CharacterAnimationsController : MonoBehaviour
    {
        private NavMeshAgent movement;
        private Character character;
        [SerializeField]
        private Animator _animator;
        public Animator animator
        {
            get { return _animator; }
        }
        private void Awake()
        {
            character = GetComponent<Character>();
            movement = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            float speedRatio = movement.velocity.magnitude / movement.speed;
            _animator.SetFloat("SpeedRatio", speedRatio);
        }
        public void SetType(Character.CharacterType type)
        {
            if (type == Character.CharacterType.Magic)
            {
                _animator.SetBool("isMagic", true);
            }
            if (type == Character.CharacterType.Archer)
            {
                _animator.SetBool("isArcher", true);
            }
        }
        public void Magic1HCastAnimation_Play()
        {
            _animator.SetBool("isMagic1HAttack01", true);
        }
        public void Magic1HCastAnimation_Stop()
        {
            _animator.SetBool("isMagic1HAttack01", false);
        }
    }
}
