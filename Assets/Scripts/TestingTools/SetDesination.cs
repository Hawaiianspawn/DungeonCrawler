﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetDesination : MonoBehaviour {
    public Transform target;
	// Use this for initialization
	void Start () {
        GetComponent<NavMeshAgent>().SetDestination(target.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
