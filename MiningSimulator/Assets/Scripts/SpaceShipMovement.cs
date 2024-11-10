using UnityEngine;

public class SpaceshipMovement2D : MonoBehaviour
{
    public Transform planetA;
    public Transform planetB;
    public float speed = 5.0f;

    private Vector3 target;
    private bool atDestination = false;

    void Start()
    {
        target = planetA.position;
    }

    void Update()
    {
        MoveTowardsTarget();
        if (atDestination)
        {
            RotateShip();
            atDestination = false;
        }
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Überprüfen, ob das Raumschiff am Ziel angekommen ist
        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            atDestination = true;
            target = target == planetA.position ? planetB.position : planetA.position;
        }
    }

    private void RotateShip()
    {
        // Dreht das Raumschiff um 180 Grad um die Z-Achse
        transform.Rotate(0, 0, 180);
    }
}
