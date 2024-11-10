using UnityEngine;
using UnityEngine.UIElements;

public class MainScreenController : MonoBehaviour
{
    public UIDocument uiDocument;
    private VisualElement root;
    private VisualElement mainScreen;
    private VisualElement dragHandle;
    private Button mainShipButton;

    private bool isDragging = false;
    private float startMousePositionY;
    private float startHeight;

    public static bool isDraggingMainScreen = false;

    void Start()
    {
        root = uiDocument.rootVisualElement;
        mainScreen = root.Q<VisualElement>("mainScreen");
        dragHandle = mainScreen.Q<VisualElement>("dragHandle");
        mainShipButton = root.Q<Button>("mainShip");

        // MainScreen initial ausblenden
        mainScreen.style.height = new StyleLength(0f);

        // Event Listener für den Hauptschiff-Button
        mainShipButton.clicked += ShowMainScreen;

        // Event Listener für den Drag Handle

        mainScreen.RegisterCallback<PointerDownEvent>(OnPointerDown);
        mainScreen.RegisterCallback<PointerMoveEvent>(OnPointerMove);
        mainScreen.RegisterCallback<PointerUpEvent>(OnPointerUp);
    }
    void OnEnable()
    {
        Toolbar_Controller.OnMainShipButtonClicked += ShowMainScreen;
    }

    void OnDisable()
    {
        Toolbar_Controller.OnMainShipButtonClicked -= ShowMainScreen;
    }

    void ShowMainScreen()
    {
        // Setze die Höhe auf einen Startwert, z.B. 30% der Bildschirmhöhe
        mainScreen.style.height = new StyleLength(new Length(30, LengthUnit.Percent));
    }

    void OnPointerUp(PointerUpEvent evt)
    {
        isDragging = true;
        isDraggingMainScreen = true;
        startMousePositionY = evt.position.y;
        startHeight = mainScreen.layout.height;
        evt.StopPropagation(); // Verhindert, dass andere Elemente das Event erhalten
    }

    void OnPointerMove(PointerMoveEvent evt)
    {
        if (isDragging)
        {
            float deltaY = evt.position.y - startMousePositionY;
            float newHeight = startHeight + deltaY;

            // Begrenzungen setzen (z.B. min 0%, max 100%)
            float minHeight = 0;
            float maxHeight = root.layout.height - 50; // Abzüglich der Toolbar-Höhe

            newHeight = Mathf.Clamp(newHeight, minHeight, maxHeight);

            mainScreen.style.height = new StyleLength(newHeight);

            evt.StopPropagation();
        }
    }

    void OnPointerDown(PointerDownEvent evt)
    {
        isDragging = false;
        isDraggingMainScreen = false;

        float currentHeight = mainScreen.resolvedStyle.height;
         // Überprüfen, ob die Höhe nahe 0 ist
        if (currentHeight < 50)
        {
            // MainScreen ausblenden
            mainScreen.style.height = new StyleLength(0f);
        }
        evt.StopPropagation();
    }
}