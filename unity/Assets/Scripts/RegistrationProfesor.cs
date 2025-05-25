using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class RegistrationProfesor : MonoBehaviour
{
    public TMP_InputField imeField;
    public TMP_InputField prezimeField;
    public TMP_InputField predmetField;
    public TMP_InputField passwordField;
    public TMP_InputField mailField;

    public Button submitButton;

    public GameObject sceneTransition;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    private IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("ime", imeField.text);
        form.AddField("prezime", prezimeField.text);
        form.AddField("predmet", predmetField.text);
        form.AddField("password", passwordField.text);
        form.AddField("mail", mailField.text);
        WWW www = new WWW("http://localhost/sqlconnect/register_profesor.php", form);
        yield return www;
        if (www.text == "0")
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
        submitButton.interactable = (imeField.text.Length >= 3 && prezimeField.text.Length >= 3 && passwordField.text.Length >= 8);
    }

    public void RegisterUcenik()
    {
        StartCoroutine(ChangeScene("RegisterMenu"));
    }
    
    private IEnumerator ChangeScene(string sceneName)
    {
        Instantiate(sceneTransition, transform.position, transform.rotation);
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(sceneName);
    }
}
