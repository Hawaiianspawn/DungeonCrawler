using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/OnClickMove")]
public class OnClickMoveAction : Action
{
    bool Held;     //Usually bad for scriptable objects to have a bool value that sticks between all users of the script. BUT this is only for one player!
    Transform movelocation;
    public override void Act(StateController controller)
    {
        OnClick(controller);
    }
    private void OnClick(StateController controller)
    {
        //Cant use GetMouseDrag because this is a scriptable object. 
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
            Ray ray = controller.CameraRef.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out Location))
            {
                //If not a target;
                if (!(Location.collider.gameObject.layer == LayerMask.NameToLayer("Enemy")))
                {
                    controller.navMeshAgent.SetDestination(Location.point);
                }
            }
        }
    }
}
