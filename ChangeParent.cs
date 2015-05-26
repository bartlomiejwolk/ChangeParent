// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the ChangeParent extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEngine;
using System.Collections;

namespace OneDayGame {

	/// On enable, change object's parent to "Clones"
	public class ChangeParent : GameComponent {

		/// How to find a new parent options.
		public enum Options {
			/// Search for parent by its name.
			Name,
			/// Pass a transform to be a parent.
			Transform }

		/// Select how to find a new parent.
		[SerializeField]
		private Options _option;

		[SerializeField]
		private string _parentName = "Clones";

		[SerializeField]
		private GameObject _parentGO;

		/// Delay before changing parent.
		[SerializeField]
		private float _delay;

		public override void Start () {
			base.Start();
		}

		public override void Update () {
			base.Update();
		}

		public override void OnEnable() {
			switch (_option) {
				case Options.Name:
					// Find parent go by name.
					_parentGO = GameObject.Find(_parentName);
					// Create parent if doesn't exists.
					if (_parentGO == null) {
						_parentGO = new GameObject(_parentName);
					}
					AssignNewParent();
					break;
				case Options.Transform:
					AssignNewParent();
					break;
			}
		}

		private void AssignNewParent() {
			// Start coroutine only if the parenting should be delayed.
			if (_delay != 0) {
				StartCoroutine(Timer.Start(
							_delay,
							() => { transform.parent = _parentGO.transform; }
							));
			}
			else {
				transform.parent = _parentGO.transform;
			}
		}
	}
}
