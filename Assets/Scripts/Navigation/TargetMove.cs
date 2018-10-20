using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class TargetMove : MonoBehaviour {
    bool DebugMode;
    public GameObject DenialPrefab;
    public Camera MainCamera;
    private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Location;

            if (Physics.Raycast(ray, out Location))
            {
                if (Location.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    Debug.DrawRay(transform.position, Location.transform.position - transform.position, Color.white);

                }
                else
                    agent.SetDestination(Location.point);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Location;

            if (Physics.Raycast(ray, out Location))
            {
                Instantiate(DenialPrefab, Location.point, Quaternion.identity);
            }
        }


    }
}
