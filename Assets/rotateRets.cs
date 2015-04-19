using UnityEngine;
using System.Collections;

public class rotateRets : MonoBehaviour
{

  public float rotspeed1 = 5;
  public float rotspeed2 = -12;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(0, 0, rotspeed1);
    transform.GetChild(0).transform.Rotate(0, 0, rotspeed2);

  }

}