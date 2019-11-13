# GazeFlowAPI
WebCam based Eye-Tracking API


With GazeFlowAPI you can access real-time gaze and head position data from GazePointer WebCam Eye-Tracker (https://sourceforge.net/projects/gazepointer/).



How to use it:

1. Install and start GazePointer (download: https://sourceforge.net/projects/gazepointer/)

2. To get your AppKey register at http://gazeflow.epizy.com/GazeFlowAPI/register/
You can use default AppKey for testing.

3. Connect to GazePointer and start reciving gaze data. 
  a) Use TCP socket ( check GazeFlowAPI.cs source code for details  ).
  b) Use WebSocket ( check /HTML5 JavaScript/GazeFlowAPI.html source code for details ).
  
If you see message  "Unauthorized app want to use your gaze data" Make sure that GazePointer has access to internet, authorization takes place on a GazeFlow server. Check your firewall settings 


You can also chek out GazeCloudAPI https://api.gazerecorder.com/ for Cr0ss-Platform online Eye-Tracking


