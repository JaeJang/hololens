using Academy.HoloToolkit.Unity;
using UnityEngine;

/// <summary>
/// GestureAction performs custom actions based on 
/// which gesture is being performed.
/// </summary>
public class GestureAction : MonoBehaviour
{
    [Tooltip("Rotation max speed controls amount of rotation.")]
    public float RotationSensitivity = 10.0f;

    private Vector3 manipulationPreviousPosition;

    private float rotationFactor;

    private float resizeFactor;

    private float pre_y;

    void Start()
    {
        pre_y = gameObject.transform.position.y;
    }

    void Update()
    {
        PerformRotation();
    }

    private void PerformRotation()
    {
        if (GestureManager.Instance.IsNavigating &&
           HandsManager.Instance.FocusedGameObject == gameObject )
        {
            
            //Debug.Log("entered");
            /* TODO: DEVELOPER CODING EXERCISE 2.c */

            // 2.c: Calculate rotationFactor based on GestureManager's NavigationPosition.X and multiply by RotationSensitivity.
            // This will help control the amount of rotation.
            //rotationFactor = GestureManager.Instance.NavigationPosition.x * RotationSensitivity;

            // 2.c: transform.Rotate along the Y axis using rotationFactor.
            //transform.Rotate(new Vector3(0, -1 * rotationFactor, 0));
            if(HandsManager.Instance.FocusedGameObject.layer == 8 ||
           HandsManager.Instance.FocusedGameObject.layer == 9) {
                Vector3 scale = gameObject.transform.localScale;
                resizeFactor = GestureManager.Instance.NavigationPosition.x; //* RotationSensitivity;

                gameObject.transform.localScale = new Vector3(scale.x + 0.005f * resizeFactor,
                                                              scale.y + 0.005f * resizeFactor,
                                                              scale.z + 0.005f * resizeFactor);
            }
            


        }
    }

    void PerformManipulationStart(Vector3 position)
    {
        manipulationPreviousPosition = position;
    }

    void PerformManipulationUpdate(Vector3 position)
    {
        if (GestureManager.Instance.IsManipulating)
        {
            /* TODO: DEVELOPER CODING EXERCISE 4.a */

            Vector3 moveVector = Vector3.zero;

            // 4.a: Calculate the moveVector as position - manipulationPreviousPosition.
            moveVector = position - manipulationPreviousPosition;

            // 4.a: Update the manipulationPreviousPosition with the current position.
            manipulationPreviousPosition = position;

            // 4.a: Increment this transform's position by the moveVector.
            transform.position += moveVector;
        }
    }
}