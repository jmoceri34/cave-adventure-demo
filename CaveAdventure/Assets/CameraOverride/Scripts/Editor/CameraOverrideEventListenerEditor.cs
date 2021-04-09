namespace CaveAdventure.CameraOverride
{
    using UnityEditor;
    using UnityEngine;

    //[CustomEditor(typeof(CameraOverrideEventListener))]
    //public class CameraOverrideEventListenerEditor : Editor
    //{
    //    public override void OnInspectorGUI()
    //    {
    //        serializedObject.Update();

    //        var prop = serializedObject.FindProperty("Type");
    //        EditorGUILayout.PropertyField(prop, new GUIContent("Override Type"));

    //        Debug.Log("prop: " + prop.intValue);

    //        switch (prop.intValue)
    //        {
    //            case (int)CameraOverrideType.SetCameraOffset:
    //                EditorGUILayout.PropertyField(serializedObject.FindProperty("NewOffset"), new GUIContent("New Offset"));
    //                break;
    //            case (int)CameraOverrideType.SetCameraOffsetX:
    //                EditorGUILayout.PropertyField(serializedObject.FindProperty("NewOffsetX"), new GUIContent("New X"));
    //                break;
    //            case (int)CameraOverrideType.SetCameraOffsetY:
    //                EditorGUILayout.PropertyField(serializedObject.FindProperty("NewOffsetY"), new GUIContent("New Y"));
    //                break;
    //        }

    //        serializedObject.ApplyModifiedProperties();
    //    }
    //}
}