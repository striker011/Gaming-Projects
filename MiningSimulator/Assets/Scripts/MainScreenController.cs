using UnityEngine;
using UnityEngine.UIElements;

public class MainScreenController : MonoBehaviour
{
    public VisualElement mainScreen;
    public Button mainShipButton;

    private bool isDragging = false;
    private float startMousePositionY;
    private float startHeight;

    public static bool isDraggingMainScreen = false;

    void Start()
    {
        // Zugriff auf die UI-Elemente über den UIManager
        mainScreen = UIManager.mainScreen;
        mainShipButton = UIManager.mainShipButton;

        if (mainScreen == null || mainShipButton == null )
        {
            Debug.LogError("Ein oder mehrere UI-Elemente sind nicht initialisiert.");
            return;
        }

        mainShipButton.clicked += ShowMainScreen;

        // Event Listener für den MainScreen (für das Dragging)
        mainScreen.RegisterCallback<PointerDownEvent>(OnPointerDown);
        mainScreen.RegisterCallback<PointerMoveEvent>(OnPointerMove);
        mainScreen.RegisterCallback<PointerUpEvent>(OnPointerUp);

        // MainScreen initial ausblenden
        mainScreen.style.height = new StyleLength(0f);
    }

    void ShowMainScreen()
    {
        // Bringe den mainScreen nach vorne
        mainScreen.BringToFront();

        // Setze die Höhe auf einen Startwert, z.B. 30% der Bildschirmhöhe
        mainScreen.style.height = new StyleLength(new Length(30, LengthUnit.Percent));

    }

    void HideMainScreen()
    {
        // Blende den MainScreen aus
        mainScreen.style.height = new StyleLength(0f);
    }

    void OnPointerDown(PointerDownEvent evt)
    {
        isDragging = true;
        isDraggingMainScreen = true;
        startMousePositionY = evt.position.y;
        startHeight = mainScreen.resolvedStyle.height;
        evt.StopPropagation();
    }

    void OnPointerMove(PointerMoveEvent evt)
    {
        if (isDragging)
        {
            // Korrigierte Berechnung von deltaY
            float deltaY = startMousePositionY - evt.position.y;

            float newHeight = startHeight + deltaY;

            mainScreen.style.height = new StyleLength(newHeight);

            // Log der Werte
            Debug.Log($"DeltaY: {deltaY}, New Height: {newHeight}");

            evt.StopPropagation();
        }
    }

    void OnPointerUp(PointerUpEvent evt)
    {
        isDragging = false;
        isDraggingMainScreen = false;

        float currentHeight = mainScreen.resolvedStyle.height;

        // Log der finalen Höhe
        Debug.Log($"Final Height on Pointer Up: {currentHeight}");

        if (currentHeight < 50)
        {
            HideMainScreen();
        }

        evt.StopPropagation();
    }
}
