using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    public Transform cam;
    public float speed = 0;
    public CharacterController chara;
	// Use this for initialization
	// Update is called once per frame
	void Update () {
        Vector3 dir = Vector3.zero;// new Vector3(Input.GetAxisRaw("Horizontal") + Input.GetAxisRaw("Mouse Y"), 0, Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("Mouse X"));
        if (Input.GetMouseButton(0)) {
            dir = Vector3.forward;
        }
      
        if (dir != Vector3.zero)
        {
            if (cam != null)
                dir = cam.rotation*dir;
            dir.y = 0;
            dir.Normalize();
            dir *= speed * Time.deltaTime;
            if (chara != null)
                chara.Move(dir);
        }
	}
}
