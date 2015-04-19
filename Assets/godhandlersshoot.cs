using UnityEngine;
using System.Collections;

public class godhandlersshoot : MonoBehaviour
{
  public GameObject myoRef;
  public GameObject myoBullethb;
  // Use this for initialization
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {

    if ((myoRef.GetComponent<ThalmicMyo>().pose.ToString() == "Fist"))
    {
      var m = Instantiate(myoBullethb, transform.position + transform.forward * 3.5f, transform.rotation) as GameObject;
    Destroy(m.gameObject, 7);
    transform.RotateAround(transform.parent.transform.position, transform.parent.transform.forward, 7.0f);

      m.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 50, ForceMode.Impulse);
    }
  }

}