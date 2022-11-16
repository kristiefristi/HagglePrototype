using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriceSelector : MonoBehaviour
{

    public List<TextMeshProUGUI> digits;

    public void IncreasePrice(TextMeshProUGUI tmp)
    {
        int count = int.Parse(tmp.text);

        if (count + 1 > 9 && tmp == digits[digits.Count - 1])
        {
            return;
        }
        else if (count + 1 > 9)
        {
            count = 0;
            IncreasePrice(digits[digits.IndexOf(tmp) + 1]);
        }
        else
        {
            count++;
        }

        tmp.text = count.ToString();
    }
}
