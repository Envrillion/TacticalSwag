using UnityEngine;
using System.Collections;

// Source : http://wiki.unity3d.com/index.php/MouseCameraControl
public class CameraMouvement : MonoBehaviour {
	public enum MouseButton { Left = 0, Right = 1, Middle = 2, None = 3 }


	[System.Serializable]
	// Translatons of camera. Add rotation??
	public class MouseCtrlConfiguration{
		public bool activate;
		public MouseButton mouseButton;
		public float sensitivity;
		public float xMinLimit;
		public float xMaxLimit;
		public float yMinLimit;
		public float yMaxLimit;

		public bool isActivated(){
			return activate && Input.GetMouseButton((int)mouseButton);
		}
	}

	[System.Serializable]
	// Scroll
	public class MouseScrollConfiguration	{	
		public bool activate;
		public float sensitivity;
		
		public bool isActivated(){
			return activate;
		}
	}
	
	// Ttranslation default configuration
	public MouseCtrlConfiguration translation = new MouseCtrlConfiguration { mouseButton = MouseButton.Right, sensitivity = 0.5F, xMinLimit = 0F, xMaxLimit = 13.5F, yMinLimit = 0F, yMaxLimit = 13.5F };

	// Scroll default configuration
	public MouseScrollConfiguration scroll = new MouseScrollConfiguration { sensitivity = 2F };

	// Default unity names for mouse axes
	public string mouseHorizontalAxisName = "Mouse X";
	public string mouseVerticalAxisName = "Mouse Y";
	public string scrollAxisName = "Mouse ScrollWheel";

	void LateUpdate(){

		if (translation.isActivated()){
			float translateX = Input.GetAxis(mouseHorizontalAxisName) * translation.sensitivity;
			float translateY = Input.GetAxis(mouseVerticalAxisName) * translation.sensitivity;
			transform.position = new Vector3(Mathf.Clamp(transform.position.x - translateX, translation.xMinLimit, translation.xMaxLimit),
			                                 Mathf.Clamp(transform.position.y  - translateY, translation.yMinLimit, translation.yMaxLimit),
			                                 transform.position.z);
		}

		if (scroll.isActivated()){ // zoom doesnt work
			float translateZ = Input.GetAxis(scrollAxisName) * scroll.sensitivity;
			
			transform.Translate(0, 0, translateZ);
		}
	}
}
