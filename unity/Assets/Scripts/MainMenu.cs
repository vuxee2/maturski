using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public TMP_Text jmbg;
    public GameObject loginRegisterPanel;
    void Start()
    {
        if(DBManager.LoggedIn)
        {
            jmbg.text = DBManager.jmbg;
            loginRegisterPanel.SetActive(false);
        }
        else
        {
            loginRegisterPanel.SetActive(true);
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
