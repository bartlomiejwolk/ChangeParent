﻿// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
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

        private SerializedProperty _option;
        private SerializedProperty _parentName;
        private SerializedProperty _parentGO;
        private SerializedProperty _delay;

        #endregion

        #region UNITY MESSAGES

        private void OnEnable() {
            _option = serializedObject.FindProperty("_option");
            _parentName = serializedObject.FindProperty("_parentName");
            _parentGO = serializedObject.FindProperty("_parentGO");
            _delay = serializedObject.FindProperty("_delay");
        }

        public override void OnInspectorGUI() {
            //ChangeParent script = (ChangeParent)target;
            serializedObject.Update();

            EditorGUILayout.PropertyField(_option);
            switch (_option.enumValueIndex) {
                case (int) Options.Name:
                    EditorGUILayout.PropertyField(_parentName);
                    break;
                case (int) Options.Transform:
                    EditorGUILayout.PropertyField(_parentGO);
                    break;
            }
            EditorGUILayout.PropertyField(_delay);

            serializedObject.ApplyModifiedProperties();
            // Save changes
            /*if (GUI.changed) {
            EditorUtility.SetDirty(script);
        }*/
        }

        #endregion

    }

}
