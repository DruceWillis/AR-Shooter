using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrenadeController : MonoBehaviour
{
    [SerializeField] GameObject grenadesText;

    public int grenades = 3;
    private const int MAX_GRENADES = 5;

    void Start()
    {
        
    }

    void Update()
    {
        grenadesText.GetComponent<TextMeshProUGUI>().text = grenades + "";
    }

    public void PickUpGrenades()
    {
        if (grenades <  MAX_GRENADES - 3)
            grenades += 3;
        else
            grenades = MAX_GRENADES;
    }
}
