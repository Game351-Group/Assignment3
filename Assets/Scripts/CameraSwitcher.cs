using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera firstPersonCamera;
    [SerializeField] private CinemachineVirtualCamera thirdPersonCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Start with third person view by default
        thirdPersonCamera.enabled = true;
        firstPersonCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Toggle the enabled state of the cameras
            thirdPersonCamera.enabled = !thirdPersonCamera.enabled;
            firstPersonCamera.enabled = !firstPersonCamera.enabled;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reset to default view, typically third person
            if (thirdPersonCamera.enabled)
            {
                // Implement logic to reset third person camera orientation if needed
            }
        }
    }
}
