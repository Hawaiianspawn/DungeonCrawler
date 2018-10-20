using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//How wow calculates their damage. 
//(Weapon Damage + Attack Power / 3.5 * Normalized Weapon Speed) * Coefficient* Damage

[ExecuteInEditMode]
public class Enemy : Character {
    [HideInInspector] public StateController controller;
    public EnemyType Type;
    public enum EnemyNavType { Idle, PatrolArea, PatrolPath, Pack}
    [Tooltip("Determine if and how you want the AI to move" )]
    public EnemyNavType NavType;
    [HideInInspector] public EnemyNavType PreviousNavType;
    public GameObject WaypointPrefab;
    public GameObject Parent;            //Location to a gameobject that holds Waypoints

    [Range(0.1f, 15f)]
    [Tooltip("The how far an enemy can aggro you (in a 360 view, meaning the target doesnt need to be infront of it) ")]
    public float AggroRange = 5f;      

    [Range(0.1f, 5f)]
    [Tooltip("The Range an enemy can inflence another to chase you")]
    public float InfluenceRange = 2f;  

    [Tooltip("Gives your character a state color")]
    public Color StateColor = Color.cyan;

    [Tooltip("Turns on extra information")]
    public bool DebugMode = true;

    //In Editor commands 
    private void OnValidate()
    {
        //Check what Nav type and Adjust to that. Idle be default
        if (PreviousNavType != NavType)
        {
            switch (NavType)
            {
                case EnemyNavType.Idle:
                    {
                        DestroyWaypoints();
                        break;
                    }
                case EnemyNavType.PatrolPath:
                    {
                        CreateWaypoints();
                        break;
                    }

                case EnemyNavType.PatrolArea:
                    {
                        CreateWaypoints();
                        break;
                    }

            }

            PreviousNavType = NavType;         

        }

    }

    void CreateWaypoints()
    {
        if (!WaypointPrefab)
        {
            Parent = GameObject.Find("Waypoints");
            WaypointPrefab = (GameObject)Instantiate(Resources.Load("WaypointSystem"), Parent.transform);
            WaypointPrefab.name = "WP: " + this.name + " at: (" + this.transform.position + ")";
            WaypointPrefab.transform.position = this.transform.position;
        }
    }

    void UpdateWaypoints()
    {
        if (WaypointPrefab)
        {
            foreach (Transform Child in Parent.transform)
            {
                controller.wayPointList.Add(Child.transform);
            }
        }
    }
    void DestroyWaypoints()
    {
      //  WaypointPrefab.hideFlags |= HideFlags.HideInInspector;
        DestroyImmediate(WaypointPrefab);
    }

    void Start()
    {
        Initialize();
    }
    public void SetStateColor(Color colorin)
    {
        StateColor = colorin;
    }
    private void Initialize()
    {
        AttackRange = InfluenceRange;
        controller = GetComponent<StateController>();
        Parent = GameObject.Find("WayPoints");
        CalculateStats();
    }



    private void CalculateStats()
    {

    }
}
