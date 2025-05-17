using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
public class MainMenuProfesor : MonoBehaviour
{
    public TMP_Text mail;
    public GameObject odeljenjaPanel;
    public GameObject uceniciPanel;

    public GameObject ucenikPanel;
    public TMP_Text ucenikImePrezime;
    private string selectedJMBG;
    public TMP_Dropdown ocenaDropDown;
    void Start()
    {
        if(DBManagerProfesor.LoggedIn)
        {
            mail.text = DBManagerProfesor.mail + "  " + DBManagerProfesor.kod_predmeta;
        }
    }
    void Update()
    {
        if(!ucenikPanel.activeSelf) selectedJMBG = "";
    }
    public void OpenOdeljenja(string razred)
    {
        FillOdeljenja.zeljeniRazred = razred;
        odeljenjaPanel.SetActive(true);
    }

    public void OnOdeljenjeButtonClicked(string razred, string odeljenje)
    {
        //Debug.Log($"Razred: {razred}, Odeljenje: {odeljenje}");
        if (razred == null || odeljenje == null)
        {
            Debug.LogError("Jedan od parametara je null!");
            return;
        }
        uceniciPanel.SetActive(true);
        odeljenjaPanel.SetActive(false);
        uceniciPanel.GetComponent<FillUcenici>().PrikaziUcenikeZaOdeljenje(razred, odeljenje);
    }
    public void OnUcenikButtonClicked(string jmbg, string ime, string prezime)
    {
        if (jmbg == null)
        {
            Debug.LogError("Jedan od parametara je null!");
            return;
        }
        uceniciPanel.SetActive(false);
        odeljenjaPanel.SetActive(false);
        ucenikPanel.SetActive(true);
        ucenikImePrezime.text = ime + " " + prezime;
        selectedJMBG = jmbg;
    }

    public IEnumerator AddOcenaUceniku(string jmbg, string kod_predmeta, int ocena)
    {
        WWWForm form = new WWWForm();
        form.AddField("jmbg", jmbg);
        form.AddField("predmet", kod_predmeta);
        form.AddField("ocena", ocena);

        WWW www = new WWW("http://localhost/sqlconnect/add_ocena_ucenik.php", form);
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError("Greska pri povezivanju: " + www.error);
            yield break;
        }

        if (www.text == "0")
        {
            Debug.Log("Ocena dodata");
        }
        else
        {
            Debug.LogError("Greska: " + www.text);
        }
    }

    public void AddOcenaUcenik()
    {
        StartCoroutine(AddOcenaUceniku(selectedJMBG, DBManagerProfesor.kod_predmeta, ocenaDropDown.value + 1));
    }
}
