
using UnityEngine;

public class follow_player : MonoBehaviour
{
    public Transform target;
    public Transform stats;
    public float cameraDistance = 30.0f;

    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }
    void LateUpdate()
    {
        if(!(target.position.y < -42))
            if(!(target.position.y > 46))
            transform.position = new Vector3(target.position.x, target.position.y+2, transform.position.z);
       

    }
}
