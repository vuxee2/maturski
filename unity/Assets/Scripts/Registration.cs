using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Registration : MonoBehaviour
{
    public TMP_InputField jmbgField;
    public TMP_InputField imeField;
    public TMP_InputField prezimeField;
    public TMP_InputField passwordField;

    public TMP_Dropdown razredDropdown;
    public TMP_Dropdown odeljenjeDropdown;

    public Button submitButton;

    public GameObject sceneTransition;

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
        form.AddField("razred", razredDropdown.value + 1);
        form.AddField("odeljenje", odeljenjeDropdown.value + 1);
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

    public void RegisterProfesor()
    {
        StartCoroutine(ChangeScene("RegisterProfesor"));
    }

    private IEnumerator ChangeScene(string sceneName)
    {
        Instantiate(sceneTransition, transform.position, transform.rotation);
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(sceneName);
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
