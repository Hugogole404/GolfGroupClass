using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndFire : MonoBehaviour
{
    [Header("Scripts utilisés")]
    [SerializeField] BallController ballController;

    void Awake()
    {
        plane = new Plane(Vector3.up, 0);
    }

    #region Rayon
    private Plane plane;
    private Ray mousePositionRay;
    private Vector3 hitPoint = Vector3.zero;
    private Vector3 playerPositionOnPlane = Vector3.zero;
    //private 

    private void OnMouseUp()
    {
        //peut etre des trucs à faire quand on relache le click
    }
    private void OnMouseDrag()
    {
        mousePositionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(mousePositionRay, out var enter))
        {
            hitPoint = mousePositionRay.GetPoint(enter);
            playerPositionOnPlane = plane.ClosestPointOnPlane(transform.position);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = hitPoint - playerPositionOnPlane;
        direction = direction.magnitude > ballController.MaxPower ? direction.normalized * ballController.MaxPower : direction;
        Gizmos.DrawLine(playerPositionOnPlane, playerPositionOnPlane + direction);

    }
    #endregion
}
