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
        private SerializedProperty description;

        #endregion

        #region UNITY MESSAGES

        private void OnEnable() {
            option = serializedObject.FindProperty("option");
            parentName = serializedObject.FindProperty("parentName");
            parentGO = serializedObject.FindProperty("parentGO");
            delay = serializedObject.FindProperty("delay");
            description = serializedObject.FindProperty("description");
        }

        public override void OnInspectorGUI() {
            //ChangeParent script = (ChangeParent)target;
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();
            
            DrawOptionDropdown();
            HandleOptionSelection();
            DrawDelayField();

            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        #region INSPECTOR CONTROLS
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

        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    ChangeParent.Version,
                    ChangeParent.Extension));
        }

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }
 
        #endregion

        #region METHODS

        [MenuItem("Component/ChangeParent")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof(ChangeParent));
            }
        }
 
        #endregion

    }

}
