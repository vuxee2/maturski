using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class DBManagerProfesor
{
    public static string mail;
    public static string id;
    public static string kod_predmeta;

    public static bool LoggedIn { get { return mail != null; } }
    public static void LogOut()
    {
        mail = null;
        id = null;
        kod_predmeta = null;
    }

    // Lista odeljenja i razreda
    public static List<OdeljenjeInfo> odeljenja = new List<OdeljenjeInfo>();

    public class OdeljenjeInfo
    {
        public string razred;
        public string odeljenje;
    }

    // Metoda za slanje zahteva PHP-u
    public static WWW GetOdeljenjaFromDB()
    {
        WWWForm form = new WWWForm();
        form.AddField("id_profesor", id);
        WWW www = new WWW("http://localhost/sqlconnect/extract_info_profesor.php", form);
        return www;
    }

    // Korutina za update odeljenja sa servera
    public static IEnumerator UpdateOdeljenja()
    {
        WWW www = GetOdeljenjaFromDB();
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError("Greška pri povezivanju: " + www.error);
            yield break;
        }

        string responseText = www.text.Trim();
        Debug.Log("Response: " + responseText);

        if (string.IsNullOrEmpty(responseText))
        {
            Debug.LogWarning("Prazan odgovor sa servera.");
            yield break;
        }

        // Ako server vrati "8" - nema rezultata
        if (responseText == "8")
        {
            Debug.Log("Nema odeljenja za ovog profesora.");
            yield break;
        }

        // Ocisti prethodno
        odeljenja.Clear();

        // Parsiranje plain text odgovora
        string[] lines = responseText.Split(new[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 2)
            {
                OdeljenjeInfo o = new OdeljenjeInfo();
                o.razred = parts[0];
                o.odeljenje = parts[1];
                odeljenja.Add(o);
            }
        }

        Debug.Log("Učitano odeljenja: " + odeljenja.Count);
    }
}
