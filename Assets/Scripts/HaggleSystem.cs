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
    }
}
