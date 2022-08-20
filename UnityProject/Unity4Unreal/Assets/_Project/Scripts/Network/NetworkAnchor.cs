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

        private void Start()
        {
            PlayFabController.Initialize();
        }


        #region Accessor
        public PlayFabController PlayFabController => _playFabController;
        #endregion
    }
}
