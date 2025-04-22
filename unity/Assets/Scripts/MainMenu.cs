using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void GoToRegister()
    {
        SceneManager.LoadScene("RegisterMenu");
    }
    public void GoToLogin()
    {
        SceneManager.LoadScene("LoginMenu");
    }
}
