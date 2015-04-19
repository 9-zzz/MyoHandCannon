using UnityEngine;
using System.Collections;

public class GodHand : MonoBehaviour {

  public GameObject myoRef;
  public GameObject myoBullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
    if ((myoRef.GetComponent<ThalmicMyo>().pose.ToString() == "Fist") )
    {
      var m = Instantiate(myoBullet, transform.position + transform.forward * 3.5f, transform.rotation) as GameObject;
      Destroy(m.gameObject, 7);

        m.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 50,ForceMode.Impulse);
    }
	}
}
