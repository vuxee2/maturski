using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
public class FillOcene : MonoBehaviour
{
    public GameObject OcenaPref;

    public Transform ScrollViewContent;

    private string oceneTemp;

    void Start()
    {
        oceneTemp = DBManager.ocene;

        var subjectMap = new Dictionary<string, string>()
        {
            {"s", "Српски језик и књизевност"},
            {"m", "Математика"},
            {"e", "Енглески језик"},
            {"fzc", "Физичко васпитање"},
            {"fiz", "Физика"},
            {"nem", "Немачки језик"},
            {"asa", "Анализа са алгебром"},
            //treba se doda jos, mrzi me sad malo
        };

        var matches = Regex.Matches(oceneTemp, @"([a-zA-Z]+)(\d)");

        foreach (Match match in matches)
        {
            string subjectCode = match.Groups[1].Value;
            string grade = match.Groups[2].Value;

            var instance = Instantiate(OcenaPref, ScrollViewContent);

            var subjectText = instance.transform.Find("PredmetTXT").GetComponent<TextMeshProUGUI>();
            var gradeText = instance.transform.Find("OcenaTXT").GetComponent<TextMeshProUGUI>();

            gradeText.text = grade;
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
