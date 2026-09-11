using UnityEngine;

namespace MakupSim
{
    // Lives on a runtime data manager singleton
    public class MakeupSimFaceState
    {
        private int _lipsSizeIdx = 0;
        private int _lipsColorIdx = 0;

        public int LipsSizeIdx { get { return _lipsSizeIdx; } }
        public int LipsColorIdx { get {return _lipsColorIdx; } }

        public void SetLipsSizeIdx(int lipsSizeIdx)
        {
            _lipsSizeIdx = lipsSizeIdx;
        }
        public void SetLipsColorIdx(int lipsColorIdx)
        {
            _lipsColorIdx = lipsColorIdx;
        }

        public int GetSizeIdx(string tagString)
        {
            switch (tagString)
            {
                case "LIPS":
                    return _lipsSizeIdx;

                // and so on

                default:
                    break;
            }
            return 0;
        }

        public int GetColorIdx(string tagString)
        {
            switch (tagString)
            {
                case "LIPS":
                    return _lipsColorIdx;

                // and so on

                default:
                    break;
            }
            return 0;
        }

    }
}

