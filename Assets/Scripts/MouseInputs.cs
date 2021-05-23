
using UnityEngine;

public class MouseInputs 
{
    public readonly Camera _cam;
    
    public MouseInputs()
    {
        _cam = Camera.main;
    }
    
    public  Vector3 GetMousePos()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 vector = Vector3.zero;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Ground"))
                vector = hit.point;
        }
        return vector;
    }
}
