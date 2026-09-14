# FacePrefab structure

```mermaid
%%{ init : { "themeVariables": { "primaryTextColor": "#ff0000" }}}%%
treeView-beta
            FacePrefab/
                Components/
                    ARFace
                    MeshCollider
                    MakeupSimFaceManager*
                LipsLayer/
                    components/
                        MakeupSimFaceLayer*
                        MeshFilter
                        MeshRenderer
                EyeMakeupLayer/
                    components/
                        MakeupSimFaceLayer*
                        MeshFilter
                        MeshRenderer
                (Other layers as needed)/
                    components/
                        ...
```

