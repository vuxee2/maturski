using UnityEngine;

public static class DBManager
{
    public static string jmbg;

    public static bool LoggedIn { get { return jmbg != null; } }
    public static void LogOut()
    {
        jmbg = null;
    }
}
