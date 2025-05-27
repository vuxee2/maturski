using UnityEngine;
using TMPro;
using System.Collections;
public class AddObaveza : MonoBehaviour
{
    public TMP_InputField tekstField;
    public TMP_InputField predmetField;

    private IEnumerator _AddObaveza()
    {
        WWWForm form = new WWWForm();
        form.AddField("jmbg", DBManager.jmbg);
        form.AddField("tekst", tekstField.text);
        form.AddField("predmet", predmetField.text);
        WWW www = new WWW("http://localhost/sqlconnect/add_obaveza.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            Debug.Log("dodavanje ocena uspesno");
        }
        else
        {

        }
    }

    public void AddObavezaButton()
    {
        StartCoroutine(_AddObaveza());
    }
}
