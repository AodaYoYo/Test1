using UnityEngine;
using System.Collections;
public class RotateOnEnter : MonoBehaviour
{
    public GameObject object1; 
    public GameObject object2; 
    public float rotationSpeed = 2.0f; 

    private Quaternion targetRotation1; 
    private Quaternion targetRotation2; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            
            targetRotation1 = Quaternion.Euler(0, 135, 0); 
            targetRotation2 = Quaternion.Euler(0, -135, 0); 

           
            StartCoroutine(RotateObjects());
        }
    }

    private IEnumerator RotateObjects()
    {
       
        Quaternion startRotation1 = object1.transform.rotation;
        Quaternion startRotation2 = object2.transform.rotation;

        float elapsedTime = 0f;
        float duration = 1.0f; 

        while (elapsedTime < duration)
        {
            
            object1.transform.rotation = Quaternion.Slerp(startRotation1, targetRotation1, elapsedTime / duration);
            object2.transform.rotation = Quaternion.Slerp(startRotation2, targetRotation2, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null; 
        }

        
        object1.transform.rotation = targetRotation1;
        object2.transform.rotation = targetRotation2;
    }
}
