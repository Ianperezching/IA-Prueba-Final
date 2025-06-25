using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IACharacterActionsVillager : IACharacterActions
{
    public float FrameRate = 0;
    public float Rate = 1;

    private IACharacterVehiculo _IACharacterVehiculo; // Agregado

    private void Start()
    {
        LoadComponent();
    }

    public override void LoadComponent()
    {
        base.LoadComponent();
        _IACharacterVehiculo = GetComponent<IACharacterVehiculo>(); // Inicializado
        // Asegúrate de que las referencias estén inicializadas
        // AIEye = GetComponent<IAEyeBase>();
    }

    // Huir del enemigo
    public void EscapeFromEnemy()
    {
        if (AIEye == null || _IACharacterVehiculo == null) return;
        if (AIEye.ViewEnemy == null) return;
        Vector3 dir = (transform.position - AIEye.ViewEnemy.transform.position).normalized;
        Vector3 newPosition = transform.position + dir * 2f;
        _IACharacterVehiculo.MoveToPosition(newPosition);
    }

    // Seguir al golem (aliado)
    public void FollowGolem()
    {
        if (AIEye == null || _IACharacterVehiculo == null) return;
        if (AIEye.ViewAllie == null) return;
        _IACharacterVehiculo.MoveToAllied();
    }
    
}
