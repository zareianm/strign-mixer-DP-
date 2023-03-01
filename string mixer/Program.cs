using System;

namespace string_mixer
{
    class Program
    {
        static void Main()
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            string s3 = Console.ReadLine();

            Console.WriteLine(StringMixer(s1, s2, s3));
        }


        private static bool StringMixer(string s1, string s2, string s3)
        {
            int s1Len = s1.Length;
            int s2Len = s2.Length;

            if (s1Len + s2Len != s3.Length)
                return false;

            bool[,] DP = new bool[s1Len + 1, s2Len + 1];

            for (int i = 0; i <= s1Len; i++)
            {
                for (int j = 0; j <= s2Len; j++)
                {
                    if (i == 0 && j == 0)
                        DP[i, j] = true;

                    else if (i == 0 && j != 0)
                    {
                        if (s2[j - 1] == s3[i + j - 1])
                        {
                            DP[i, j] = DP[i, j - 1];
                        }

                        else
                            DP[i, j] = false;
                    }

                    else if (j == 0 && i != 0)
                    {
                        if (s1[i - 1] == s3[i + j - 1])
                        {
                            DP[i, j] = DP[i - 1, j];
                        }

                        else
                            DP[i, j] = false;
                    }

                    else if (s1[i - 1] == s3[i + j - 1] && s2[j - 1] != s3[i + j - 1])
                        DP[i, j] = DP[i - 1, j];

                    else if (s2[j - 1] == s3[i + j - 1] && s1[i - 1] != s3[i + j - 1])
                        DP[i, j] = DP[i, j - 1];

                    else if (s2[j - 1] == s3[i + j - 1] && s1[i - 1] == s3[i + j - 1])
                        DP[i, j] = DP[i, j - 1] || DP[i - 1, j];

                    else
                        DP[i, j] = false;
                }
            }

            return DP[s1Len, s2Len];
        }
    }
}
