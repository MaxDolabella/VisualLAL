using System.Text.RegularExpressions;

public static class TextHelper
{
    public static bool ContainsExtactExpression(this string s, string expression)
    {
        var pattern = $@"(\b{expression}\b)";
        var r = new Regex(pattern);
        return r.IsMatch(s);
    }
}

