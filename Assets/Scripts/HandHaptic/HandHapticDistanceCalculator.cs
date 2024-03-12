using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHapticDistanceCalculator : MonoBehaviour
{
    [SerializeField] private List<GameObject> interactableList;
    [SerializeField] private List<Transform> fingerTipTransformList;    
    [SerializeField] private List<Vector3> fingerTipToInteractableMeshPointList;

    [SerializeField] private List<LineRenderer> distanceLineRendererDebug;
    [SerializeField] private List<float> fingerTipToInteractableDistanceList;

    [SerializeField] private GameObject _closestInteractable;
    [SerializeField] private Vector3 _closestPoint;

    void Update()
    {
        //Clean distance
        fingerTipToInteractableDistanceList.Clear();
        fingerTipToInteractableMeshPointList.Clear();

        //Get All interactables.
        interactableList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Interactable"));

        //Get closest interactable.
        foreach (Transform fingerTip in fingerTipTransformList)
        {
            float _closestDistance = 1000;
            Vector3 _closestPoint = Vector3.zero;

            foreach (GameObject interactable in interactableList)
            {
                Collider[] interactableColliders = interactable.GetComponents<Collider>();

                foreach (Collider convexCollider in interactableColliders)
                {
                    Vector3 closestPointInMesh = convexCollider.ClosestPoint(fingerTip.position);
                    float distance = Vector3.Distance(closestPointInMesh, fingerTip.position);

                    if (distance < _closestDistance)
                    {
                        _closestDistance = distance;
                        _closestPoint = closestPointInMesh;
                    }
                }
            }

            fingerTipToInteractableDistanceList.Add(_closestDistance);
            fingerTipToInteractableMeshPointList.Add(_closestPoint);
        }
        DebugLineRendererDistance();
    }

    public void DebugLineRendererDistance()
    {
        for (int i = 0; i < 5; i++)
        {
            distanceLineRendererDebug[i].SetPosition(0, fingerTipTransformList[i].position);
            distanceLineRendererDebug[i].SetPosition(1, fingerTipToInteractableMeshPointList[i]);
        }
    }

    public List<float> GetFingerTipToInteractableDistanceList()
    {
        return fingerTipToInteractableDistanceList;
    }
}
