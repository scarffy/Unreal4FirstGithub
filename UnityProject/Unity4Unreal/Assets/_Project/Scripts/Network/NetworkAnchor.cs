using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unreal.Network
{
    using Shell;

    public class NetworkAnchor : Singleton<NetworkAnchor>
    {
        #region Private Field
        [SerializeField] private PlayFabController _playFabController;
        #endregion

        public static void Initialize() {
            PlayFabController.Initialize();
        }

        #region Accessor
        public static PlayFabController PlayFabController => Instance._playFabController;
        #endregion
    }
}
