using UnityEngine;

public class CutterConnection : MonoBehaviour
{
    public GameObject cutter;
    public Transform attachPoint;
    public GameObject fieldEntryTrigger;   
    private bool hasAttached = false;
    public GameObject directionalArrow;

    private void OnTriggerEnter(Collider other)
    {
        if (hasAttached) return;

        if (other.GetComponent<RCC_CarControllerV3>())
        {
            Debug.Log("Cutter is attached");

            // Attach cutter to tractor
            cutter.transform.SetParent(attachPoint);
            cutter.transform.localPosition = Vector3.zero;
            cutter.transform.localRotation = Quaternion.identity;
            if (directionalArrow != null)
                directionalArrow.SetActive(false); //Arrows OFF when cutter attached

            // Show field entry trigger
            if (fieldEntryTrigger != null)
            {
                fieldEntryTrigger.SetActive(true); // Activates green particle trigger zone

                //Call the OnCutterAttached method from FieldTriggerHandler
                FieldTriggerHandler fieldHandler = fieldEntryTrigger.GetComponent<FieldTriggerHandler>();
                if (fieldHandler != null)
                    fieldHandler.OnCutterAttached();
                else
                    Debug.LogWarning("FieldTriggerHandler not found on fieldEntryTrigger!");
            }

            gameObject.SetActive(false); // Disable this cutter trigger after attaching
            hasAttached = true;
        }
    }
}


