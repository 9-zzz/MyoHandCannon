using UnityEngine;
using System.Collections;

public class MyoArmShooter : MonoBehaviour
{

  public GameObject myoRef;

  public GameObject myoBullet;
  public GameObject mb;

  public bool charging = false;


  public void shoot()
  {

    //mb.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 70, ForceMode.Impulse);
    Destroy(mb, 5);
  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(0, 0, 7.0f);
    //Debug.Log(myoRef.GetComponent<ThalmicMyo>().pose);
    if ((myoRef.GetComponent<ThalmicMyo>().pose.ToString() == "Fist") && !charging)
    {
      mb = Instantiate(myoBullet, transform.position + transform.forward * 3.5f, transform.rotation) as GameObject;
      mb.transform.parent = transform;
      charging = true;
    }

    if ((myoRef.GetComponent<ThalmicMyo>().pose.ToString() == "WaveOut"))
    {
      charging = false;
    }
  }

}