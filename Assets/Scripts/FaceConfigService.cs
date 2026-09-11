using UnityEngine;

namespace MakupSim
{
    public class FaceConfigService : Singleton<FaceConfigService>
    {
        private MakeupSimFaceState _faceConfig = new MakeupSimFaceState();

        public MakeupSimFaceState FaceConfig { get { return _faceConfig; } }

    }
}

