using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unreal.Core
{
    using Unreal.Shell;
    using Unreal.UI;
    using Unreal.Network;

    /// <summary>
    /// Project booth initializer, responsible for starting the initialization when application starts
    /// </summary>
    public class ProjectBootstrapper : MonoBehaviour
    {
        [SerializeField] private bool _enableDebugUI = false;

        private void Start()
        {
            Application.targetFrameRate = 60;


            //! Initialization
            UIAnchor.InitializeAllControllers();
            NetworkAnchor.Initialize();
        }
    }
}
