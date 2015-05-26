// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the ChangeParent extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ChangeParentEx {

    [CustomEditor(typeof (ChangeParent))]
    public class ChangeParentEditor : Editor {

        #region SERIALIZED PROPERTIES

        private SerializedProperty option;
        private SerializedProperty parentName;
        private SerializedProperty parentGO;
        private SerializedProperty delay;

        #endregion

        #region UNITY MESSAGES

        private void OnEnable() {
            option = serializedObject.FindProperty("option");
            parentName = serializedObject.FindProperty("parentName");
            parentGO = serializedObject.FindProperty("parentGO");
            delay = serializedObject.FindProperty("delay");
        }

        public override void OnInspectorGUI() {
            //ChangeParent script = (ChangeParent)target;
            serializedObject.Update();

            DrawOptionDropdown();
            HandleOptionSelection();
            DrawDelayField();

            serializedObject.ApplyModifiedProperties();
        }

        private void HandleOptionSelection() {
            switch (option.enumValueIndex) {
                case (int) Options.Name:
                    EditorGUILayout.PropertyField(parentName);
                    break;
                case (int) Options.Transform:
                    EditorGUILayout.PropertyField(parentGO);
                    break;
            }
        }

        private void DrawDelayField() {
            EditorGUILayout.PropertyField(delay);
        }

        private void DrawOptionDropdown() {
            EditorGUILayout.PropertyField(option);
        }

        #endregion

    }

}
