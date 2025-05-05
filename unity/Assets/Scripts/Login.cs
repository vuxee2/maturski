using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Login : MonoBehaviour
{
    public TMP_InputField jmbgField;
    public TMP_InputField passwordField;

    public Button submitButton;


    public void CallLogin()
    {
        StartCoroutine(LoginUser());
    }

    private IEnumerator LoginUser()
    {   
        WWWForm form = new WWWForm();
        form.AddField("jmbg", jmbgField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        if(www.text[0] == '0')
        {
            DBManager.jmbg = jmbgField.text;

            //uzmi ocene
            WWWForm form2 = new WWWForm();
            form2.AddField("jmbg", jmbgField.text);
            WWW www2 = new WWW("http://localhost/sqlconnect/extract_info.php", form2);
            yield return www2;
            DBManager.ocene = www2.text;

            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User login failed error number #" + www.text);
        }
    }
    
    public void VerifyInputs()
    {
        submitButton.interactable = (passwordField.text.Length >= 8 && jmbgField.text.Length == 13 && IsOnlyNumbers(jmbgField.text));
    }
    bool IsOnlyNumbers(string text)
    {
        if (string.IsNullOrEmpty(text)) return false;
        foreach (char c in text)
        {
            if (!char.IsDigit(c))
                return false;
        }
        return true;
    }
}
