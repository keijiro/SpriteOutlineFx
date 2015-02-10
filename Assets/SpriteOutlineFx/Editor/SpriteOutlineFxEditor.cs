using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(SpriteOutlineFx)), CanEditMultipleObjects]
public class SpriteOutlineFxEditor : Editor
{
    SerializedProperty propOutlineColor;
    SerializedProperty propSampleDistance;

    GUIContent labelSampleDistance;

    void OnEnable()
    {
        propOutlineColor = serializedObject.FindProperty("_outlineColor");
        propSampleDistance = serializedObject.FindProperty("_sampleDistance");
        labelSampleDistance = new GUIContent("Outline Width");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(propOutlineColor);
        EditorGUILayout.Slider(propSampleDistance, 0.0f, 10.0f, labelSampleDistance);

        serializedObject.ApplyModifiedProperties();
    }
}
