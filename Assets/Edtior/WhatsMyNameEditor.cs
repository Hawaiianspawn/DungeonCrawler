using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(WhatsMyName), true)]
[InitializeOnLoad]
[CanEditMultipleObjects]
public class WhatsMyNameEditor : Editor {

    [DrawGizmo(GizmoType.InSelectionHierarchy | GizmoType.NotInSelectionHierarchy)]
    static void DrawHandles(WhatsMyName ME, GizmoType gizmoType)
    {
        //Add a small offset to Term
        Handles.color = Color.cyan;
        Handles.Label(ME.transform.position + new Vector3(0.0f, 0.4f, 0f), ME.gameObject.name);



    }

}
