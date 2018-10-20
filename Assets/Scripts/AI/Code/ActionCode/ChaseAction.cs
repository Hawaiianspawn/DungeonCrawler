using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PluggableAI/Actions/Chase")]
public class ChaseAction : Action {
    public override void Act(StateController controller)
    {
            Chase(controller);
    }
    private void Chase(StateController controller)
    {
        controller.navMeshAgent.destination = controller.chaseTarget.position;
        controller.navMeshAgent.isStopped = false;

        //Debugging Tools
        Vector3 Direction = (controller.chaseTarget.transform.position - controller.transform.position);
        //Debug.Log(controller.currentState.StateColor);
        Debug.DrawRay(controller.enemy.transform.position, Direction, controller.currentState.StateColor);
    }
}
