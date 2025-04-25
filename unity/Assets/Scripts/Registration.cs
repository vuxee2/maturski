using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Registration : MonoBehaviour
{
    public TMP_InputField jmbgField;
    public TMP_InputField imeField;
    public TMP_InputField prezimeField;
    public TMP_InputField passwordField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    private IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("jmbg", jmbgField.text);
        form.AddField("ime", imeField.text);
        form.AddField("prezime", prezimeField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("Your user creation request has been sent successfully. Please wait for the admin's approval.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User Creation Failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (imeField.text.Length >= 3 &&  prezimeField.text.Length >= 3 && passwordField.text.Length >= 8 && jmbgField.text.Length == 13 && IsOnlyNumbers(jmbgField.text));
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
