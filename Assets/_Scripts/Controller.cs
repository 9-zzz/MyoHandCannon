using UnityEngine;
using System;
using System.Collections;

using System.Collections.Generic;


public class Controller : MonoBehaviour {

/// <summary>
/// This demo and wiimote plugin is made by ByDesign Games & StinkBot LLC. 
/// It is modified by project Team Unity~ from the Entertainment Technology Center in Carnegie Mellon.
/// This demo showcase multiple wiimotes connected at the same time with multiple nunchucks.
/// </summary>

	public GameObject wiimoteModel;

	private Transform[] wiimotesConnected;
	public float sensitivity = 8.0f;
	public float pitchFudge = 30.0f;
	public float rollFudge = 50.0f;
	public bool showDebugGUI = false;
	public bool enableDebugTests = false;

	

    #region wiimote elements

    public Transform buttonA;
	public Transform buttonB;
	public Transform button1;
	public Transform button2;
	public Transform buttonPlus;
	public Transform buttonMinus;
	public Transform buttonHome;
	public Transform dpad;
	public Transform expansionPlug;
	public Transform[] lightIndicators;
	public Texture2D wiimote_cursor_tex;
	public Texture2D expansion_cursor_tex;

    #endregion 



    #region wiimote data 

    private string[] display;
	private int[] cursor_x, cursor_y;
	private Vector3[] vec;
	private Vector3[] oldVec;
	private int wiimoteCount;
	private int previousCount;

	private float[]  accx;
	private float[]  accy;
	private float[]  accz;
	private float[]  roll;
	private float[] pitch;
	private float[]  yaw;
	private float[]  ir_x;
	private float[]  ir_y;
	private float[]  nunchuck_x;
	private float[]  nunchuck_z;
	private  float[]  nunchuckStick_x;
	private float[] nunchuckStick_y;
	private bool[] hasNunchuck;



    #endregion  



    private wiiMote mywiiMote = new wiiMote(); // declare wiimote object class


    /// <summary>
    /// Called once 
    /// </summary>
	void Start () 
	{
		
			mywiiMote.start(); // starts the wiimote connection
			wiimoteCount = mywiiMote.count(); // gets the number of wiimotes connected
			previousCount = wiimoteCount; 
		
		
			showDebugGUI = true;
			enableDebugTests = true;
		
			if(wiimoteCount > 0)
			{
				declareArrays(wiimoteCount);
			}
		
			cursor_x = new int[16];
			cursor_y = new int[16];
		

		
	}
	
    /// <summary>
    /// declares the length of the wiimote data elements
    /// </summary>
    /// <param name="wiimoteCount"></param>
	void declareArrays(int wiimoteCount)
	{
		
		wiimotesConnected = new Transform[wiimoteCount];
		vec = new Vector3[wiimoteCount];
		oldVec = new Vector3[wiimoteCount];
		
		display = new string[wiimoteCount];
		hasNunchuck = new bool[wiimoteCount];
		accx = new float[wiimoteCount];
		accy = new float[wiimoteCount];
		accz = new float[wiimoteCount];
		roll = new float[wiimoteCount];
		pitch = new float[wiimoteCount];
		yaw =new float[wiimoteCount];
		ir_x =new float[wiimoteCount];
		ir_y =new float[wiimoteCount];
		nunchuck_x = new float[wiimoteCount];
		nunchuck_z = new float[wiimoteCount];
		nunchuckStick_x = new float[wiimoteCount];
		nunchuckStick_y = new float[wiimoteCount];
		
		for(int i = 0; i<wiimoteCount; i++)
		{
			GameObject g = (GameObject)Instantiate(wiimoteModel, new Vector3(0 + 10*i , 0, 0) , Quaternion.identity); //gets the wiimote object that instantiates it and put the transform into the list
		
			wiimotesConnected[i] = g.transform;
		}

	
	}
	
    /// <summary>
    ///  Update at a fixed length (can be changed in Edit>Project Settings>Time)
    /// </summary>
	void Update () {

		
		if(Input.GetKeyDown(KeyCode.A))
		{
			mywiiMote.stop();
		}
		
		if (Input.GetKeyDown(KeyCode.Escape))
        {
           mywiiMote.stop(); // stops wiimote connection
            Application.Quit();
        }
	

        // check to see if any wiimotes get disconnected
		
		wiimoteCount = mywiiMote.count();
		if(previousCount != wiimoteCount)  
		{
			declareArrays(wiimoteCount);
			previousCount = wiimoteCount;
		}

	       //execute for every wiimote connected
			if (wiimoteCount>0) 
	        {
				
				for (int i=0; i<wiimoteCount; i++) 
				{
						// set member vars to plugin data 
						accx[i] = mywiiMote.getAccX(i);
						accy[i] = mywiiMote.getAccY(i);
						accz[i] = mywiiMote.getAccZ(i);
						roll[i] = mywiiMote.getRoll(i) + rollFudge;
						pitch[i] = mywiiMote.getPitch(i) + pitchFudge;
						yaw[i] = mywiiMote.getYaw(i);
						ir_x[i] = mywiiMote.getIrX(i);
						ir_y[i] = mywiiMote.getIrY(i);
						nunchuck_x[i] = mywiiMote.getNunchuckAccX(i);
						nunchuck_z[i] = mywiiMote.getNunchuckAccZ(i);
						nunchuckStick_x[i] = mywiiMote.getNunchuckStickX(i);
						nunchuckStick_y[i] = mywiiMote.getNunchuckStickY(i);
						hasNunchuck[i] = mywiiMote.hasNunChuck(i);
						
		
						if (!float.IsNaN(roll[i]) && !float.IsNaN(pitch[i])) {
							vec[i] = new Vector3(pitch[i], 0 , -1 * roll[i]);
							//vec = new Vector3(pitch, yaw , -1 * roll);
							vec[i] = Vector3.Lerp(oldVec[i], vec[i], Time.deltaTime * sensitivity);
							oldVec[i] = vec[i];
							
							//print("Wiimote #" + i);
							wiimotesConnected[i].eulerAngles = vec[i];
							
						}
				
				
					
						//ir cursor values
						if (  (ir_x[i] != -100) && (ir_y[i] != -100) )
						{
					    	float temp_x = ((ir_x[i] + 1.0f)/ 2.0f) * Screen.width;
					    	float temp_y = Screen.height - (((ir_y[i] + 1.0f)/ 2.0f) * Screen.height);
		
					    	cursor_x[wiimoteCount] = Mathf.RoundToInt(temp_x);
					    	cursor_y[wiimoteCount] = Mathf.RoundToInt(temp_y);
						}
		
					
						DoDebugStr(i);
						DoDebugTests(i);
				
					
				}

		}


		
	}
	
	void OnApplicationQuit()
	{
		mywiiMote.stop();
		Application.Quit();
	}
	

	/// <summary>
	/// Display GUI
	/// </summary>
	void OnGUI() {
		
		GUI.Label(new Rect(350, 10, 100, 100),  "wiimote count : " + wiimoteCount);

		if(wiimoteCount > 0)
		{


			for(int x=0; x<wiimoteCount; x++)
			{
				GUI.Label(new Rect( 0, 10+210*x, 300, 200),   display[x]);
			}
		
			if (showDebugGUI)
			{
				
				/* create style for cursor*/
				GUIStyle label_wiimote_cursor;
				if (wiimote_cursor_tex) 
				{
					label_wiimote_cursor = new GUIStyle();
					label_wiimote_cursor.normal.background = wiimote_cursor_tex;
				}
				else
					label_wiimote_cursor = "box";
				
				label_wiimote_cursor.clipping = TextClipping.Overflow;
				label_wiimote_cursor.normal.textColor = Color.red;
	
				
				// for each remote, show debug cursors
				for (int i=0; i<wiimoteCount; i++)
				{
					// uses ir 
					float ir_posx = mywiiMote.getIrX(i);
					float ir_posy = mywiiMote.getIrY(i);
			    	float temp_x = (Screen.width * 0.5f) + ir_posx * Screen.width * 0.5f;
			    	float temp_y = Screen.height - (ir_posy * Screen.height * 0.5f);
					GUI.Box ( new Rect (temp_x, temp_y, 64.0f, 64.0f), "IR Pointer #" + i, label_wiimote_cursor);
	
					// expansion joystick cursor 
					if (hasNunchuck[i]) 
					{
						if (expansion_cursor_tex)
							label_wiimote_cursor.normal.background = expansion_cursor_tex;
						else 
						{
							label_wiimote_cursor = "box";
							label_wiimote_cursor.normal.background = null;
						}
	
						label_wiimote_cursor.normal.textColor = Color.yellow;
	
					    Vector3 extJoyViewport = new Vector3(mywiiMote.getNunchuckStickX(i) * (Screen.width / 256), Screen.height - (mywiiMote.getNunchuckStickY(i) * (Screen.height / 256)), 0.0f);
						GUI.Box ( new Rect (extJoyViewport.x, extJoyViewport.y, 50.0f, 50.0f), (expansion_cursor_tex) ? "" : "Expansion #" + i , label_wiimote_cursor);
					}
				}
			}
		}
		else
		{
			GUI.Label(new Rect(10, 10, 500, 50), "No Wii Remote connected...");
		}
	}

	
	
	/// <summary>
	/// Display on GUI all the variables of the wiimote 
    /// As well as which buttons are being pressed right now
	/// </summary>
	/// <param name="i"></param>
	void DoDebugStr (int i) 
    {
        if (wiimoteCount > 0) 
		{
			display[i] = "";

			display[i] += "Wiimote #" + i + ":"
				+ "\n\tAccelerometer: " + accx[i]+ ", " + accy[i] + " , " + accz[i]
				+ "\n\t\tRoll: " + roll[i] 
				+ "\n\t\tPitch: " + pitch[i] 
				+ "\n\t\tYaw: " + yaw[i] 
				+ "\n\tIR Pitch & Yaw: " + ir_x[i] + ", " + ir_y[i]
				+ "\n\tOrientation Vector: " + vec
				+ "\n\tSensitivity: " + sensitivity.ToString("F2");
			
            if (hasNunchuck[i]) 
			{
				display[i] += "\n\tnunChuck Accelerometer: " + nunchuck_x[i] + " , " + nunchuck_z[i] 
					+ "\n\t nunChuck Joystick: " + nunchuckStick_x[i] + ", " + nunchuckStick_y[i];
			}
			else 
			{
				display[i] += "\n\t nunchuuck Device: _not detected_";
			}

            // buttons
			display[i] += "\n\tButtons Active: ";
			
			if (mywiiMote.getButtonA(i)) 
				display[i] += " A ";
			if (mywiiMote.getButtonB(i))
				display[i] += " B ";
			if (mywiiMote.getButtonHome(i)) 
				display[i] += " Home ";
			if (mywiiMote.getButtonPlus(i)) 
				display[i] += " + ";
			if (mywiiMote.getButtonMinus(i)) 
				display[i] += " - ";
			if (mywiiMote.getButton1(i)) 
				display[i] += " 1 ";
			if (mywiiMote.getButton2(i)) 
				display[i] += " 2 ";
			if (mywiiMote.getDpadUp(i)) 
				display[i] += " Up ";
			
		    // dpad
			if (mywiiMote.getDpadDown(i)) 
						display[i] += " Down ";
			if (mywiiMote.getDpadLeft(i)) 
				display[i] += " Left ";
			if (mywiiMote.getDpadRight(i)) 
				display[i] += " Right ";
			
			// nunchucks
			if (mywiiMote.getButtonNunchuckC(i)) 
				display[i] += " C ";
			if (mywiiMote.getButtonNunchuckZ(i)) 
				display[i] += " Z ";
		}

	}

    /// <summary>
    /// displays the light index of each wiimote 
    /// as well as which buttons are being pressed
    /// </summary>
    /// <param name="i"></param>
	void DoDebugTests (int i) 
	{
		if (wiimoteCount > 0) 
		{
			DoLightInit(i);

			if (hasNunchuck[i])
			{
				Color activeColor = new Color (1.0f,0.0f,0.0f,0.5f);
				
				if (mywiiMote.getButtonNunchuckC(i)) 
					activeColor.a = 1.0f;
				else if (mywiiMote.getButtonNunchuckZ(i)) 
					activeColor.a = 1.0f;
				else 
					activeColor.a = 0.5f;

			}
			
	
			//change the color to red to highlight button being pressed
			if (mywiiMote.getButtonA(i)) 
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_button_a"), Color.red);
			else 
				SetColorInstance(wiimotesConnected[i].FindChild("WiiMote_button_a"), Color.white);
			
			if (mywiiMote.getButtonB(i)) 
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_button_b"), Color.red);
			else 
				SetColorInstance(wiimotesConnected[i].FindChild("WiiMote_button_b"), Color.white);
			
			if (mywiiMote.getButtonHome(i))
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_button_home"), Color.red);
			else 
				SetColorInstance(wiimotesConnected[i].FindChild("WiiMote_button_home"), Color.white);
			
			if (mywiiMote.getButtonPlus(i)) 
			{
				sensitivity += 0.05f;
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_button_plus"), Color.red);
			}
			else 
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_button_plus"), Color.white);
			
			if (mywiiMote.getButtonMinus(i)) 
			{ 
				sensitivity -= 0.05f;
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_button_minus"), Color.red);
			}
			else 
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_button_minus"), Color.white);
			
			if (mywiiMote.getButton1(i)) 
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_button_1"), Color.red);
			else
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_button_1"), Color.white);
			
			if (mywiiMote.getButton2(i)) 
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_button_2"), Color.red);
			else 
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_button_2"), Color.white);
			
			//Dpad
			if (mywiiMote.getDpadUp(i))
			{
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_dpad"), Color.red);
				if (wiimotesConnected[i])
					wiimotesConnected[i].localPosition += new Vector3(0,0,0.10f);
			}
			else if (mywiiMote.getDpadDown(i)) 
			{
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_dpad"), Color.red);
				if (wiimotesConnected[i])
					wiimotesConnected[i].localPosition -= new Vector3(0,0,0.10f);
			}
			else if (mywiiMote.getDpadLeft(i)) 
			{
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_dpad"), Color.red);
				if (wiimotesConnected[i])
					wiimotesConnected[i].localPosition -= new Vector3(0.1f,0,0);

			}
			else if (mywiiMote.getDpadRight(i)) 
			{
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_dpad"), Color.red);
				if (wiimotesConnected[i])
					wiimotesConnected[i].localPosition += new Vector3(0.1f,0,0);

			}
			else 
				SetColorInstance (wiimotesConnected[i].FindChild("WiiMote_dpad"), Color.white);
		
			sensitivity = Mathf.Clamp (sensitivity, 1.0f, 16.0f);

		}
	
	}

    /// <summary>
    /// show on the wiimote model which light index it is. 
    /// </summary>
    /// <param name="index"></param>

 	void DoLightInit (int index) 
	{
	
		for (int i=0; i<=3; i++)  //there are 4 lights on a wiimote
		{
			wiimotesConnected[index].FindChild("WiiMote_light_" + i).gameObject.active = false;
		}
	
		
		wiimotesConnected[index].FindChild("WiiMote_light_" + index).gameObject.active = true;
		
	}

	
	/// <summary>
	/// utility function
    /// Changing the transform of the color to a new color
	/// </summary>
	/// <param name="someTR"></param>
	/// <param name="newColor"></param>
	void SetColorInstance (Transform someTR, Color newColor) 
	{
		someTR.GetComponent<Renderer>().material.color = newColor;
	}
	
}