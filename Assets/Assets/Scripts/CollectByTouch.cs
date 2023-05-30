using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectByTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CollectCoinByTouch();
    }
    private void CollectCoinByTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Collectible")
                {
                    Destroy(hit.transform.gameObject);
                    Debug.Log("Anjay");
                }
            }
        }
    }
}
