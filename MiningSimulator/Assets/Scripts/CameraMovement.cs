using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public Camera cam;
    private Vector3 previousPosition;

    void Update()
    {
        if (MainScreenController.isDraggingMainScreen){
            return;
        }
        // Touch-Eingabe
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            // Bei Beginn des Touches
            if (touch.phase == TouchPhase.Began)
            {
                previousPosition = cam.ScreenToWorldPoint(touch.position);
            }
            // Während der Bewegung
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 direction = previousPosition - cam.ScreenToWorldPoint(touch.position);
                cam.transform.position += direction;
            }
        }
        // Maus-Eingabe
        else if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = previousPosition - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += direction;
        }
    }
}
