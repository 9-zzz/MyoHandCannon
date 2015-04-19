using System;
using System.Collections;
using System.Runtime.InteropServices;


public class wiiMote
	{

		[DllImport ("UniWii")]
		private static extern void wiimote_start();
		
		/// <summary>
		/// starts the connection with the wiimote 
		/// </summary>
		public void start()
		{
			wiimote_start();
		}

		[DllImport ("UniWii")]
		private static extern void wiimote_stop();
		
		/// <summary>
		/// Stops the connection with the wiimote
		/// </summary>
		public void stop()
		{
			wiimote_stop();
		}
		
		[DllImport ("UniWii")]
		private static extern int wiimote_count();
	

	    /// <summary>
	    /// Returns the number of wiimotes connected
	    /// </summary>
        /// <returns>int</returns>
		public int count()
		{
			return wiimote_count();
		}
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_available( int which );
		
	    /// <summary>
	    /// Checks to see if this wiimote is available
	    /// </summary>
	    /// <param name="which"> index of wiimote </param>
	    /// <returns></returns>
		public bool availble(int which)
		{
			return wiimote_available(which);
		}
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_isIRenabled( int which );
		
	
	    /// <summary>
	    /// Checks to see if this wiimote has enabled IR
	    /// </summary>
	    /// <param name="which">index of wiimote</param>
	    /// <returns></returns>
		public bool isIRenabled(int which)
		{
			return wiimote_isIRenabled(which);
		}
		

		[DllImport ("UniWii")] 
		private static extern bool wiimote_enableIR( int which );
		
        /// <summary>
        /// Enables the IR for the wiimote
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool enableIR(int which)
		{
			return wiimote_enableIR(which);
		}
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_isExpansionPortEnabled( int which );
		
	
        /// <summary>
        /// Checks to see if the wiimote has a NunChuck attached
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool hasNunChuck(int which)
		{
			return wiimote_isExpansionPortEnabled(which);
		}
		
		
		
		[DllImport ("UniWii")]
		private static extern void wiimote_rumble( int which, float duration);
		
	    
        /// <summary>
        /// Makes the wiimote rumble
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <param name="duration">length of rumble</param>
		public void rumble(int which, float duration)
		{
			wiimote_rumble(which, duration);
		}
		
		[DllImport ("UniWii")]
		private static extern double wiimote_getBatteryLevel( int which );
		
	
        /// <summary>
        /// Get the battery level of the wiimote
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns>double</returns>
		public double getBatteryLevel(int which)
		{
			return wiimote_getBatteryLevel(which);
		}
		
		[DllImport ("UniWii")]
		private static extern byte wiimote_getAccX(int which);
		
        /// <summary>
        /// Gets the Acceleration on the X axis
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public byte getAccX(int which)
		{	
			return wiimote_getAccX(which);
		}
		
		[DllImport ("UniWii")]
		private static extern byte wiimote_getAccY(int which);

        /// <summary>
        /// Gets the Acceleration on the Y axis
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public byte getAccY( int which)
		{
			return wiimote_getAccY(which);
		}
		
		[DllImport ("UniWii")]
		private static extern byte wiimote_getAccZ(int which);

        /// <summary>
        /// Gets the Acceleration on the Z axis
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public byte getAccZ(int which)
		{
			return wiimote_getAccZ(which);
		}
		
		[DllImport ("UniWii")]
		private static extern float wiimote_getIrX(int which);

        /// <summary>
        /// Gets the IR on the Z axis
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public float getIrX(int which)
		{
			return wiimote_getIrX(which);
		}
		
		[DllImport ("UniWii")]
		private static extern float wiimote_getIrY(int which);
		
		public float getIrY(int which)
		{
			return wiimote_getIrY(which);
		}
		
		[DllImport ("UniWii")]
		private static extern float wiimote_getRoll(int which);


        /// <summary>
        /// Gets the roll
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public float getRoll(int which)
		{
			return wiimote_getRoll(which);
		}
		[DllImport ("UniWii")]
		private static extern float wiimote_getPitch(int which);


        /// <summary>
        /// Gets the pitch
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public float getPitch(int which)
		{
			return wiimote_getPitch(which);
		}
		
		
		[DllImport ("UniWii")]
		private static extern float wiimote_getYaw(int which);


        /// <summary>
        /// Gets the yaw
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public float getYaw(int which)
		{
			return wiimote_getYaw(which);
		}
		
		[DllImport ("UniWii")]
		private static extern byte wiimote_getNunchuckStickX(int which);

        /// <summary>
        /// Gets the X axes on the analog stick on the Nunchuck
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public byte getNunchuckStickX(int which)
		{
			return wiimote_getNunchuckStickX(which);
		}
		
		[DllImport ("UniWii")]
		private static extern byte wiimote_getNunchuckStickY(int which);

        /// <summary>
        /// Gets the Y axes on the analog stick on the Nunchuck
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public byte getNunchuckStickY(int which)
		{
			return wiimote_getNunchuckStickY(which);
		}
		
		[DllImport ("UniWii")]
		private static extern byte wiimote_getNunchuckAccX(int which);

        /// <summary>
        /// Gets the Acceleration on the X axis on the Nunchuck
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
        /// </summary>
        /// <param name="which"></param>
        /// <returns></returns>
		public byte getNunchuckAccX(int which)
		{
			return wiimote_getNunchuckAccX(which);
		}
		
		
		[DllImport ("UniWii")]
		private static extern byte wiimote_getNunchuckAccZ(int which);
		
        /// <summary>
        /// Gets the Acceleration on the Z axis on the Nunchuck
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
        /// </summary>
        /// <param name="which"></param>
        /// <returns></returns>
		public byte getNunchuckAccZ(int which)
		{
			return wiimote_getNunchuckAccZ(which);
		}
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_getButtonA(int which);

        /// <summary>
        /// Gets the A button on the wiimote
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool getButtonA(int which)
		{
			return wiimote_getButtonA(which);		
		}
		

		
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_getButtonB(int which);

        /// <summary>
        /// Gets the B button on the wiimote
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool getButtonB(int which)
		{
			return wiimote_getButtonB(which);
		}
		
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_getButtonUp(int which);

        /// <summary>
        /// Gets the Up button on the Directional pad 
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool getDpadUp(int which)
		{
			return wiimote_getButtonUp(which);
		}
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_getButtonLeft(int which);

        /// <summary>
        /// Gets the Left button on the Directional pad 
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool getDpadLeft(int which)
		{
			return wiimote_getButtonLeft(which);
		}
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_getButtonRight(int which);


        /// <summary>
        /// Gets the Right button on the Directional pad 
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool getDpadRight(int which)
		{
			return wiimote_getButtonRight(which);
		}
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_getButtonDown(int which);


        /// <summary>
        /// Gets the Down button on the Directional pad 
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool getDpadDown(int which)
		{
			return wiimote_getButtonDown(which);
		}
		


		[DllImport ("UniWii")]
		private static extern bool wiimote_getButton1(int which);

        /// <summary>
        /// Gets the 1 button on the wiimote
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool getButton1(int which)
		{
			return wiimote_getButton1(which);
		}
		
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_getButton2(int which);


        /// <summary>
        /// Gets the 2 button on the wiimote
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool getButton2(int which)
		{
			return wiimote_getButton2(which);
		}
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_getButtonNunchuckC(int which);

        /// <summary>
        /// Gets the C button on the NunChuck
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool getButtonNunchuckC(int which)
		{
			return wiimote_getButtonNunchuckC(which);
		}
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_getButtonNunchuckZ(int which);


        /// <summary>
        /// Gets the Z button on the NunChuck
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool getButtonNunchuckZ(int which)
		{
			return wiimote_getButtonNunchuckZ(which);
		}
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_getButtonPlus(int which);



        /// <summary>
        /// Gets the Plus button on the Wiimote
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool getButtonPlus(int which)
		{
			return wiimote_getButtonPlus(which);
		}
		
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_getButtonMinus(int which);


        /// <summary>
        /// Gets the Minus button on the Wiimote
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool getButtonMinus(int which)
		{
			return wiimote_getButtonMinus(which);
		}
		
		
		
		// Aquired through Dependency walker.
		
		[DllImport ("UniWii")]
		private static extern bool wiimote_getButtonHome(int which);
		

        /// <summary>
        /// Gets the Home button on the Wiimote
        /// </summary>
        /// <param name="which">index of wiimote</param>
        /// <returns></returns>
		public bool getButtonHome(int which)
		{
			return wiimote_getButtonHome(which);
		}
		
		
		// Not sure about return types.
		[DllImport ("UniWii")]
		private static extern float wiimote_getNunchuckPitch(int which);
		
		public float getNunchuckPitch(int which)
		{
			return wiimote_getNunchuckPitch(which);
		}
		
		
		[DllImport ("UniWii")]
		private static extern float wiimote_getNunchuckRoll(int which);
		
		public float getNunchuckRoll(int which)
		{
			return wiimote_getNunchuckRoll(which);
		}
		
		
		[DllImport ("UniWii")] 
		private static extern bool wiimote_setLed( int which);
		
		public bool setLed(int which)
		{
			return wiimote_setLed(which);
		}

	}

