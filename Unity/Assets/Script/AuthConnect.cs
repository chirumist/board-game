using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class AuthConnect : MonoBehaviour
{
    public GameObject signinPanel;
    public GameObject signUpPanel;

    public ApiList apiList = new ApiList();

    private string username, password;

    private string usernameSignUp, emailSignUp, passwordSignUp, confirmPasswordSignUp;

    public Button loginButton;
    public Button registerButton;

    WWWForm form;

    void Start()
    {
        var token = PlayerPrefs.GetString("access_token");
        if (token != "") {
            //SceneManager.LoadScene("Lobby");
        } else {
        }
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
        Debug.Log(username);
        Debug.Log(password);
        WWWForm form = new WWWForm();
        form.AddField("email", username);
        form.AddField("password", password);

        StartCoroutine(
            Helper.SendData(apiList.loginUrl, form, (responseText, isSuccess) => {
                if (isSuccess)
                    setLoginToken(responseText);
            })
        );
    }

    public void setLoginToken(string responseText)
    {
        LoginResponse response = JsonUtility.FromJson<LoginResponse>(responseText);
        PlayerPrefs.SetString("access_token", response.access_token);
        PlayerPrefs.SetString("token_type", response.token_type);
        PlayerPrefs.SetInt("expires_in", response.expires_in);
    }

    public void OnRegisterSubmit()
    {
        registerButton.interactable = false;
        StartCoroutine(Register(apiList.registerUrl));
    }

    IEnumerator Register(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameSignUp);
        form.AddField("email", emailSignUp);
        form.AddField("password", passwordSignUp);
        form.AddField("confirm_password", confirmPasswordSignUp);

        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Register Success!");
            }
        }
    }

    public void OnLoginEmail(string value) { username = value; }
    public void OnLoginPassword(string value) { password = value; }

    public void OnUsername(string value) { usernameSignUp = value; }
    public void OnEmail(string value) { emailSignUp = value; }
    public void OnPassword(string value) { passwordSignUp = value; }
    public void OnConfirmPassword(string value) { confirmPasswordSignUp = value; }
}
