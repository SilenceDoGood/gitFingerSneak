using UnityEngine;
using System.Collections;


public class InputCon
{
    public static bool touched = false;
    
    //GENERIC CLASS METHODS
    public static bool BeingTouched (){
        if (Input.touchCount > 0) 
        {
            touched = true;
        } 
        else 
        {
            touched = false;
        }
        return touched;
    }
    
    public static bool TouchedObject (string objectName, Touch input)
    {
        Ray ray = Camera.main.ScreenPointToRay(input.position);
        RaycastHit hitInfo = new RaycastHit();
        Physics.Raycast(ray, out hitInfo);
        
        if (hitInfo.collider.gameObject.name == objectName || hitInfo.collider.gameObject.name == "Vision") 
        {
            return true;
        } 
        else 
        {
            return false;
        }
    }
    
    public static float GetDistanceToObject (string objectName, Touch input) 
    {
        float distance;
        
        Ray ray = Camera.main.ScreenPointToRay(input.position);
        RaycastHit hitInfo = new RaycastHit();
        Physics.Raycast(ray, out hitInfo);
        
        if(hitInfo.collider.gameObject.name == objectName)
        {
            distance = hitInfo.distance;
        } 
        else 
        {
            distance = 0.0f;
        }
        return distance;
    }
    
    public static Vector3 CalcWorldPosition (Touch touchPos, float distance)
    {
        Vector3 newPos = touchPos.position;
        newPos.z = distance;
        var worldPosition = Camera.main.ScreenToWorldPoint(newPos);
        return worldPosition;
    }
    
    public static float DistanceBetween (string objectName)
    {
        var posA = CalcWorldPosition(Input.GetTouch(0), GetDistanceToObject(objectName, Input.GetTouch(0)));
        var posB = CalcWorldPosition(Input.GetTouch(1), GetDistanceToObject(objectName, Input.GetTouch(1)));
        return Vector3.Distance(posA, posB);
    }
    
    
    //Function: Angle between two points
    //Function: Player transform using get and set 
    
}