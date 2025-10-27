﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorPrivateAssembly
{
    public class BasicComputation
    {
        public static float Add(float a, float b) => a + b;
        public static float Subtract(float a, float b) => a - b;
        public static float Multiply(float a, float b) => a * b;
        public static float Divide(float a, float b) => b != 0 ? a / b : 0;
        public static float Percent(float a, float b) => a / 100 * b;
    }
}
