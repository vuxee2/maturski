using UnityEngine;
using System.Collections;

public static class DBManager
{
    public static string jmbg;
    public static string ocene;

    public static bool LoggedIn { get { return jmbg != null; } }
    public static void LogOut()
    {
        jmbg = null;
        ocene = null;
    }

    public static WWW GetOceneFromDB()
    {
        WWWForm form = new WWWForm();
        form.AddField("jmbg", jmbg);
        WWW www = new WWW("http://localhost/sqlconnect/extract_info.php", form);
        return www;
    }
    public static IEnumerator UpdateOcene()
    {
        WWW www = GetOceneFromDB();
        yield return www;
        ocene = www.text;
    }
}
