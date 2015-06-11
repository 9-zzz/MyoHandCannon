using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.IO;

public class mbScript : MonoBehaviour
{

  public float chargeForce = 0.0f;
public float spinVal = 0;

public scoreKeeper playerRef;

  // Use this for initialization
  void Start()
  {
    playerRef = GameObject.Find("Player").GetComponent<scoreKeeper>();

  }

  void sendText()
  {
    string url = "http://162.243.88.82:7000/";

    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

    Stream resStream = response.GetResponseStream();
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.parent != null)
    {

      if (transform.parent.GetComponent<MyoArmShooter>().charging)
      {
        if (transform.localScale.x <= 3)
        {
          transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
          chargeForce += 1f;
          spinVal += 0.1f;
        }
      }
      else 
      {
        transform.GetComponent<Rigidbody>().AddRelativeForce(0, 0, chargeForce, ForceMode.Impulse);
        transform.parent = null;
        chargeForce = 0.0f;
        spinVal = 0;
      }
    }
  }

  void OnCollisionEnter(Collision other)
  {
    Destroy(gameObject);

    if (other.gameObject.tag == "Bronner")
      playerRef.bronnerhits++;

    if (other.gameObject.tag == "Sagnew")
    {
      sendText();
      playerRef.samhits++;
    }

    if (other.gameObject.tag == "Aedan")
      playerRef.aedanhits++;

    if (other.gameObject.tag == "Tobias")
      playerRef.tobiasshits++;


  }
 
}