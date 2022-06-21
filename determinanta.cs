using System;

class Solution
{
    static void Main(string[] args)
    {
        string[] inputs, spec, parts;
        int N = int.Parse(Console.ReadLine()), D, final;
        int[] B = new int[N];                   // slobodni clanovi
        spec = new string[N];                   // zivotinje
        inputs = Console.ReadLine().Split(' ');
        for (int i = 0; i < N; i++) {
            spec[i] = inputs[i];                // spisak zivotinja
        }
        parts = new string[N];                  // delovi tela
        for (int i = 0; i < N; i++) {
            inputs = Console.ReadLine().Split(' ');
            parts[i] = inputs[0];
            B[i] = int.Parse(inputs[1]);
        }

        int[,] determ = new int[N,N];
        for (int j = 0; j < N; j++) {
            string part = parts[j];
            for (int i = 0; i < N; i++) {
                string animal = spec[i];
                determ[j,i] = Values (animal, part);
            }
        }
        D = DetCalc (determ, N);                // resenje glavne Determinante

        int[,] rot = new int[N,N];
        for (int i = 0; i < N; i++) {
            Array.Copy(determ, rot, N * N);
            for (int j = 0; j < N; j++) {
                rot[j,i] = B[j];
            }
            final = DetCalc (rot, N) / D;
            Console.WriteLine(spec[i] + " " + final);
        }

    }
    static int DetCalc (int[,] mat, int n) {
        if (n == 2) {
            return mat[0,0] * mat[1,1] - mat[1,0] * mat[0,1];
        }
        else {
            int result = 0;
            int[,] nova = new int[n-1,n-1];

            for (int x = 0; x < n; x++) {       // x za svaku pod-matricu od 0..n
                for (int j = 1; j < n; j++) {
                    int a = 0;
                    for (int i = 0; i < n; i++) {
                        if (i != x) {
                            nova[j-1,a] = mat[j,i];
                            a++;
                        }
                    }
                }
                int sign = (x % 2 == 0) ? 1 : -1;
                result += sign * mat[0,x] * DetCalc (nova, n-1);
            }
            return result;
        }
    }
    static int Values (string animal, string part) {
        switch (animal) {
            case "Cows":
                switch (part) {
                    case "Heads": return 1;
                    case "Legs": return 4;
                    case "Wings": return 0;
                    case "Eyes": return 2;
                    case "Horns": return 2;
                    default: return 0;
                }
            case "Rabbits":
                switch (part) {
                    case "Heads": return 1;
                    case "Legs": return 4;
                    case "Wings": return 0;
                    case "Eyes": return 2;
                    case "Horns": return 0;
                    default: return 0;
                }
            case "Chickens":
                switch (part) {
                        case "Heads": return 1;
                        case "Legs": return 2;
                        case "Wings": return 2;
                        case "Eyes": return 2;
                        case "Horns": return 0;
                        default: return 0;
                }
            case "Pegasi":
                switch (part) {
                        case "Heads": return 1;
                        case "Legs": return 4;
                        case "Wings": return 2;
                        case "Eyes": return 2;
                        case "Horns": return 0;
                        default: return 0;
                }
            case "Demons":
                switch (part) {
                        case "Heads": return 1;
                        case "Legs": return 4;
                        case "Wings": return 2;
                        case "Eyes": return 4;
                        case "Horns": return 4;
                        default: return 0;
                }
            default: return 0;
        }
    }
}
