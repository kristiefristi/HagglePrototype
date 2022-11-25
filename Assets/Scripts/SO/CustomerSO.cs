using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Customer", menuName = "Scriptable Objects/Customer", order = 1)]
public class CustomerSO : ScriptableObject
{
    public string archetype;
    public int initialPatience;
    public Vector2 toleranceMinMax;
    public int basePricePenalty;

    [Header("Dialogue")]
    public string interested;
    public string penalty1;
    public string penalty2;
    public string penalty3;
    public string acceptBid;
    public string fail;
}
