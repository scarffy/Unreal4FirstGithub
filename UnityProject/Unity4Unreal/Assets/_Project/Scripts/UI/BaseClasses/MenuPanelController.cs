using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unreal.UI
{
    public abstract class MenuPanelController : MonoBehaviour
    {
        #region Serialized Fields
        [Header("Menu Panel Controller")]
        [SerializeField] protected MenuPanel[] controlledPanels;
        #endregion

        #region Protected Fields
        /// <summary>Mapping of the panels by type.</summary>
        protected Dictionary<Type, MenuPanel> panelDictionary = new();
        #endregion

        #region Private Fields
        private MenuPanel _currentPanel = null;
        #endregion

        /// <summary>Initializes the controller and its controlled panels.</summary>
        public virtual void Initialize()
        {
            foreach (MenuPanel panel in controlledPanels)
            {
                if (panelDictionary.TryAdd(panel.GetType(), panel)) panel.Initialize(this);
                else Debug.LogWarning($"Panel of type {panel.GetType()} already exist in mapping.");
            }
        }

        /// <summary>Gets and returns a specific controlled panel.</summary>
        /// <typeparam name="T">Type of the searched panel.</typeparam>
        /// <returns>The requested panel, null if not found.</returns>
        public virtual T GetPanel<T>() where T : MenuPanel
        {
            return panelDictionary.ContainsKey(typeof(T)) ? (T)panelDictionary[typeof(T)] : null;
        }

        /// <summary>Opens a panel given the panel type. Does not do anything if not found.</summary>
        /// <typeparam name="T">Type of panel to open.</typeparam>
        /// <param name="opensExclusive">Whether opening this panel will close other panels.</param>
        public virtual void OpenPanel<T>(bool opensExclusive = true) where T : MenuPanel
        {
            Type type = typeof(T);

            if (!panelDictionary.ContainsKey(type))
            {
                Debug.LogWarning($"Cannot open panel of type {type}.");
                return;
            }

            foreach (var kvp in panelDictionary)
            {
                if (kvp.Key == type)
                {
                    kvp.Value.Open();
                    _currentPanel = kvp.Value;
                }
                else if (opensExclusive) kvp.Value.Close();
            }
        }

        /// <summary>Closes all controlled panels.</summary>
        public virtual void CloseAllPanels()
        {
            foreach (var kvp in panelDictionary)
                kvp.Value.Close();
        }

        /// <summary>Checks and gets if current panel is castable as given type.</summary>
        /// <typeparam name="T">Type of <see cref="MenuPanel"/> class.</typeparam>
        /// <param name="panelAsT">Out reference of the current panel, casted as T.</param>
        /// <returns>True if castable, false if not.</returns>
        public bool GetCurrentPanelAsTypeOf<T>(out T panelAsT) where T : MenuPanel
        {
            if (_currentPanel is T)
            {
                panelAsT = _currentPanel as T;
                return true;
            }

            panelAsT = null;
            return false;
        }

        public int PanelCount => controlledPanels.Length;
    }
}
