// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
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
        private Options option;

        [SerializeField]
        private string parentName = "Clones";

        [SerializeField]
        private GameObject parentGO;

        /// Delay before changing parent.
        [SerializeField]
        private float delay;
        #endregion

        #region UNITY MESSAGES
        private void OnEnable() {
            switch (option) {
                case Options.Name:
                    Invoke("AssignParentByName", delay);
                    break;
                case Options.Transform:
                    Invoke("AssignParentByTransform", delay);
                    break;
            }
        }

        #endregion

        #region METHODS

        private void AssignParentByName() {
            // Find parent go by name.
            parentGO = GameObject.Find(parentName);
            // Create parent if doesn't exists.
            if (parentGO == null) {
                parentGO = new GameObject(parentName);
            }

            transform.parent = parentGO.transform;
        }

        private void AssignParentByTransform() {
            transform.parent = parentGO.transform;
        }

        #endregion
    }

}
