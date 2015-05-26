﻿// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the ChangeParent extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEngine;
using System.Collections;

namespace ChangeParentEx {

    /// On enable, change object's parent to "Clones"
    public class ChangeParent : MonoBehaviour {

        #region FIELDS
        #endregion

        #region INSECTOR FIELDS
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
        #endregion

        #region UNITY MESSAGES
        private void OnEnable() {
            switch (_option) {
                case Options.Name:
                    Invoke("AssignParentByName", _delay);
                    break;
                case Options.Transform:
                    Invoke("AssignParentByTransform", _delay);
                    break;
            }
        }

        #endregion

        #region METHODS

        private void AssignParentByName() {
            // Find parent go by name.
            _parentGO = GameObject.Find(_parentName);
            // Create parent if doesn't exists.
            if (_parentGO == null) {
                _parentGO = new GameObject(_parentName);
            }

            transform.parent = _parentGO.transform;
        }

        private void AssignParentByTransform() {
            transform.parent = _parentGO.transform;
        }

        #endregion
    }

}
