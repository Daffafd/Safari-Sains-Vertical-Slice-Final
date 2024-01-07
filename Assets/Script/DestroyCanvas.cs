using UnityEngine;
using UnityEngine.UI;

public class DestroyCanvas : MonoBehaviour
{
    public Button destroyButton;
    public Canvas canvasToDestroy;

    void Start()
    {
        // Ensure the destroyButton is assigned and has a onClick listener
        if (destroyButton != null)
        {
            destroyButton.onClick.AddListener(DestroyCanvasOnClick);
        }
        else
        {
            Debug.LogError("Destroy Button not assigned!");
        }
    }

    void DestroyCanvasOnClick()
    {
        // Ensure the canvasToDestroy is assigned before destroying
        if (canvasToDestroy != null)
        {
            Destroy(canvasToDestroy.gameObject);
        }
        else
        {
            Debug.LogError("Canvas to destroy not assigned!");
        }
    }
}
