// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the ChangeParent extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEngine;
using System.Collections;
using UnityEditor;
using OneDayGame;

[CustomEditor(typeof(ChangeParent))]
public class ChangeParentEditor: GameComponentEditor {

	private SerializedProperty _option;
	private SerializedProperty _parentName;
	private SerializedProperty _parentGO;
	private SerializedProperty _delay;

	public override void OnEnable() {
		base.OnEnable();

		_option = serializedObject.FindProperty("_option");
		_parentName = serializedObject.FindProperty("_parentName");
		_parentGO = serializedObject.FindProperty("_parentGO");
		_delay = serializedObject.FindProperty("_delay");
	}

	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		//ChangeParent script = (ChangeParent)target;
		serializedObject.Update();

		EditorGUILayout.PropertyField(_option);
		switch (_option.enumValueIndex) {
			case (int)ChangeParent.Options.Name:
				EditorGUILayout.PropertyField(_parentName);
				break;
			case (int)ChangeParent.Options.Transform:
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
}
