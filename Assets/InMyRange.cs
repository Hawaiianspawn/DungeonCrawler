using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMyRange : MonoBehaviour
{
    Enemy ME;
    StateController controller;
    public Collider[] targets;
    public LayerMask Layer;
    

    // Use this for initialization
    void Start()
    {
        ME = GetComponent<Enemy>();
        controller = GetComponent<StateController>();
    }

    // Update is called once per frame
    void Update()
    {
        targets = Physics.OverlapSphere(this.transform.position, ME.AggroRange, 1536);  //Enemy
        foreach (Collider target in targets)
        {
            Vector3 Direction = (target.transform.position - ME.transform.position);
            RaycastHit hit;

            //Shoot out a raycast, if somethings blocking, don't change state
            if (Physics.Raycast(transform.position, Direction, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    Debug.Log("I SEE YOU");
                    Debug.DrawRay(this.transform.position, Direction, Color.white);
                }
                else
                    Debug.DrawRay(this.transform.position, Direction, Color.red);
            }
        }
    }
}

