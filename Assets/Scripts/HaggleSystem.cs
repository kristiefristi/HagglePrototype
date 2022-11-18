using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HaggleSystem : MonoBehaviour
{
    public List<ProductSO> products;
    public List<CustomerSO> customers;

    [Header("Components")]
    public PriceSelector priceSelector;
    public TextMeshProUGUI productName;
    public TextMeshProUGUI basePrice;
    public Image productImage;
    public TextMeshProUGUI customerArchetype;
    public TextMeshProUGUI patienceText;

    private CustomerSO currentCustomer;
    private int tolerance;
    private int basePercentage = 100;
    private int patienceLevel = 0;
    private ProductSO currentProduct;

    private void Start()
    {
        currentProduct = products.GetRandom();
        SetProduct(currentProduct);
        NewCustomer();
    }

    public void SetProduct(ProductSO product)
    {
        productName.text = product.productName;
        basePrice.text = $"{product.basePrice}g";
        productImage.sprite = product.sprite;

        priceSelector.SetPrice(product.basePrice);
    }

    public void NewCustomer()
    {
        basePercentage = 100;

        currentCustomer = customers.GetRandom();
        customerArchetype.text = currentCustomer.archetype;
        SetPatienceLevel(currentCustomer.initialPatience);
        basePercentage -= currentCustomer.basePricePenalty;

        tolerance = Random.Range((int)currentCustomer.toleranceMinMax.x, (int)currentCustomer.toleranceMinMax.y);
        Debug.Log($"{tolerance}");
        Debug.Log($"Accept Bid: {basePercentage}%-{basePercentage + tolerance}%\n" +
            $"Lose 1 Patience: {basePercentage + tolerance}%-{basePercentage + tolerance + (tolerance / 2)}%\n" +
            $"Lose 2 Patience: {basePercentage + tolerance + (tolerance / 2)}%-{basePercentage + tolerance + ((tolerance / 2) * 2)}%\n" +
            $"Lose 3 Patience: {basePercentage + tolerance + ((tolerance / 2) * 2)}%+");
    }

    private void SetPatienceLevel(int level)
    {
        patienceLevel = level;
        patienceText.text = patienceLevel.ToString();
    }

    public void SuggestPrice()
    {
        int suggestedPercentage = priceSelector.Percentage;

        if (suggestedPercentage >= basePercentage && suggestedPercentage < basePercentage + tolerance) //Accept Bid!
        {
            Debug.Log("i'll faking  take it amet0");
        }
        else if (suggestedPercentage >= basePercentage + tolerance && suggestedPercentage < basePercentage + tolerance + (tolerance / 2)) //Patience -1
        {
            SetPatienceLevel(patienceLevel - 1);
        }
        else if (suggestedPercentage >= basePercentage + tolerance + (tolerance / 2) && suggestedPercentage < basePercentage + tolerance + ((tolerance / 2) * 2)) //Patience -2
        {
            SetPatienceLevel(patienceLevel - 2);
        }
        else if (suggestedPercentage >= basePercentage + tolerance + ((tolerance / 2) * 2)) //Patience -3
        {
            SetPatienceLevel(patienceLevel - 3);
        }
    }
}
