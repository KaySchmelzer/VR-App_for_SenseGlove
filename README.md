# VR-App_for_SenseGlove
VR-Application made with Unity for both SenseGlove Nova and regular controllers of VR-Headsets.

While working on my bachelor's thesis I developed a VR-Application via Unity which can be controlled by either SenseGlove Nova or regular controllers of VR-Headsets, depending on small changes you'd need to do before running the application. The goal was to allow the users to get a first impression about what the SenseGlove Nova are capable of while being able to closely compare them to regular VR-Controllers.

In this repository you'll find the Unity project i was working on as well as some short explanations on how to run it. I personally used an Oculus Quest 2 and therefor builded APK files. You might have to do some extra work if you use a different type of VR-Headset, because i am not sure about the compatibility with other types of VR-Headsets.

# For SenseGlove Nova

To enable the controls via SenseGlove Nova you have to enable the "XRRig"-component and disable the "Complete XR Origin Set Up"- and "XR Device Simulator"-component. 

If you want to build the application file for your VR-device, you also need to include the "CalibrationVoid_XR" scene in the build settings. This is required because the scene is needed to calibrate the SenseGlove Nova if you pair them with your VR-device. 

# For regular VR-Controllers

To enable the controls via regular VR-Controllers you have to enable the "Complete XR Origin Set Up"-component and disable the "XRRig"- and "XR Device Simulator"-component. You can also enable the "XR Device Simulator"-component if you want to run the application on your PC without any VR-device connected.

If you want to build the application file for your VR-device, you need to exclude the "CalibrationVoid_XR" scene in the build settings, since it's only needed for the SenseGlove Nova.

# Overview

In this Application there are three different tasks implemented, which the users can solve with both types of controls.

The first task is a bow which can be used to shoot stationary targets.

The second task is a box which has holes in different kind of shapes. The user needs to grab different figures and precisely get them through the right holes.

The third task is a bowling ball with some bowling pins.
