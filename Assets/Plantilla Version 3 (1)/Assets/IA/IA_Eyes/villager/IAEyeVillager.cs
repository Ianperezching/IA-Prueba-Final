using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeVillager : IAEyeBase
{
    // Puedes agregar lógica personalizada aquí si lo necesitas

    void Start()
    {
        LoadComponent();
    }

    void Update()
    {
        UpdateScan();
    }
}
