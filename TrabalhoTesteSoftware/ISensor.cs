using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoTesteSoftware
{
    interface ISensor
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
