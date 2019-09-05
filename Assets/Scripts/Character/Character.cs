using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum Clan {
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
        if(dt <= 0)
        {
            hp = 0;

        } else
        {
            hp -= dt;
        }
    }
    public void Heal(int hp)
    {
        this.hp += hp;
    }

}

public class Character : MonoBehaviour
{

    private Clan clan;

 






    public CharacterHealthComponent health
    {
        set;
        get;
    }

    [SerializeField]
    private List<SkillBase> _skills;
    public List<SkillBase> skills
    {
        get
        {
            return _skills;
        }
    }
    public Character selectedObject
    {
        get;
        set;
    }

    [SerializeField]
    private Animation _animationMontages;
    public Animation animationMontages
    {
        get { return _animationMontages; }
        private set { _animationMontages = value; }
    }
    [SerializeField]
    private Animator _animator;
    public Animator animator
    {
        get { return _animator; }
        private set { _animator = value; }
    }
    [SerializeField]
    private Transform _leftHandSocket, _rightHandSocket;

    public Transform leftHandSocket
    {
        get { return _leftHandSocket; }
    }
    public Transform rightHandSocket
    {
        get { return _rightHandSocket; }

    }


    public void Awake()
    {
        foreach(var x in skills)
        {
            x.Initialize(this);
        }

    }
    public bool isFriend(Character target)
    {
        return false;
    }
  
}
