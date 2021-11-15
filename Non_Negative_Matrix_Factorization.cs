using CenterSpace.NMath.Core;

namespace NMathPatterns
{
    internal class Non_Negative_Matrix_Factorization
    {
        public Non_Negative_Matrix_Factorization()
        {          
            //This breaks a larger matrix down into two smaller ones, It's like in deep learning where information is removed
            //from the data to make computation faster, and then it's recombined once the important features of the data is worked with

            var start = DateTime.Now;

            var matData = new DoubleMatrix(100, 10, new RandGenUniform(45));

            var names = new string[matData.Cols];
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = "a" + i;
            }
            var data = new DataFrame(matData, names);

            //Factor the matrix using defaults for all factorization settings and the divergence iterative 
            //update for computing the factorization.
            var NMFClustering = new NMFClustering<NMFDivergenceUpdate>();
            NMFClustering.MaxFactorizationIterations = 20000;
            int numberOfClusters = 3;
            NMFClustering.Factor(matData, numberOfClusters);

            Console.WriteLine();

            // Check if the iterative factorization converged before hitting the default maximum
            // number of iterations.
            if (NMFClustering.Converged)
            {
                Console.WriteLine("Factorization converged in {0} iterations.", NMFClustering.Iterations);
            }
            else
            {
                Console.WriteLine("Factorization failed to converge in {0} iterations.", NMFClustering.MaxFactorizationIterations);
            }

            // Get the connectivity matrix. The connectivity matrix is an adjacency matrix, A, such that 
            // columns of the factored matrix are in the same cluster if A[i,j] == 1 and are not in the
            // same cluster if A[i,j] == 0
            ConnectivityMatrix connectivity = NMFClustering.Connectivity;
            Console.WriteLine();
            Console.WriteLine("Connectivity Matrix: ");
            Console.WriteLine(connectivity.ToTabDelimited());
            Console.WriteLine();

            // Print out the cluster each column belongs to using the cluster set.
            ClusterSet cs = NMFClustering.ClusterSet;
            for (int i = 0; i < cs.N; i++)
            {
                Console.WriteLine("Column {0} belongs to cluster {1}", data.ColumnHeaders[i], cs[i]);
            }
            Console.WriteLine();

            // Print out the the members of each cluster using the cluster set.
            for (int clusterNumber = 0; clusterNumber < cs.NumberOfClusters; clusterNumber++)
            {
                int[] members = cs.Cluster(clusterNumber);
                Console.Write("Cluster number {0} contains: ", clusterNumber);
                for (int i = 0; i < members.Length; i++)
                {
                    Console.Write("{0} ", data.ColumnHeaders[members[i]]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter Key");
            Console.Read();
        }
    }    
}
