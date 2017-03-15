namespace TrabalhoTesteSoftware
{
    public interface ISensor
    {
        bool setH();
        bool resetH();
        bool getH();
        void setR(float r);
        float getR();
        bool setValue(float v);
        bool getAlert();
    }
}
