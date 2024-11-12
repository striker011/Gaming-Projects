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

        // MainScreen initial ausblenden
        mainScreen.style.height = new StyleLength(0f);
    }

    void ShowMainScreen()
    {
        // Bringe den mainScreen nach vorne
        mainScreen.BringToFront();

        // Setze die Höhe auf einen Startwert, z.B. 30% der Bildschirmhöhe
        mainScreen.style.height = new StyleLength(new Length(85, LengthUnit.Percent));

    }

    void HideMainScreen()
    {
        // Blende den MainScreen aus
        mainScreen.style.height = new StyleLength(0f);
    }
}
