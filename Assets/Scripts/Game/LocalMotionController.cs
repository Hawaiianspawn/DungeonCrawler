using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LocalMotionController : MonoBehaviour {
    public Animator Anim;
    public NavMeshAgent Agent;
    private float speed;
    private float maxSpeed;

	// Use this for initialization
	void Start () {
        if(!Anim)
            Anim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        maxSpeed = Agent.speed;
        
	}
	
	// Update is called once per frame
	void Update () {
        UpdateParameters();
    }
    public void UpdateParameters()
    {
        Anim.SetFloat("Speed", (Agent.velocity.magnitude / maxSpeed));
    }
}
