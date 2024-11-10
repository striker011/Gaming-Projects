using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public Camera cam;
    public float zoomSpeed = 1f;
    public float minZoom = 5f;
    public float maxZoom = 20f;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
        // Zoom mit Touch (Pinch-Geste)
        if (Input.touchCount == 2)
        {
            // Ersten beiden Finger erfassen
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Positionen im vorherigen Frame
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos  = touchOne.position - touchOne.deltaPosition;

            // Berechne die Abstände zwischen den Touchpunkten
            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            // Differenz der Abstände
            float difference = currentMagnitude - prevMagnitude;

            // Zoom anpassen
            cam.orthographicSize -= difference * zoomSpeed * 0.01f;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
    }
}
