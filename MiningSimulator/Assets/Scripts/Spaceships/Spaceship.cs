using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour
{
    public SpaceshipData spaceshipData;
    public Planet planet;
    public MotherShip motherShip;

    private float currentCargoSize;
    private float currentSpeed;
    private float nextCargoUpgradeCost;
    private float nextSpeedUpgradeCost;

    private enum State { Loading, ToMotherShip, Unloading, Returning }
    private State currentState;

    void Start()
    {
        InitializeSpaceship();
        StartCoroutine(TransportRoutine());
    }

    void InitializeSpaceship()
    {
        currentCargoSize = spaceshipData.baseCargoSize;
        currentSpeed = spaceshipData.baseSpeed;
        nextCargoUpgradeCost = spaceshipData.cargoUpgradeCost;
        nextSpeedUpgradeCost = spaceshipData.speedUpgradeCost;
    }

    IEnumerator TransportRoutine()
    {
        while (true)
        {
            currentState = State.Loading;
            yield return StartCoroutine(LoadResources());

            currentState = State.ToMotherShip;
            yield return StartCoroutine(MoveToPosition(motherShip.transform.position));

            currentState = State.Unloading;
            yield return StartCoroutine(UnloadResources());

            currentState = State.Returning;
            yield return StartCoroutine(MoveToPosition(planet.transform.position));
        }
    }

    IEnumerator LoadResources()
    {
        // Simuliere das Laden von Ressourcen
        yield return new WaitForSeconds(1f); // Wartezeit für das Laden
    }

    IEnumerator UnloadResources()
    {
        // Simuliere das Entladen von Ressourcen
        float unloadedAmount = currentCargoSize;
        motherShip.ReceiveResources(unloadedAmount);
        yield return new WaitForSeconds(1f); // Wartezeit für das Entladen
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void UpgradeCargoSize()
    {
        // Überprüfe, ob der Spieler genügend Ressourcen hat (muss noch implementiert werden)
        currentCargoSize += spaceshipData.baseCargoSize; // Oder eine andere Logik
        nextCargoUpgradeCost *= 1.5f; // Erhöhe die Upgrade-Kosten
    }

    public void UpgradeSpeed()
    {
        // Überprüfe, ob der Spieler genügend Ressourcen hat (muss noch implementiert werden)
        currentSpeed += spaceshipData.baseSpeed; // Oder eine andere Logik
        nextSpeedUpgradeCost *= 1.5f; // Erhöhe die Upgrade-Kosten
    }
}