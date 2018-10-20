using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScript : MonoBehaviour {

    Camera Self;
    bool Held;
	// Use this for initialization
	void Start() {
        Self = GetComponent<Camera>();
	}
    void Awake()
    {
        Self = GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update () {
		
	}

    private void OnMouseDrag()
    { 
    }


   
    void OnDrawGizmos()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Held = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Held = false;
        }

        if (Held)
        {
            RaycastHit Location;
            Ray ray = Self.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out Location))
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(Location.point, 1);
            }
        }
    }

}
