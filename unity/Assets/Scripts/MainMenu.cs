using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public TMP_Text jmbg;
    void Start()
    {
        if(DBManager.LoggedIn)
        {
            jmbg.text = DBManager.jmbg;
        }
    }

    public void GoToRegister()
    {
        SceneManager.LoadScene("RegisterMenu");
    }
    public void GoToLogin()
    {
        SceneManager.LoadScene("LoginMenu");
    }
}
