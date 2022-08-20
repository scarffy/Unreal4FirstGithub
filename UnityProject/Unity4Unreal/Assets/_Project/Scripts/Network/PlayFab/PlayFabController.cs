using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;

namespace Unreal.Network
{
    /// <summary>
    /// This is to store logic for register, login and account recovery
    /// </summary>
    public class PlayFabController : MonoBehaviour
    {
        public void Initialize()
        { 
        }

        public void RegisterAccount(string email,string username, string password)
        {
            var request = new RegisterPlayFabUserRequest()
            {
                Email = email,
                Username = username,
                DisplayName = username,
                Password = password,
                RequireBothUsernameAndEmail = true
            };
            PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnFailure);
        }

        public void LoginAccountWithEmail(string email, string password)
        {
            var request = new LoginWithEmailAddressRequest()
            {
                Email = email,
                Password = password
            };
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnFailure);

            ///! This is how to login with another method
            //LoginWithEmailAddressRequest method2 = new LoginWithEmailAddressRequest();
            //method2.Email = email;
            //method2.Password = password;
            //PlayFabClientAPI.LoginWithEmailAddress(method2, OnLoginSuccess, OnFailure);
        }

        public void RecoverAccount(string email)
        {
            var request = new SendAccountRecoveryEmailRequest()
            {
                Email = email
            };
            PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoverySuccess, OnFailure);
        }

        private void OnRegisterSuccess(RegisterPlayFabUserResult result)
        {
            Debug.Log("PlayFab result : Register Success.");
        }

        private void OnLoginSuccess(LoginResult result)
        {
            Debug.Log("PlayFab result : Login Success.");
        }

        private void OnRecoverySuccess(SendAccountRecoveryEmailResult result)
        {
            Debug.Log("PlayFab result : Recovery Success.");
        }

        private void OnFailure(PlayFabError error)
        {
            Debug.LogError(error.GenerateErrorReport());
        }
    }
}
