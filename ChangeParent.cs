// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
// 
// This file is part of the ChangeParent extension for Unity. Licensed under
// the MIT license. See LICENSE file in the project root folder.

using UnityEngine;

namespace ChangeParentEx {

    /// On enable, change object's parent to "Clones"
    public class ChangeParent : MonoBehaviour {
        #region CONSTANTS

        public const string Extension = "ChangeParent";
        public const string Version = "v0.1.0";

        #endregion CONSTANTS

        #region FIELDS

        /// <summary>
        ///     Allows identify component in the scene file when reading it with
        ///     text editor.
        /// </summary>
        [SerializeField]
        private string componentName = "ChangeParent";

        #endregion FIELDS

        #region INSECTOR FIELDS

        /// Delay before changing parent.
        [SerializeField]
        private float delay;

        [SerializeField]
        private string description = "Description";

        /// Select how to find a new parent.
        [SerializeField]
        private Options option;

        [SerializeField]
        private GameObject parentGO;

        [SerializeField]
        private string parentName = "Clones";

        #endregion INSECTOR FIELDS

        #region PROPERTIES

        /// Delay before changing parent.
        public float Delay {
            get { return delay; }
            set { delay = value; }
        }

        /// <summary>
        ///     Optional text to describe purpose of this instance of the
        ///     component.
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }

        /// Select how to find a new parent.
        public Options Option {
            get { return option; }
            set { option = value; }
        }

        public GameObject ParentGO {
            get { return parentGO; }
            set { parentGO = value; }
        }

        public string ParentName {
            get { return parentName; }
            set { parentName = value; }
        }

        #endregion PROPERTIES

        #region UNITY MESSAGES

        private void OnEnable() {
            switch (Option) {
                case Options.Name:
                    Invoke("AssignParentByName", Delay);
                    break;

                case Options.Transform:
                    Invoke("AssignParentByTransform", Delay);
                    break;
            }
        }

        #endregion UNITY MESSAGES

        #region METHODS

        private void AssignParentByName() {
            // Find parent go by name.
            ParentGO = GameObject.Find(ParentName);
            // Create parent if doesn't exists.
            if (ParentGO == null) {
                ParentGO = new GameObject(ParentName);
            }

            transform.parent = ParentGO.transform;
        }

        private void AssignParentByTransform() {
            transform.parent = ParentGO.transform;
        }

        #endregion METHODS
    }

}