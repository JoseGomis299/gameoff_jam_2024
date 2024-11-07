using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityUtils;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform pointOfView;
    [SerializeField] private AdvancedController.PlayerController playerController;
    [SerializeField] private float yLerpTime = 0.02f;
    [SerializeField] private float minHeightToLerp = 0.2f;
    [SerializeField, Min(0.01f)] private Vector2 sensitivity = new Vector2(1, 1);

    private float _yLerpSpeed = 0.1f;
    private Vector2 _input;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        transform.position = pointOfView.position;
        playerController = pointOfView.GetComponentInParent<AdvancedController.PlayerController>();
    }

    private void Update()
    {
        _input += InputManager.Instance.LookInput.Multiply(y:-1).Multiply(Time.deltaTime*sensitivity);
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(pointOfView.position.x, pointOfView.position.y, pointOfView.position.z);
        transform.rotation = Quaternion.Euler(_input.y, _input.x, 0);
        playerController.transform.rotation = Quaternion.Euler(0, _input.x, 0);
    }
}