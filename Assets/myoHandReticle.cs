using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class myoHandReticle : MonoBehaviour
{

  public GameObject ret;

  public float rayDistance = 100;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

    RaycastHit hit;
    if(Physics.Raycast(transform.position, transform.forward,  out hit, rayDistance))
    {
    Debug.DrawRay(transform.position,transform.forward*rayDistance);
    ret.transform.position = hit.point;
    ret.transform.LookAt(GameObject.Find("Player").transform.position);
    }

  }

}