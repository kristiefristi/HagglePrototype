using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Product", menuName = "Scriptable Objects/Product", order = 1)]
public class ProductSO : ScriptableObject
{
    public string productName;
    public int basePrice;
    public Sprite sprite;
}
