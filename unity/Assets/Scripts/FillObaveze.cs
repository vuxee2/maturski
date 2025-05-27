using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class FillObaveze : MonoBehaviour
{
    public GameObject ObavezaPref;           // Prefab sa TMP_Text komponentama
    public Transform ScrollViewContent;

    [System.Serializable]
    public class ObavezaData
    {
        public string tekst;
        public string predmet;
    }

    [System.Serializable]
    private class ObavezaDataList
    {
        public List<ObavezaData> items;
    }

    private void OnEnable()
    {
        StartCoroutine(LoadAndDisplayObaveze());
    }

    private IEnumerator LoadAndDisplayObaveze()
    {
        foreach (Transform child in ScrollViewContent)
            Destroy(child.gameObject);

        WWWForm form = new WWWForm();
        form.AddField("jmbg", DBManager.jmbg);

        using (WWW www = new WWW("http://localhost/sqlconnect/get_obaveze.php", form))
        {
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.LogError("Greska pri ucitavanju podataka: " + www.error);
                yield break;
            }

            //Debug.Log("Primljeni JSON: " + www.text);

            ObavezaDataList listaObaveza = JsonUtility.FromJson<ObavezaDataList>(www.text);

            if (listaObaveza == null || listaObaveza.items == null || listaObaveza.items.Count == 0)
            {
                Debug.Log("Nema obaveza ili problem sa parsiranjem JSON-a.");
                yield break;
            }

            foreach (var obaveza in listaObaveza.items)
            {
                GameObject obj = Instantiate(ObavezaPref, ScrollViewContent);

                TMP_Text[] texts = obj.GetComponentsInChildren<TMP_Text>();
                if (texts.Length >= 2)
                {
                    texts[0].text = obaveza.tekst;
                    texts[1].text = obaveza.predmet;
                }
                else if (texts.Length == 1)
                {
                    texts[0].text = $"{obaveza.predmet}: {obaveza.tekst}";
                }
            }
        }
    }
}
