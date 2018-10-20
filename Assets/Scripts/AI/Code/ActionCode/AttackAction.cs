using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action
{
    public override void Act(StateController controller)
    {
        //If Target is a character
        if(controller.chaseTarget.GetComponent<Character>())
            Attack(controller);
    }
    private void Attack(StateController controller)
    {
        
        Character Self = controller.GetComponent<Character>();
        Character Target = null;
        
        //If target is not on the same team (By layer) then set target! 
        if(controller.gameObject.layer != controller.chaseTarget.gameObject.layer)
        {
            Target = controller.chaseTarget.GetComponent<Character>();
        }

        float Range = 0f;
        Range = Self.AttackRange;
        float Distance = Vector3.Distance(controller.chaseTarget.transform.position, controller.gameObject.transform.position);
        //Debug.Log(Distance);


        //If there is a target according to it's StateController
        if (Target)
        {
            if (Range >= Distance && Self.IsReady())
            {
                Self.Attack(Target, Self.Damage);
            }
        }
    }
}
