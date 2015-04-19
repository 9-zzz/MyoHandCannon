using UnityEngine;
using System.Collections;

public class ExplodeSprites : MonoBehaviour
{

  public GameObject sams;
  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "mb")
    {
      Instantiate(sams, transform.position, transform.rotation);
      Instantiate(sams, transform.position, transform.rotation);
      Instantiate(sams, transform.position, transform.rotation);
      Instantiate(sams, transform.position, transform.rotation);
      Instantiate(sams, transform.position, transform.rotation);
      Instantiate(sams, transform.position, transform.rotation);
    }
  }

}