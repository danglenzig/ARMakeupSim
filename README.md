### Main Scene Structure

```
- '*' indicates C# classes that I authored for this assignment
- '**' indicates C# classes included with Unity's AR Mobile template

MakeupSim(scene root)
    XROrigin/
        Components/
            ...
        Child Gameobjects
            Foo/
                Components/
                    ...
                Child Gameobjects/
                    ...

```

### FacePrefab structure

```
- '*' indicates C# classes that I authored for this assignment
- '**' indicates C# classes included with Unity's AR Mobile template

FacePrefab/
    Components/
        ARFace **
        MeshCollider
        MakeupSimFaceManager *
    Child GameObjects/
        LipsLayer/
            Components/
                MakeupSimFaceLayer *
                MeshFilter
                MeshRenderer
        EyeMakeupLayer/
            Components/
                MakeupSimFaceLayer *
                MeshFilter
                MeshRenderer
        (Other layers as needed)/
            components/
                ...
```

