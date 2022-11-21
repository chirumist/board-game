[System.Serializable]
public class ApiList
{
    private static string baseUrl = "http://127.0.0.1:8000/api";

    public string loginUrl = baseUrl + "/login";

    public string registerUrl = baseUrl + "/register";
}
