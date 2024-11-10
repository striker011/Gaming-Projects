using UnityEngine;

public class PlanetTouch : MonoBehaviour
{
    void Start(){

    }
    void Update()
    {
            // Überprüfen auf Mausklick
        if (Input.GetMouseButtonDown(0)) // 0 steht für die linke Maustaste
        {
            CheckTouch(Input.mousePosition);
        }

        // Überprüfen auf Touch-Eingabe
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Erster Touch-Punkt
            if (touch.phase == TouchPhase.Began) // Nur bei neuem Touch reagieren
            {
                CheckTouch(touch.position);
            }
        }
    }

    private void CheckTouch(Vector3 pos)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == this.gameObject)
        {
            OnPlanetClicked();
        }
    }

    private void OnPlanetClicked()
    {
        // Hier kannst du definieren, was passieren soll, wenn der Planet angeklickt wird
        Debug.Log(gameObject.name + " wurde angeklickt!");
    }
}
