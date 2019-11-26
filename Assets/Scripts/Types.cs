namespace Types {
    public enum CameraView {
          FPP
        , TPP
        , FreeCam
    }

    public struct Sensitivity {
        public float X {get; }
        public float Y {get; }

        public Sensitivity(float x, float y) { X = x; Y = y;}
    }

    public enum KeyPushMode {
          Toggle
        , Hold
    }

    public enum GunType {
          Auto
        , Semi
    }
}


