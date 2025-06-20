using UnityEngine;

public class IACharacterVehiculoGolem : IACharacterVehiculo
{
    private Vector3 initialPosition;
    public Vector3 InitialPosition => initialPosition;
    private float returnThreshold = 0.5f; // Distancia mínima para considerar que llegó a su posición inicial

    // Puedes personalizar el comportamiento si lo deseas
    void Start()
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
