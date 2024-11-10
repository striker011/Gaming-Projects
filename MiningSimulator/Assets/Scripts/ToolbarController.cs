using UnityEngine;
using UnityEngine.UIElements;
using System;
public class Toolbar_Controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static event Action OnMainShipButtonClicked;
    public UIDocument uiDocument;
    private Button mainShipButton;
    private Button managerButton;
    private Button workshopButton;

    void Start()
    {
        var root = uiDocument.rootVisualElement;
        mainShipButton = root.Q<Button>("mainShip");
        managerButton = root.Q<Button>("manager");
        workshopButton = root.Q<Button>("workshop");

        managerButton.clicked += () => OpenView("Manager");
        workshopButton.clicked += () => OpenView("Workshop");

        mainShipButton.clicked += () =>
        {
            OpenView("MainShip");
            OnMainShipButtonClicked?.Invoke();
        };
    }

    void OpenView(string viewName)
    {
        // Implementiere hier die Logik zum Öffnen der jeweiligen Ansicht
        Debug.Log("Öffne Ansicht: " + viewName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
