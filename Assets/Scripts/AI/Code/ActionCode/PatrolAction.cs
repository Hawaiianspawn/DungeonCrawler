using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action {

    public override void Act(StateController controller)
    {
        Patrol(controller);
      //  Debug.Log("Action");
    }

    private void Patrol(StateController controller)
    {
        if (controller.enemy.NavType == Enemy.EnemyNavType.PatrolPath)
        {
            controller.navMeshAgent.SetDestination(controller.wayPointList[controller.nextWayPoint].position);
            controller.navMeshAgent.isStopped = false;

            if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
            {
                controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
            }
        }
    }
}
