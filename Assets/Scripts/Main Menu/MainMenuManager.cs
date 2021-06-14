using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject PlayButton, OptionsButtons, QuitButton;
    public GameObject emailLogin, passwordLogin;
    public GameObject LogInButton, toRegisterButton, RegisterButton, toLoginButton;
    public GameObject emailRegister, passwordRegister, passwordRegisterC;
    public Text Error, RError;
    public GameObject quitConfirm;
    public GameObject optionsPanel;

    public void goToLogin()
    {
        Error.text = "";
        RError.text = "";
        PlayButton.SetActive(false);
        OptionsButtons.SetActive(false);
        QuitButton.SetActive(false);
        emailRegister.SetActive(false);
        passwordRegister.SetActive(false);
        passwordRegisterC.SetActive(false);
        toLoginButton.SetActive(false);
        RegisterButton.SetActive(false);


        emailLogin.SetActive(true);
        passwordLogin.SetActive(true);
        LogInButton.SetActive(true);
        toRegisterButton.SetActive(true);
    }

    public void goToRegister()
    {
        Error.text = "";
        RError.text = "";
        emailLogin.SetActive(false);
        passwordLogin.SetActive(false);
        LogInButton.SetActive(false);
        toRegisterButton.SetActive(false);

        emailRegister.SetActive(true);
        passwordRegister.SetActive(true);
        passwordRegisterC.SetActive(true);
        RegisterButton.SetActive(true);
        toLoginButton.SetActive(true);
    }

    public void quitGame()
    {
        PlayButton.SetActive(false);
        OptionsButtons.SetActive(false);
        QuitButton.SetActive(false);
        quitConfirm.SetActive(true);
    }

    public void abortQuit()
    {
        PlayButton.SetActive(true);
        OptionsButtons.SetActive(true);
        QuitButton.SetActive(true);
        quitConfirm.SetActive(false);
    }

    public void confirmQuit()
    {
        Application.Quit();
    }
}
