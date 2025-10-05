using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Unity.Services.Core;
// using Unity.Services.Authentication;
using System.Threading.Tasks;
using UnityEngine.UI;
// using Unity.Services.CloudSave;
using UnityEngine.SceneManagement;


public class SignInController : MonoBehaviour  {

    private ISignIn _signIn;

    void Start()
    {
        _signIn = new AuthManager();
    }

    public async void Signin()
    {
        await _signIn.SignIn();
        SceneManager.LoadScene(1);
    }
    
}
