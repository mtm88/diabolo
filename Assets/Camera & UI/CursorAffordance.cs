using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (CameraRaycaster))]
public class CursorAffordance : MonoBehaviour {

    [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);
    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D attackCursor = null;
    [SerializeField] Texture2D raycastEndCursor = null;
    CameraRaycaster cameraRaycaster;
    
	// Use this for initialization
	void Start () {
		cameraRaycaster = GetComponent<CameraRaycaster>();
        cameraRaycaster.onLayerChange += OnLayerChanged;
	}

	// Update is called once per frame
	void OnLayerChanged(Layer newLayer) {
        Texture2D cursorToApply = null;

        switch (newLayer)
        {
            case Layer.Walkable:
                cursorToApply = walkCursor;
                break;
            case Layer.Enemy:
                cursorToApply = attackCursor;
                break;
            case Layer.RaycastEndStop:
                cursorToApply = raycastEndCursor;
                break;
            default:
                Debug.LogError("Don't know which cursor to show");
                return;
        }
        Cursor.SetCursor(cursorToApply, cursorHotspot, CursorMode.Auto);
	}

    // TODO consider de-registering OnLayerChanged on leaving all game scenes
}
