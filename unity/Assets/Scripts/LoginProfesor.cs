using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoginProfesor : MonoBehaviour
{
    public TMP_InputField mailField;
    public TMP_InputField passwordField;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginUser());
    }

    private IEnumerator LoginUser()
    {   
        WWWForm form = new WWWForm();
        form.AddField("mail", mailField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login_profesor.php", form);
        yield return www;
        if(www.text[0] == '0')
        {
            DBManagerProfesor.mail = mailField.text;

            string[] parts = www.text.Split('\t');
            if (parts.Length > 1)
            {
                string idProfesor = parts[1];
                DBManagerProfesor.id = idProfesor;
                string kod_predmeta = parts[2];
                DBManagerProfesor.kod_predmeta = kod_predmeta;
            }
            
            //uzmi odeljenja
            yield return StartCoroutine(DBManagerProfesor.UpdateOdeljenja());

            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuProfesor");
        }
        else
        {
            Debug.Log("User login failed error number #" + www.text);
        }
    }

    
    public void VerifyInputs()
    {
        submitButton.interactable = (passwordField.text.Length >= 8);
    }
}
