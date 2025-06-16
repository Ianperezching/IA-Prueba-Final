using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterVehiculoVillager : IACharacterVehiculo
{
    // Puedes personalizar el comportamiento si lo deseas

    public override void MoveToPosition(Vector3 pos)
    {
        base.MoveToPosition(pos);
    }

    public override void MoveToAllied()
    {
        base.MoveToAllied();
    }

    public override void MoveToEvadEnemy()
    {
        base.MoveToEvadEnemy();
    }

    public override void Wander()
    {
        base.Wander();
    }
}
