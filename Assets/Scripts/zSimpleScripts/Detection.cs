using UnityEngine;

public class Detection : MonoBehaviour {

    private RaycastHit hit;
    [SerializeField]
    private LayerMask detectionLayer;
    private float checkRate = 0.5f;
    private float nextCheck;
    private float range = 5;
    private Transform _transform;

	// Use this for initialization
	void Start () {
        SetInitialReferences();

    }

    // Update is called once per frame
    void Update()
    {
        DetectItems();
    }

    void SetInitialReferences()
    {
        _transform = transform;
        // setting for layermask varable COOLSHIT
        // detectionLayer = 1 << 11 |1<<12;
    }

    void DetectItems()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;

            if(Physics.Raycast(_transform.position, _transform.forward, out hit, range, detectionLayer))
            {
                Debug.Log(hit.transform.name + " is an Item");
            }
        }
    }
}
