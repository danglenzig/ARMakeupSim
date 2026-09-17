# Makeup Thing Catcher
#### Brad Neal -- GP25
#### Unity AR Mobile

![](SS1.png) ![](SS2.png)

### Summary

A game where you change the color of your lipstick and eyeshadow by catching things with your face.

### Scripts Authored For This Assignment
- [`ShooterFaceManager`](Assets/Scripts/Shooter/ShooterFaceManager.cs)


### Unity AR Mobile Classes Relevant To Face Recognition & Filtering
- `ARFaceManager`
  - Component of `XROrigin` object
  - Provides an `ARFace` to my prefab via the `FacePrefab` serialized field
- `ARFace`
  - Represents a human face detected and tracked by the device’s front-facing camera.
  - Contains all the runtime topology data for the my prefab's facial mesh
