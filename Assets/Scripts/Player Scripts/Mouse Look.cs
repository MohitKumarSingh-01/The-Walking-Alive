using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region Singleton
    public static MouseLook instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More then one instance found!");
            return;
        }

        instance = this;
    }
    #endregion

    [SerializeField]
    private Transform playerRoot, lookRoot;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private float sensivity = 5f;

    [SerializeField]
    private Vector2 default_Look_limit = new Vector2(-70f, 80f);

    private Vector2 mouseAngle;

    private Vector2 current_Mouse_Look;

    public bool openPanel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        openPanel = false;
    }

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            LookAround();
        }
    }


    void LookAround()
    {

        current_Mouse_Look = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        mouseAngle.x += current_Mouse_Look.x * sensivity * (invert ? 1f : -1f);
        mouseAngle.y += current_Mouse_Look.y * sensivity;

        mouseAngle.x = Mathf.Clamp(mouseAngle.x, default_Look_limit.x, default_Look_limit.y);

        lookRoot.localRotation = Quaternion.Euler(mouseAngle.x, 0f, 0f);
        playerRoot.localRotation = Quaternion.Euler(0f, mouseAngle.y, 0f);
    }

}




























































































