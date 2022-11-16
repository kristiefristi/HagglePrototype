using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HaggleSystem : MonoBehaviour
{
    public ProductSO currentProduct;

    [Header("Components")]
    public PriceSelector priceSelector;
    public TextMeshProUGUI productName;
    public TextMeshProUGUI basePrice;
    public Image productImage;

    private void Start()
    {
        SetProduct(currentProduct);
    }

    public void SetProduct(ProductSO product)
    {
        productName.text = product.productName;
        basePrice.text = $"{product.basePrice}g";
        productImage.sprite = product.sprite;

        priceSelector.SetPrice(product.basePrice);
    }
}
