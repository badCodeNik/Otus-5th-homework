using System;

namespace SaveSystem
{
    [Serializable]
    public class Vector3Data
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3Data(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
    [Serializable]
    public class QuaternionData
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public QuaternionData(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
}