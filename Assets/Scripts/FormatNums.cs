using UnityEngine;

public static class FormatNums
{
    private static string[] names = new[]
    {
        "",
        "k",
        "м",
        "в",
        "т",
        "q"
    };

    public static string FormatNum(double num)
    {
        if (num == 0) return "0";
        num = Mathf.Round((float) num);

        int i = 0;
        while (i + 1 < names.Length && num >= 1000d)
        {
            num /= 1000d;
            i++;
        }

        return num.ToString("#.#") + names[i];
    }
}
