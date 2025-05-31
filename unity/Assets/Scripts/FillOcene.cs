using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using TMPro;
public class FillOcene : MonoBehaviour
{
    public GameObject OcenaPref;

    public Transform ScrollViewContent;

    private string oceneTemp;

    private void OnEnable()
    {
        StartCoroutine(LoadAndDisplayOcene());
    }
    private IEnumerator LoadAndDisplayOcene()
    {
        yield return StartCoroutine(DBManager.UpdateOcene());
        oceneTemp = DBManager.ocene;

        foreach (Transform child in ScrollViewContent)
        {
            Destroy(child.gameObject);
        }

        var subjectMap = new Dictionary<string, string>()
        {
            {"s", "Српски језик и књизевност"},
            {"m", "Математика"},
            {"e", "Енглески језик"},
            {"fzc", "Физичко васпитање"},
            {"fiz", "Физика"},
            {"nem", "Немачки језик"},
            {"asa", "Анализа са алгебром"},
            //treba se doda jos
        };

        // Regex koji hvata predmet, ocenu i datum (npr. mat5(2025-05-31))
        var matches = Regex.Matches(oceneTemp, @"([a-zA-Z]+)(\d)\(([\d\-]+)\)");

        foreach (Match match in matches)
        {
            string subjectCode = match.Groups[1].Value;
            string grade = match.Groups[2].Value;
            string date = match.Groups[3].Value;

            var instance = Instantiate(OcenaPref, ScrollViewContent);

            var subjectText = instance.transform.Find("PredmetTXT").GetComponent<TextMeshProUGUI>();
            var gradeText = instance.transform.Find("OcenaTXT").GetComponent<TextMeshProUGUI>();
            var dateText = instance.transform.Find("DatumTXT").GetComponent<TextMeshProUGUI>();

            gradeText.text = grade;
            dateText.text = date;
            
            if (subjectMap.ContainsKey(subjectCode))
            {
                subjectText.text = subjectMap[subjectCode];
            }
            else
            {
                subjectText.text = $"Unknown ({subjectCode})";
            }
        }
        
    }
}
