using CenterSpace.NMath.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFT_Convolution
{
    internal class WaveFunction
    {
        public WaveFunction()
        {
            Console.WriteLine("enter a number");
            var input = Console.ReadLine();
            // Define a harr wavelet and some signal data.
            var harr_kernel = new DoubleVector(input);
            var data = new DoubleVector(50, 25, 10, 5, 2, 1, 2, 5, 10, 25, 50);


            // Create the correlation class.
            var corr = new Double1DCorrelation(harr_kernel, data.Length);

            // Compute the correlation.
            DoubleVector result = corr.Correlate(data);

            // Remove edge effects - trim result to areas with full kernel overlap
            DoubleVector result_trimmed = corr.TrimConvolution(result, CorrelationBase.Windowing.FullKernelOverlap);

            Console.WriteLine();

            Console.WriteLine("Double precision 1D correlation computed.");
            Console.WriteLine("-----------------------------------------\n");
            Console.Write("Kernel = ");
            Console.WriteLine(harr_kernel.ToString());
            Console.Write("Data =   ");
            Console.WriteLine(data.ToString() + "\n");
            Console.WriteLine("Correlation = ");
            Console.WriteLine(result.ToString());
            Console.WriteLine("Correlation trimmed to areas with full kernel overlap = ");
            Console.WriteLine(result_trimmed.ToString());
        }
    }
}
