using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{

    public State currentState;
    public State remainState;
    public Camera CameraRef;


    [HideInInspector] public NavMeshAgent navMeshAgent;
    public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;
    public Transform chaseTarget;
    [HideInInspector] public Enemy enemy;
    [HideInInspector] public CharacterStats character;




    public float stateTimeElapsed;

    private bool aiActive;


    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if(GetComponent<Enemy>())
            enemy = GetComponent<Enemy>();
        aiActive = true;
        CameraRef = GameObject.Find("Main Camera").GetComponent<Camera>();
        //Debug.Log(currentState);
    }

    public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
    {
      //        aiActive = aiActivationFromTankManager;
        if (aiActive)
        {
            navMeshAgent.enabled = true;
        }
        else
        {
            navMeshAgent.enabled = false;
        }
    }

    void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState(this);
    }

    void OnDrawGizmos()
    {

    }
  
    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }
  
}
