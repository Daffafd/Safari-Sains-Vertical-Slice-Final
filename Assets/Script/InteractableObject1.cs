using UnityEngine;

public class InteractableObject1 : MonoBehaviour
{
    public PuzzleManager1 puzzleManager1;
    public PlayerMovement playerMovement;
    public float interactionDistance = 2f;
    private bool isInteracting = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsPlayerNearby1())
            {
                if (isInteracting)
                {
                    UnInteractPlayer();
                }
                else
                {
                    InteractWithObject();
                }
            }
        }
    }

    bool IsPlayerNearby1()
    {
        Vector3 playerPosition = playerMovement.transform.position;
        Vector3 objectPosition = transform.position;
        float distance = Vector3.Distance(playerPosition, objectPosition);
        return distance <= interactionDistance;
    }

    void InteractWithObject()
    {
        puzzleManager1.ShowPuzzle();
        playerMovement.SetCanMove(false);
        isInteracting = true;

    }
    public void UnInteractPlayer()
    {
        playerMovement.SetCanMove(true);
        isInteracting = false;
    }
    public void PlayerFinishInteract()
    {
        playerMovement.SetCanMove(true);
        isInteracting = false;
        Debug.Log("Interaksi Puzzle Selesai");
    }
}


