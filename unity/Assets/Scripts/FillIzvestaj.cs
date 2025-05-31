using UnityEngine;
using TMPro;
using System.Collections;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

public class FillIzvestaj : MonoBehaviour
{
    public TextMeshProUGUI IzvestajText; // UI Text za prikaz izveštaja

    private void OnEnable()
    {
        StartCoroutine(GenerateIzvestaj());
    }

    private IEnumerator GenerateIzvestaj()
    {
        yield return StartCoroutine(DBManager.UpdateOcene());

        string oceneTemp = DBManager.ocene;

        // Uzmi trenutni mesec u formatu "yyyy-MM" (npr. "2025-05")
        string targetMonth = DateTime.Now.ToString("yyyy-MM");

        var matches = Regex.Matches(oceneTemp, @"([a-zA-Z]+)(\d)\(([\d\-]+)\)");
        List<int> oceneUMesecu = new List<int>();
        List<string> detalji = new List<string>();

        foreach (Match match in matches)
        {
            string predmet = match.Groups[1].Value;
            int ocena = int.Parse(match.Groups[2].Value);
            string datum = match.Groups[3].Value;

            if (datum.StartsWith(targetMonth))
            {
                oceneUMesecu.Add(ocena);
                detalji.Add($"{predmet.ToUpper()}: {ocena} ({datum})");
            }
        }

        if (oceneUMesecu.Count == 0)
        {
            IzvestajText.text = $"Нема оцена за {targetMonth}.";
            yield break;
        }

        float prosek = 0;
        foreach (var o in oceneUMesecu)
            prosek += o;

        prosek /= oceneUMesecu.Count;

        IzvestajText.text = $"Извештај за {targetMonth}:\n";
        IzvestajText.text += $"Број оцена: {oceneUMesecu.Count}\n";
        IzvestajText.text += $"Просек: {prosek:F2}\n";
        IzvestajText.text += "\nДетаљи:\n";

        foreach (var detalj in detalji)
        {
            IzvestajText.text += detalj + "\n";
        }
    }
}
