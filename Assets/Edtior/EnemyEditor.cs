using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (Enemy),true)]
[InitializeOnLoad]
public class EnemyEditor : Editor {
    Enemy ME;
    void Reset()
    {
  
    }


    [DrawGizmo(GizmoType.InSelectionHierarchy | GizmoType.NotInSelectionHierarchy)]
    static void DrawHandles(Enemy ME, GizmoType gizmoType)
    {

        if (ME.controller.currentState.name == "PatrolChase")
        {
            Handles.color = Color.white;
            Handles.DrawWireArc(ME.transform.position, Vector3.up, Vector3.forward, 360, ME.AggroRange);
        }
        else
        {
            Handles.color = Color.grey;
            Handles.DrawWireArc(ME.transform.position, Vector3.up, Vector3.forward, 360, ME.AggroRange);
        }
             //Allows you to change the internal state color, this is good for idenifying a states of a machine. 
             //Each state could have a color that references this! 
            Handles.color = ME.StateColor;
            Handles.DrawWireArc(ME.transform.position, Vector3.up, Vector3.forward, 360, ME.InfluenceRange);

            //Add a small offset to Term
            Handles.color = ME.StateColor;
            Handles.Label(ME.transform.position + new Vector3(0.0f, 1f, 0f), ME.controller.currentState.name);
            
            

    }

}
