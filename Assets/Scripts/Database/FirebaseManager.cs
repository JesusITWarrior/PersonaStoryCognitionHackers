using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.UI;
using Firebase.Database;

//TODO: Ensure that saving and reloading is not an easy exploit to adjust the items database

public class FirebaseManager : MonoBehaviour
{
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;
    public DatabaseReference DBref;

    [Header("Login")]
    public InputField email;
    public InputField password;
    public Text warningLogin;
    public Text confirmLogin;

    [Header("Register")]
    public InputField emailRegister;
    public InputField passwordRegister;
    public InputField passwordRegisterVerify;
    public Text warningRegister;
    public Text confirmRegister;

    [Header("UserData")]
    public InputField hold; //Come back to this when Save slot screen is made...

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all firebase dependencies: " + dependencyStatus);
            }
        });
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = FirebaseAuth.DefaultInstance;
        DBref = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void ClearLoginFields()
    {
        email.text = "";
        password.text = "";
    }

    public void ClearRegisterFields()
    {
        emailRegister.text = "";
        passwordRegister.text = "";
        passwordRegisterVerify.text = "";
    }

    public void LoginButton()
    {
        StartCoroutine(Login(email.text, password.text));
    }

    public void RegisterButton()
    {
        StartCoroutine(Register(emailRegister.text, passwordRegister.text));
    }

    //TODO: Implement this into a "Title Screen" Button, the ingame "quit" button, and if application is closed or connection is lost
    public void SignOutButton()
    {
        auth.SignOut();
        //May need to remove these parts later....
        ClearRegisterFields();
        ClearLoginFields();
    }

    private IEnumerator Login(string _email, string _password)
    {
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            warningLogin.text = message;
            GameObject reject = GameObject.Find("Error");
            reject.GetComponent<AudioSource>().Play();
        }
        else
        {
            User = LoginTask.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            warningLogin.text = "";
            confirmLogin.text = "Logged In";
            GameObject confirm = GameObject.Find("Select");
            confirm.GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(2);

            //fade the screen into the save data screen
            confirmLogin.text = "";
        }
    }
    private IEnumerator Register(string _email, string _password)
    {
        if (passwordRegister.text != passwordRegisterVerify.text)
        {
            warningRegister.text = "Password Does Not Match!";
        }
        else
        {
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                Debug.LogWarning(message: $"failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Registration Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Password Is Too Weak";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email Already In Use";
                        break;
                }
                warningRegister.text = message;
                GameObject reject = GameObject.Find("Error");
                reject.GetComponent<AudioSource>().Play();
            }
            else
            {
                User = RegisterTask.Result;

                if (User != null)
                {
                    UserProfile profile = new UserProfile();

                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                    }
                    else
                    {
                        confirmRegister.text = "Registered";
                        //UIManager.instance.LoginScreen();     //Supposed to return to Login Screen, but I will just go ahead and log them in.
                        warningRegister.text = "";
                        GameObject confirm = GameObject.Find("Select");
                        confirm.GetComponent<AudioSource>().Play();

                        yield return new WaitForSeconds(2);
                        confirmRegister.text = "";
                        
                    }
                }
            }
        }
    }

    //TODO: Ensure the player initializes the correct things

    /*private IEnumerator SetPlayerName(string _name)
    {
        var DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Name").SetValueAsync(playerFile.charName);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }
    }*/



    private IEnumerator UpdatePlayerData(int i, Player playerFile)
    {
        var DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Level").SetValueAsync(playerFile.lv);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if(DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }
        
        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("XP").SetValueAsync(playerFile.xp);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Strength").SetValueAsync(playerFile.str);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Magic").SetValueAsync(playerFile.mag);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Endurance").SetValueAsync(playerFile.en);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Agility").SetValueAsync(playerFile.ag);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Luck").SetValueAsync(playerFile.lu);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Weapon").SetValueAsync(playerFile.weapon);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Gun").SetValueAsync(playerFile.gun);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Armor").SetValueAsync(playerFile.armor);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Skill1").SetValueAsync(playerFile.Skill1);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Skill2").SetValueAsync(playerFile.Skill2);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Skill3").SetValueAsync(playerFile.Skill3);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Skill4").SetValueAsync(playerFile.Skill4);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Skill5").SetValueAsync(playerFile.Skill5);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Skill6").SetValueAsync(playerFile.Skill6);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Skill7").SetValueAsync(playerFile.Skill7);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }

        DBTask = DBref.Child("users").Child(User.UserId).Child(i.ToString()).Child("Skill8").SetValueAsync(playerFile.Skill8);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database is updated
        }
    }
}
