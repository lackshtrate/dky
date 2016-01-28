using UnityEngine;
using System.Collections.Generic;

public class movement : MonoBehaviour {
    public Transform cam;
    public float speed = 0;
    public CharacterController chara;
    [SerializeField]
    private List<Color> colors = new List<Color>();
    [SerializeField]
    private Material mat;
    private int curColor = 0;
    private int nextColor = 0;
    // Update is called once per frame
    void Update () {
        Vector3 dir = Vector3.zero;// new Vector3(Input.GetAxisRaw("Horizontal") + Input.GetAxisRaw("Mouse Y"), 0, Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("Mouse X"));
        if (Input.GetAxisRaw("Mouse Y") != 0) {
            if (curColor == nextColor) {
                if (Input.GetAxisRaw("Mouse Y") > 0.5f)
                    nextColor = Mathf.Clamp(curColor + 1, 0, colors.Count-1);
                else if (Input.GetAxisRaw("Mouse Y") < -0.5f)
                    nextColor = Mathf.Clamp(curColor - 1, 0, colors.Count-1);
                if (mat != null)
                    mat.color = colors[nextColor];
            }
        } else if (curColor != nextColor) {
            curColor = nextColor;
        }

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
