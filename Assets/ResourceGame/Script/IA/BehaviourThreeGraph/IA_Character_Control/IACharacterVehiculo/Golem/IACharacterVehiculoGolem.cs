using UnityEngine;

public class IACharacterVehiculoGolem : IACharacterVehiculo
{
    private Vector3 initialPosition;
    public Vector3 InitialPosition => initialPosition;
    
    // Puedes personalizar el comportamiento si lo deseas
    void Awake()
    {
        this.LoadComponent();
        initialPosition = transform.position;
    }

    public override void LoadComponent()
    {
        base.LoadComponent();

    }
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
    private void OnDrawGizmos()
    {
        if (!IsDrawGizmo) { return; }
        base.DrawGizmos();
    }
}
