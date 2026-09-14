### Main Scene Structure

```
- '*' indicates C# classes that I authored for this assignment
- '**' indicates C# classes included with Unity's AR Mobile template

MakeupSim(scene root)
----XR Origin (AR Rig)/
--------Components/
------------XROrigin **
------------InputActionManager **
------------ActionAssets **
------------ARFaceManager **
--------Child Gameobjects
------------Camera Offset/
----------------Components/
--------------------(None, just a container of child objects)
----------------Child Gameobjects/
--------------------Main Camera/
------------------------Components/
----------------------------ARCameraManager **
----------------------------ARCameraBackground **
----------------------------TrackedPoseDriver **
--------------------Screen Space Ray Interactor/
------------------------ ...
----AR Session/
--------Components/
------------ARSession **
------------ARInputManager **
----EventSystem/
--------Components/
------------XR UI Input Module **
----UI/
--------== SEE BELOW ==
----FaceConficService/
--------Components/
------------FaceConfigService *
```

### UI Structure
```
- '*' indicates C# classes that I authored for this assignment
- '**' indicates C# classes included with Unity's AR Mobile template
```

### FacePrefab structure

```
- '*' indicates C# classes that I authored for this assignment
- '**' indicates C# classes included with Unity's AR Mobile template

FacePrefab/
----Components/
--------ARFace **
--------MeshCollider
--------MakeupSimFaceManager *
----Child GameObjects/
--------LipsLayer/
------------Components/
----------------MakeupSimFaceLayer *
----------------MeshFilter
----------------MeshRenderer
--------EyeMakeupLayer/
------------Components/
----------------MakeupSimFaceLayer *
----------------MeshFilter
----------------MeshRenderer
--------(Other layers as needed)/
------------Components/
---------------- ...
```

### Unity AR Mobile Classes Relevant To Face Recognition & Filtering
- `ARFaceManager`
  - Component of `XROrigin` object
  - Provides an `ARFace` to my runtime via the `FacePrefab` serialized field
- `ARFace`
  - Represents a human face detected and tracked by the device’s front-facing camera.
  - Contains all the realtime topology data for the my prefab's facial mesh
