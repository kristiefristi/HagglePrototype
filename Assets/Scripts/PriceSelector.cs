using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriceSelector : MonoBehaviour
{

    public List<TextMeshProUGUI> digits;
    public TextMeshProUGUI percentageText;

    private int basePrice = 0;

    public int Percentage
    {
        get
        {
            float p = (float)GetPrice() / (float)basePrice;
            return (int)(p * 100);
        }
    }

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

        UpdatePercentage();
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

        UpdatePercentage();
    }

    private void UpdatePercentage()
    {
        percentageText.text = Percentage.ToString();   
    }

    public int GetPrice()
    {
        string p = "";

        for (int i = digits.Count - 1; i >= 0; i--)
        {
            p += digits[i].text;
        }

        int price = int.Parse(p);

        return price;
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

        UpdatePercentage();
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

    public void ResetPrice()
    {
        SetPrice(basePrice);
    }
}
