using UnityEngine;

public class AnimationEventForwarder : MonoBehaviour
{
    public PlayerController playerController;

    public void StartKick()
    {
        playerController.StartKick();
    }

    public void EndKick()
    {
        playerController.EndKick();
    }
}
