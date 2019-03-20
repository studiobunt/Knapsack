using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Knapsack
    {
        private string plainText;

        public string getPublicKey(int n, int m, string[] arr)
        {
            string k = "";

            foreach (string el in arr)
            {
                int i = (Convert.ToInt32(el) * Convert.ToInt32(n)) % Convert.ToInt32(m);
                if (k == "") k += i.ToString();
                else k += "," + i.ToString();
            }
            return (k);
        }

        public int fullfil(int key, int data)
        {
            int mod = data % key;
            int rest = key - mod;
            int fullfil = data + rest;
            return fullfil;
        }

        public string getcipher(string publickey, string data)
        {
            string data_result = "";
            string[] vals = publickey.Split(',');
            int[] weights = new int[vals.Length];
            for (int i = 0; i < vals.Length; i++) weights[i] = Convert.ToInt32(vals[i]);
            int ptr = 0;
            int bit = 0;
            int total = 0;
            do
            {
                total = 0;
                for (int i = 0; i < vals.Length; i++)
                {
                    if (ptr < data.Length)
                    {
                        if (data[ptr] == '1') bit = 1;
                        else bit = 0;
                        total += weights[i] * bit;
                        Console.WriteLine(i);
                        Console.WriteLine(ptr);
                        ptr++;
                    }
                }
                if (data_result == "") data_result += total.ToString();
                else data_result += "," + total.ToString();

            } while (ptr < data.Length);


            return (data_result);

        }

        Dictionary<char, int> english = new Dictionary<char, int>()
        {
            { 'a', 0 }, { 'b', 1 }, { 'c', 2 }, { 'd', 3 }, { 'e', 4 },
            { 'f', 5 }, { 'g', 6 }, { 'h', 7 }, { 'i', 8 }, { 'j', 9 },
            { 'k', 10 }, { 'l', 11 }, { 'm', 12 }, { 'n', 13 }, { 'o', 14 },
            { 'p', 15 }, { 'q', 16 }, { 'r', 17 }, { 's', 18 }, { 't', 19 },
            { 'u', 20 }, { 'v', 21 }, { 'w', 22 }, { 'x', 23 }, { 'y', 24 }, { 'z', 25 }
        };

        Dictionary<int, char> englishInverse = new Dictionary<int, char>()
        {
            { 0, 'a' }, { 1, 'b' }, { 2, 'c' }, { 3, 'd' }, { 4, 'e'},
            { 5, 'f'}, { 6, 'g'}, { 7, 'h'}, { 8, 'i'}, { 9, 'j'},
            { 10, 'k'}, { 11, 'l'}, { 12, 'm'}, { 13, 'n'}, { 14, 'o'},
            { 15, 'p'}, { 16, 'q'}, { 17, 'r'}, { 18, 's'}, { 19, 't'},
            { 20, 'u'}, { 21, 'v'}, { 22, 'w'}, { 23, 'x'}, { 24, 'y'}, { 25, 'z'}
        };

        Dictionary<char, int> turkish = new Dictionary<char, int>()
        {
            { 'a', 0 }, { 'b', 1 }, { 'c', 2 }, { 'ç', 3 }, { 'd', 4 },
            { 'e', 5 }, { 'f', 6 }, { 'g', 7 }, { 'ğ', 8 }, { 'h', 9 },
            { 'ı', 10 }, { 'i', 11 }, { 'j', 12 }, { 'k', 13 }, { 'l', 14 },
            { 'm', 15 }, { 'n', 16 }, { 'o', 17 }, { 'ö', 18 }, { 'p', 19 },
            { 'r', 20 }, { 's', 21 }, { 'ş', 22 }, { 't', 23 }, { 'u', 24 },
            { 'ü', 25 }, { 'v', 26 }, { 'y', 27 }, { 'z', 28 }
        };

        Dictionary<int, char> turkishInverse = new Dictionary<int, char>()
        {
            { 0, 'a' }, { 1, 'b' }, { 2, 'c' }, { 3, 'ç' }, { 4, 'd'},
            { 5, 'e'}, { 6, 'f'}, { 7, 'g'}, { 8, 'ğ'}, { 9, 'h'},
            { 10, 'ı'}, { 11, 'i'}, { 12, 'j'}, { 13, 'k'}, { 14, 'l'},
            { 15, 'm'}, { 16, 'n'}, { 17, 'o'}, { 18, 'ö'}, { 19, 'p'},
            { 20, 'r'}, { 21, 's'}, { 22, 'ş'}, { 23, 't'}, { 24, 'u'},
            { 25, 'ü'}, { 26, 'v'}, { 27, 'y'}, { 28, 'z'}
        };

        public string convertToBinary(string data)
        {
            int value;
            string binary = "";
            foreach (char c in data)
            {
                if (english.TryGetValue(c, out value))
                {
                    Console.WriteLine("For key = \"tif\", value = {0}.", value);
                }
                else
                {
                    Console.WriteLine("Key = \"tif\" is not found.");
                }
                if (value <= 15)
                {
                    binary += Convert.ToString(value, 2).PadLeft(8, '0'); //za brojeve vece od 15 padleft 8 0, napisi if
                } else
                {
                    binary += Convert.ToString(value, 2).PadLeft(8, '0');
                }
                Console.WriteLine(binary);
            }
            return binary;
        }
        public string convertToBinaryTurkish(string data)
        {
            int value;
            string binary = "";
            foreach (char c in data)
            {
                if (turkish.TryGetValue(c, out value))
                {
                    Console.WriteLine("For key = \"tif\", value = {0}.", value);
                }
                else
                {
                    Console.WriteLine("Key = \"tif\" is not found.");
                }
                if (value <= 15)
                {
                    binary += Convert.ToString(value, 2).PadLeft(8, '0'); //za brojeve vece od 15 padleft 8 0, napisi if
                }
                else
                {
                    binary += Convert.ToString(value, 2).PadLeft(8, '0');
                }
                Console.WriteLine(binary);
            }
            return binary;
        }

        public int solve(int n, int m)
        {
            int res = 0;
            for (int i = 0; i < 50000; i++)
            {
                if (((n * i) % m) == 1) return (i);
            }
            return (res);
        }

        public string calculatePlain(string[] cipherArr, int inverse, int m)
        {
            string plain="";
            foreach(string cipher in cipherArr)
            {
                int i = (inverse * Convert.ToInt32(cipher)) % m;
                if (plain == "") plain += i.ToString();
                else plain += "," + i.ToString();
            }
            return (plain);
        }

        public string calculateBinary(string calculatePlain, string superIncreasing)
        {
            string plainKnapSack = "";
            string binary = "";
            string[] calculatePlainArr = calculatePlain.Split(',');
            string[] superIncreasingArr = superIncreasing.Split(',');
            int length = superIncreasingArr.Length;
            foreach (string Plain in calculatePlainArr)
            {
                int data = Convert.ToInt32(Plain);
                for (int i=length; i>0; i--)
                {
                    if (data >= Convert.ToInt32(superIncreasingArr[i - 1]))
                    {
                        if (data >= 0)
                        {
                            if (plainKnapSack == "") {
                                plainKnapSack += superIncreasingArr[i - 1];
                                binary += "1";
                            }
                            else if(plainKnapSack!="") {
                                plainKnapSack += "," + superIncreasingArr[i - 1];
                                binary += "1";
                            }
                            data = data - Convert.ToInt32(superIncreasingArr[i - 1]);
                        }
                    }
                    else
                    {
                        binary += "0";
                    }
                }
                binary += ",";
            }
            binary = binary.Remove(binary.Length - 1);
            string output = "";
            string[] binaryArr = binary.Split(',');
            foreach (string binar in binaryArr)
            {
                char[] charArray = binar.ToCharArray();
                Array.Reverse(charArray);
                binary = new string(charArray);
                output += binary;
            }
            return (output);
        }

        static IEnumerable<string> Split(string output)
        {
            return Enumerable.Range(0, output.Length / 8)
                .Select(i => output.Substring(i * 8, 8));
        }

        public string binaryToDec(string binary)
        {
            string output = "";
            int rez = binary.Length % 8;
            if (rez > 0) { 
            string binaryArr = binary.Remove(binary.Length - rez);
                
            foreach (string value in Split(binaryArr))
            {
                output += (Convert.ToInt32(value, 2) % 26).ToString();
                output += ",";
                }
                }
            else
            {
                foreach (string value in Split(binary))
                {
                    output += (Convert.ToInt32(value, 2) % 29).ToString();
                    output += ",";
                }
            }
            output = output.Remove(output.Length - 1);
            return (output);
        }
        public string binaryToDecTurkish(string binary)
        {
            string output = "";
            int rez = binary.Length % 8;
            if (rez > 0)
            {
                string binaryArr = binary.Remove(binary.Length - rez);

                foreach (string value in Split(binaryArr))
                {
                    output += (Convert.ToInt32(value, 2) % 29).ToString();
                    output += ",";
                }
            }
            else
            {
                foreach (string value in Split(binary))
                {
                    output += (Convert.ToInt32(value, 2) % 26).ToString();
                    output += ",";
                }
            }
            output = output.Remove(output.Length - 1);
            return (output);
        }
        public string decToChar(string dec)
        {
            char value;
            string output = "";
            string[] decArr = dec.Split(',');
            foreach (string c in decArr)
            {
                if (englishInverse.TryGetValue(Convert.ToInt32(c), out value))
                {
                    Console.WriteLine("For key = \"tif\", value = {0}.", value);
                    output += value;
                }
                else
                {
                    Console.WriteLine("Key = \"tif\" is not found.");
                }
            }
            return (output);
        }
        public string decToCharTurkish(string dec)
        {
            char value;
            string output = "";
            string[] decArr = dec.Split(',');
            foreach (string c in decArr)
            {
                if (turkishInverse.TryGetValue(Convert.ToInt32(c), out value))
                {
                    Console.WriteLine("For key = \"tif\", value = {0}.", value);
                    output += value;
                }
                else
                {
                    Console.WriteLine("Key = \"tif\" is not found.");
                }
            }
            return (output);
        }
    }
}
