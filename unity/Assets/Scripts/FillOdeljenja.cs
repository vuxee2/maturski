using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine.UI;
public class FillOdeljenja : MonoBehaviour
{
    public GameObject OdeljenjePref;
    public Transform ScrollViewContent;

    public static string zeljeniRazred = "0";

    private void OnEnable()
    {
        StartCoroutine(LoadAndDisplayOdeljenja());
    }
    private IEnumerator LoadAndDisplayOdeljenja()
    {
        foreach (Transform child in ScrollViewContent)
        {
            Destroy(child.gameObject);
        }

        yield return StartCoroutine(DBManagerProfesor.UpdateOdeljenja());

        foreach (var odeljenje in DBManagerProfesor.odeljenja)
        {
            if(odeljenje.razred == zeljeniRazred)
            {
                GameObject noviObjekat = Instantiate(OdeljenjePref, ScrollViewContent);
                
                TMP_Text textComponent = noviObjekat.GetComponentInChildren<TMP_Text>();
                if (textComponent != null)
                {
                    textComponent.text = odeljenje.razred + "-" + odeljenje.odeljenje;
                }

                Button btn = noviObjekat.GetComponent<Button>();

                MainMenuProfesor mainMenuProfesor = FindFirstObjectByType<MainMenuProfesor>();

                // Dodaj listener na klik dugmeta
                btn.onClick.AddListener(() => {
                    mainMenuProfesor.OnOdeljenjeButtonClicked(odeljenje.razred, odeljenje.odeljenje);
                });
            }
        }
    }
}
