using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimationsController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private NavMeshAgent movement;

    void Start()
    {
        movement = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        float speedRatio = movement.velocity.magnitude / movement.speed;
        animator.SetFloat("SpeedRatio", speedRatio);
    }
    public void SetType(Character.CharacterType type)
    {
        if (type == Character.CharacterType.Magic)
        {
            animator.SetBool("isMagic", true);
        }
        if(type == Character.CharacterType.Archer)
        {
            animator.SetBool("isArcher", true);
        }
    }
    public void Magic1HCastAnimation_Play()
    {
        animator.SetBool("isMagic1HCast", true);
    }
    public void Magic1HCastAnimation_Stop()
    {
        animator.SetBool("isMagic1HCast", false);
    }
}
