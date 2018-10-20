using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Enemy), true)]
[InitializeOnLoad]
[CanEditMultipleObjects]
public class CharacterStatsEditor : Editor {

    SerializedProperty StaminaProp;
    SerializedProperty StrengthProp;
    SerializedProperty AgilityProp;
    SerializedProperty IntellectProp;
    SerializedProperty MaxHPProp;
    SerializedProperty MaxMPProp;

    void OnEnable()
    {
        // Setup the SerializedProperties
        StaminaProp = serializedObject.FindProperty("Stamina");
        StrengthProp = serializedObject.FindProperty("Strength");
        AgilityProp = serializedObject.FindProperty("Agility");
        IntellectProp = serializedObject.FindProperty("Intellect");

        MaxHPProp = serializedObject.FindProperty("MaxHP");
        MaxMPProp = serializedObject.FindProperty("MaxHP");

    }


    //public override void OnInspectorGUI()
    //{
    //    // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
    //    serializedObject.Update();
    //    // Show the custom GUI controls
    //    var MaxHP = MaxHPProp;
    //    EditorGUILayout.IntSlider(StaminaProp, 0,  100, new GUIContent("HP based on level" + StaminaProp));
    //    // Only show the damage progress bar if all the objects have the same damage value:
    //    if (!StaminaProp.hasMultipleDifferentValues)
    //        ProgressBar(StaminaProp.intValue / 100.0f, "Damage");


    //    //EditorGUILayout.IntSlider(armorProp, 0, 100, new GUIContent("Armor"));
    //    //// Only show the armor progress bar if all the objects have the same armor value:
    //    //if (!armorProp.hasMultipleDifferentValues)
    //    //    ProgressBar(armorProp.intValue / 100.0f, "Armor");
    //    //EditorGUILayout.PropertyField(gunProp, new GUIContent("Gun Object"));

    //    // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
    //    serializedObject.ApplyModifiedProperties();
    //}

    // Custom GUILayout progress bar.
    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();


    }

    // Use this for initialization
    void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
