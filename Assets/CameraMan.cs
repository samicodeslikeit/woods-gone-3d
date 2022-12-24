using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMan : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float dampingSpeed;
    [SerializeField] private Vector3 startingOffset;
    [SerializeField] private Vector3 startingRotation;
    
    private Camera cam;

    public static CameraMan Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        cam = transform.GetChild(0).GetComponent<Camera>();
        cam.transform.localPosition = startingOffset;
        transform.localEulerAngles = startingRotation;
    }

    private void Update()
    {
        if(target)
            transform.position = Vector3.MoveTowards(transform.position, target.position, dampingSpeed * Time.deltaTime);
    }
}
