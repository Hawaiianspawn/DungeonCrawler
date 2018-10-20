using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//Made exclusively for movement of hero characters. Sure you can use it for npcs but that might be hard. 

[CreateAssetMenu(menuName = "PluggableAI/Decisions/OnClick")]

public class OnClickDecision : Decision {

    public override bool Decide(StateController controller)
    {
        // Debug.Log("I SEE YOU");
        bool ClickedEnemy = Click(controller);
        return ClickedEnemy ;
    }
    // Click checks if you clicked a hero or something else. If something else move to that point
    private bool Click(StateController controller) {
        Camera MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Location;

            if (Physics.Raycast(ray, out Location))
            {
                if (Location.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    return true; //Attack enemy
                }
                else
                {
                    return false;  //You put move to location mouse
                }
            }
        }
        return false;
    }
}
