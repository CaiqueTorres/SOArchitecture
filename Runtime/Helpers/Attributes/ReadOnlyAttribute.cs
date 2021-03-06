﻿using UnityEditor;
using UnityEngine;

namespace SOArchitecture.Runtime.Helpers.Attributes
{
    public class ReadOnly : PropertyAttribute { }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ReadOnly))]
    public class ReadOnlyPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginDisabledGroup(true);
            {
                EditorGUI.PropertyField(position, property, label);
            }
            EditorGUI.EndDisabledGroup();
        }
    }
#endif
}
