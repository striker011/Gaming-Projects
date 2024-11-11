using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public UIDocument uiDocument;

    // Öffentliche Referenzen zu den UI-Elementen
    public static VisualElement root { get; private set; }
    public static VisualElement mainScreen { get; private set; }
    public static Button mainShipButton { get; private set; }
    public static Button managerButton { get; private set; }
    public static Button workshopButton { get; private set; }

    void Awake()
    {
        // Initialisiere die UI-Elemente
        InitializeUIElements();
    }

    private void InitializeUIElements()
    {
        if (uiDocument == null)
        {
            Debug.LogError("UIDocument ist nicht zugewiesen.");
            return;
        }

        root = uiDocument.rootVisualElement;

        // Abfragen der UI-Elemente
        mainScreen = root.Q<VisualElement>("mainScreen");
        mainShipButton = root.Q<Button>("mainShip");
        managerButton = root.Q<Button>("manager");
        workshopButton = root.Q<Button>("workshop");

        // Überprüfe, ob die Elemente gefunden wurden
        if (mainScreen == null) Debug.LogError("MainScreen wurde nicht gefunden.");
        if (mainShipButton == null) Debug.LogError("MainShipButton wurde nicht gefunden.");
        if (managerButton == null) Debug.LogError("ManagerButton wurde nicht gefunden.");
        if (workshopButton == null) Debug.LogError("WorkshopButton wurde nicht gefunden.");
    }

    void Update(){

    }
    void Start(){

    }
}
