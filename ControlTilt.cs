using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;
namespace Application
{
	float UPDATE_TIME = .5f;
	float lastUpdateTime = 0;
	int MAX_TURN = 1;
	float altCommand = 0;
	internal Boolean socketReady = false;
	TcpClient mySocket;
	NetworkStream theStream;
	StreamWriter theWriter;
	StreamReader theReader;
	String Host = "localhost";
	Int32 Port = 5000;
	public class ControlTilt
	{
		void Start () {
			try {
				mySocket = new TcpClient (Host, Port);
				theStream = mySocket.GetStream ();
				theWriter = new StreamWriter (theStream);
				theReader = new StreamReader(theStream); 
				socketReady = true; 
			} catch (Exception e) { 
				Debug.Log("Socket error: " + e); 
			} 
			ovrTracker = OVRManager.display;
			for (int i=0; i<3; i++) {
				commands [i] = 0;
			}
		}
		public void writeSocket(string theLine) { 
			if (!socketReady) 
				return; 
			String foo = theLine; 
			theWriter.Write(foo); theWriter.Flush(); } 
		public String readSocket() { 
			if (!socketReady) return ""; 
			if (theStream.DataAvailable) 
				return theReader.ReadLine(); return ""; } 
		public void closeSocket() { if (!socketReady) 
			return; theWriter.Close(); theReader.Close(); mySocket.Close(); socketReady = false;

		}
		float xRot;
		public ControlTilt ()
		{
			float throttle = 0;
		}
		public int updateThrottle()
		{
			xRot = Mathf.Deg2Rad * android.sensor.rotation_vector.x;
			if (Math.Abs (xRot) > .10) {
				throttle = -xRot * 2 / Math.PI;//negative because tilting the phone up results in a negative angle. limit to angle is 90 degrees.
			} else {
				throttle = 0;
			}
			return throttle;
		}

	}
}

