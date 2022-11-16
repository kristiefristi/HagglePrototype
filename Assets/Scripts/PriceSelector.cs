using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriceSelector : MonoBehaviour
{

    public List<TextMeshProUGUI> digits;

    private int basePrice = 0;

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

    public void DecreasePrice(TextMeshProUGUI tmp)
    {
        int count = int.Parse(tmp.text);

        if (count - 1 < 0)
        {
            count = 9;
            if (CheckIfAllZero(tmp) == false)
            {
                DecreasePrice(digits[digits.IndexOf(tmp) + 1]);
            }
        }
        else
        {
            count--;
        }

        tmp.text = count.ToString();
    }

    public void SetPrice(int price)
    {
        basePrice = price;

        char[] priceChars = basePrice.ToString().ToCharArray();
        System.Array.Reverse(priceChars);

        for (int i = 0; i < digits.Count; i++)
        {
            if (i <= priceChars.Length - 1)
            {
                digits[i].text = priceChars[i].ToString();
            }
            else
            {
                digits[i].text = "0";
            }
        }
    }

    private bool CheckIfAllZero(TextMeshProUGUI start)
    {
        int startIndex = digits.IndexOf(start);

        for (int i = startIndex + 1; i < digits.Count; i++)
        {
            if (int.Parse(digits[i].text) != 0)
            {
                return false;
            }
        }

        return true;
    }

    //TODO: Reset to base price instead of 0000
    public void ResetPrice()
    {
        SetPrice(basePrice);
    }
}
