using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class AuthConnect : MonoBehaviour
{
    public GameObject signinPanel;
    public GameObject signUpPanel;

    [SerializeField] InputField username, password;

    [SerializeField] InputField usernameSignUp, emailSignUp, passwordSignUp, confirmPasswordSignUp;

    [SerializeField] Button loginButton;

    WWWForm form;

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
        loginButton.interactable = false;
        StartCoroutine(Login("http://127.0.0.1:8000/api/login"));
    }

    IEnumerator Login(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", "admin@example.com");
        form.AddField("password", "admin");

        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Login Success!");
            }
        }
    }

    public void OnRegisterSubmit()
    {
        loginButton.interactable = false;
        StartCoroutine(Login("http://127.0.0.1:8000/api/register"));
    }

    IEnumerator Register(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", "admin_001");
        form.AddField("email", "admin@example.com");
        form.AddField("password", "admin");
        form.AddField("confirm_password", "admin");

        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Login Success!");
            }
        }
    }
}
