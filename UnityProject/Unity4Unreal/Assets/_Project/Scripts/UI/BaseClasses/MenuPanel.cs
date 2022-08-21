using UnityEngine;
using UnityEngine.UI;

namespace Unreal.UI
{
    [RequireComponent(typeof(Canvas), typeof(CanvasGroup), typeof(GraphicRaycaster))]
    public abstract class MenuPanel : MonoBehaviour
    {
        #region Serialized Fields
        [Header("Menu Panel")]
        [SerializeField] protected Canvas canvas;
        [SerializeField] protected CanvasGroup canvasGroup;
        [SerializeField] protected bool defaultToClosed = true;
        #endregion

        #region Protected Fields
        protected MenuPanelController panelController;
        protected bool isOpen = true;
        protected bool isInteractable = true;
        protected bool willBlockRaycasts = true;
        protected float finalAlpha = 1f;
        #endregion

        protected virtual void OnValidate()
        {
            canvas = GetComponent<Canvas>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        /// <summary>Initializes the panel.</summary>
        /// <param name="parentController">Belonging controller of this panel.</param>
        public virtual void Initialize(MenuPanelController parentController)
        {
            canvas = GetComponent<Canvas>();
            canvasGroup = GetComponent<CanvasGroup>();
            if (defaultToClosed) Close();

            panelController = parentController;
        }

        /// <summary>Opens the panel and enables canvas rendering.</summary>
        public virtual void Open()
        {
            canvas.enabled = true;
            isOpen = true;
            SetCanvasGroupState(isInteractable, willBlockRaycasts, finalAlpha);
        }

        /// <summary>Closes the panel and disables canvas rendering.</summary>
        public virtual void Close()
        {
            canvas.enabled = false;
            isOpen = false;
            SetCanvasGroupState(false);
        }

        /// <summary>Opens the panel if closed and vice versa.</summary>
        public virtual void ToggleState()
        {
            if (isOpen) Close();
            else Open();
        }

        /// <summary>Sets the interactivity of the panel. This will be the default when panel is opened.</summary>
        /// <param name="interactable">Active state of the panel.</param>
        public virtual void SetInteractivity(bool interactable)
        {
            isInteractable = interactable;
            canvasGroup.interactable = interactable;
        }

        /// <summary>Sets the raycast block state of the panel. This will be the default when panel is opened.</summary>
        /// <param name="blocksRaycasts">Whether the panel will block raycasts.</param>
        public virtual void SetBlockRaycasts(bool blocksRaycasts)
        {
            willBlockRaycasts = blocksRaycasts;
            canvasGroup.blocksRaycasts = blocksRaycasts;
        }

        /// <summary>Sets the final alpha when the panel is opened. This will be the default when panel is opened.</summary>
        /// <param name="alpha">The alpha when panel is opened.</param>
        public virtual void SetFinalAlpha(float alpha)
        {
            finalAlpha = alpha;
        }

        /// <summary>Sets the canvas group state of the panel.</summary>
        /// <param name="active">Active state of the panel.</param>
        public virtual void SetCanvasGroupState(bool active)
        {
            SetCanvasGroupState(active, active, active ? 1f : 0f);
        }

        /// <summary>Sets the canvas group state of the panel.</summary>
        /// <param name="interactable">Whether the panel will be interactable.</param>
        /// <param name="blocksRaycasts">Whether the panel will detect raycasts.</param>
        /// <param name="alpha">Alpha render of the panel.</param>
        public virtual void SetCanvasGroupState(bool interactable, bool blocksRaycasts, float alpha)
        {
            canvasGroup.interactable = interactable;
            canvasGroup.blocksRaycasts = blocksRaycasts;
            canvasGroup.alpha = alpha;
        }

        public bool IsOpen => isOpen;
    }
}
