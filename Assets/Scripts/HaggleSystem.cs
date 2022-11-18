using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HaggleSystem : MonoBehaviour
{
    public ProductSO currentProduct;
    public List<CustomerSO> customers;

    [Header("Components")]
    public PriceSelector priceSelector;
    public TextMeshProUGUI productName;
    public TextMeshProUGUI basePrice;
    public Image productImage;
    public TextMeshProUGUI customerArchetype;
    public TextMeshProUGUI patienceLevel;

    private CustomerSO currentCustomer;
    private int tolerance;

    private void Start()
    {
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
        currentCustomer = customers.GetRandom();
        customerArchetype.text = currentCustomer.archetype;
        patienceLevel.text = currentCustomer.initialPatience.ToString();

        tolerance = Random.Range((int)currentCustomer.toleranceMinMax.x, (int)currentCustomer.toleranceMinMax.y);
        Debug.Log($"{tolerance}");
        Debug.Log($"Accept Bid: 100%-{100 + tolerance}%\n" +
            $"Lose 1 Patience: {100 + tolerance}%-{100 + tolerance + (tolerance / 2)}%\n" +
            $"Lose 2 Patience: {100 + tolerance + (tolerance / 2)}%-{100 + tolerance + ((tolerance / 2) * 2)}%\n" +
            $"Lose 3 Patience: {100 + tolerance + ((tolerance / 2) * 2)}%+");
    }

    public void SuggestPrice()
    {

    }
}
