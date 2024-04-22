using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera firstPersonCamera;
    [SerializeField] private CinemachineFreeLook thirdPersonCamera;

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

        if (Input.GetKeyDown(KeyCode.R) && thirdPersonCamera.enabled)
        {
            // Reset the third person camera to the default view
            thirdPersonCamera.m_XAxis.Value = 0f;
            thirdPersonCamera.m_YAxis.Value = 0.5f;
        }
    }
}
