using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
public class FillUcenici : MonoBehaviour
{
    public GameObject UcenikPref;
    public Transform ScrollViewContent;

    public void PrikaziUcenikeZaOdeljenje(string razred, string odeljenje)
    {
        StartCoroutine(LoadAndDisplayUcenici(razred, odeljenje));
    }

    private IEnumerator LoadAndDisplayUcenici(string razred, string odeljenje)
    {
        foreach (Transform child in ScrollViewContent)
        {
            Destroy(child.gameObject);
        }

        WWWForm form = new WWWForm();
        form.AddField("razred", razred);
        form.AddField("odeljenje", odeljenje);

        WWW www = new WWW("http://localhost/sqlconnect/extract_ucenici.php", form);
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError("Greška pri učitavanju učenika: " + www.error);
            yield break;
        }

        // www.text sadrži niz linija, svaka linija format: ime|prezime|razred|odeljenje
        string[] lines = www.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length >= 2) // Provera da li ima bar ime i prezime
            {
                string jmbg = parts[0];
                string ime = parts[1];
                string prezime = parts[2];
                // Po potrebi možeš uzeti i razred i odeljenje iz parts[2] i parts[3]

                GameObject noviObjekat = Instantiate(UcenikPref, ScrollViewContent);
                TMP_Text textComponent = noviObjekat.GetComponentInChildren<TMP_Text>();
                if (textComponent != null)
                {
                    textComponent.text = ime + " " + prezime;
                }

                Button btn = noviObjekat.GetComponent<Button>();

                MainMenuProfesor mainMenuProfesor = FindFirstObjectByType<MainMenuProfesor>();

                // Dodaj listener na klik dugmeta
                btn.onClick.AddListener(() => {
                    mainMenuProfesor.OnUcenikButtonClicked(jmbg, ime, prezime);
                });
            }
        }
    }
}
