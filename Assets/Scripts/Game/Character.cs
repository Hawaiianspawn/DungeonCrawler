using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour {
    [SerializeField]
    public enum RoleType { Tank, DPSMelee, DPSRanged, Healer }

    [SerializeField]
    public enum EnemyType { Trash, Contender,Boss}

    public int Level;              //From Level 1 to 100 - I do not have the base stats for 120 
    public int HP;              //Health that is percieved
    protected int MaxHP;
    protected int MP;           //Mana
    protected int MaxMP;
    public int Primary;         //Primary stat
    public float AttackRange;

    [HideInInspector] public Animator Anim;
    [HideInInspector] public NavMeshAgent Agent;
    [HideInInspector] public int Stamina;
    [HideInInspector] public int Strength;
    [HideInInspector] public int Agility;
    [HideInInspector] public int Intellect;
    [HideInInspector] public float AttackRate = 1f;
    public int Damage;

    private float Cooldown;
    public bool ActionReady;

    private float MoveCooldown;
    public bool CanMove;

    private float speed;
    private float maxSpeed;
    private float time;


    public void Awake()
    {
        Anim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        maxSpeed = Agent.speed;
    }
    public void Attack(Character Target, int Value)
    {
        if (ActionReady)
        {
            Anim.Play("Attack");
            Target.Hit(Value);
            Cooldown = 1.5f;
            MoveCooldown = 1.5f;
            ActionReady = false;
        }

    }

    public bool IsReady()
    {
        if (ActionReady)
            return true;
        else
            return false; 
    }
    public void Hit(int Value)
    {
        Anim.Play("Hit");
        HP -= Value;
    }

    public void FixedUpdate()
    {

        if (ActionReady)
            UpdateAnimation();       

        time = Time.deltaTime;

        if (Cooldown > 0f)
            Cooldown -= time;
        if (MoveCooldown > 0f)
            MoveCooldown -= time;


        if(Cooldown <= 0)
            ActionReady = true;
        if (MoveCooldown <= 0)
            CanMove = true;

    }
    public void UpdateAnimation()
    {
        Anim.SetFloat("Speed", (Agent.velocity.magnitude / maxSpeed));
        //Debug.Log("Current Speed of" + this.name + "is " + (Agent.velocity.magnitude / maxSpeed));
    }
}
