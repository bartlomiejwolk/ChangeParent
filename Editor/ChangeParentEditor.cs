﻿// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
// 
// This file is part of the ChangeParent extension for Unity. Licensed under
// the MIT license. See LICENSE file in the project root folder.

using UnityEditor;
using UnityEngine;

namespace ChangeParentEx {

    [CustomEditor(typeof (ChangeParent))]
    public class ChangeParentEditor : Editor {
        #region SERIALIZED PROPERTIES

        private SerializedProperty delay;
        private SerializedProperty description;
        private SerializedProperty option;
        private SerializedProperty parentGO;
        private SerializedProperty parentName;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            DrawOptionDropdown();
            HandleOptionSelection();
            DrawDelayField();

            serializedObject.ApplyModifiedProperties();
        }

        private void OnEnable() {
            option = serializedObject.FindProperty("option");
            parentName = serializedObject.FindProperty("parentName");
            parentGO = serializedObject.FindProperty("parentGO");
            delay = serializedObject.FindProperty("delay");
            description = serializedObject.FindProperty("description");
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS

        private void DrawDelayField() {
            EditorGUILayout.PropertyField(
                delay,
                new GUIContent(
                    "Delay",
                    "Delay before changing parent."));
        }

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        private void DrawOptionDropdown() {
            EditorGUILayout.PropertyField(
                option,
                new GUIContent(
                    "Option",
                    "Defines how to find the parent game object."));
        }

        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    ChangeParent.Version,
                    ChangeParent.Extension));
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

        #endregion INSPECTOR CONTROLS

        #region METHODS

        [MenuItem("Component/ChangeParent")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof (ChangeParent));
            }
        }

        #endregion METHODS
    }

}