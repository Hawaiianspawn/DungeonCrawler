using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//http://et.worldofwarcraft.wikia.com/wiki/Aggro_radius

[CreateAssetMenu(menuName ="PluggableAI/Decisions/Look")]
public class LookDecision : Decision {
    public override bool Decide(StateController controller)
    {
       // Debug.Log("I SEE YOU");
        bool targetVisible = Look(controller);
        return targetVisible;
    }


    //Check if target is in range and visible, ALSO check for Infleunce range 
    private bool Look(StateController controller)
    {

        RaycastHit hit;
        //Gizmos.DrawSphere(controller.transform.position, controller.enemy.AggroRange);
        Collider[] targets = Physics.OverlapSphere(controller.transform.position, controller.enemy.AggroRange, 1536);  //Enemy
        foreach (Collider target in targets)
        {
            Vector3 Direction = (target.transform.position - controller.enemy.transform.position);

            //Shoot out a raycast, if somethings blocking, don't change state
            if (Physics.Raycast(controller.enemy.transform.position, Direction.normalized, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    Debug.DrawRay(controller.enemy.transform.position, Direction, Color.white);
                    controller.chaseTarget = hit.transform;
                    return true;
                }
                else
                {
                    Debug.DrawRay(controller.enemy.transform.position, Direction, Color.red);
                }
            }
        }
        return false;

    }

}
