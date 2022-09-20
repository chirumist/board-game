using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthConnect : MonoBehaviour
{
    public GameObject signinPanel;
    public GameObject signUpPanel;

    [SerializeField] InputField username, password;

    [SerializeField] InputField usernameSignUp, emailSignUp, passwordSignUp, confirmPasswordSignUp;

    void Start()
    {
        changeToSignInTab();
    }

    public void changeToSignInTab()
    {
        signinPanel.SetActive(true);
        signUpPanel.SetActive(false);
    }

    public void changeToSignUpTab()
    {
        signinPanel.SetActive(false);
        signUpPanel.SetActive(true);
    }


    public void OnLoginSubmit()
    {
    }

    public void OnRegisterSubmit()
    {
    }
}
