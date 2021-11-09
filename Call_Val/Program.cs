using System;

//請輸入兩個正整數(100~300) 3N+1
//for迴圈
//排序

namespace Call_Val
{
    class Program
    {
        //存放num的迴圈資料
        public struct ThreeN
        {
            public int number;
            public int count;
        }

        //count for 3N+1
        public static int ThreeNPlusOne(int N)
        {
            int count = 0;

            while (N != 1 && count < 500) // 不要讓loop一直跑
            {
                count += 1;
                if ((N % 2) == 1) //奇數
                {
                    N = N * 3 + 1;
                }
                else //偶數
                {
                    N = N / 2;
                }
            }
            return count;
        }

        //BubbleSort 由大到小
        public static void BubbleSort(ThreeN[] data) //call by reference
        {
            ThreeN temp;

            for (int i = 0; i < data.Length - 1; i++)
            {
                for(int j = 0; j < data.Length - 1; j++)
                {
                    if (data[j].count < data[j + 1].count)
                    {
                        temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                    else if (data[j].count == data[j + 1].count)
                    {
                        if (data[j].number < data[j + 1].number)
                        {
                            temp = data[j];
                            data[j] = data[j + 1];
                            data[j + 1] = temp;
                        }
                    }
                }
            }
            ShowContent(data);
        }

        public static void ShowContent(ThreeN[] D)
        {
            Console.WriteLine("--------Print out Content--------");
            for (int i = 0; i < D.Length; i++)
            {
                Console.WriteLine("數字: {0} Loop: {1} 次",
                    D[i].number.ToString().PadLeft(3), D[i].count.ToString().PadLeft(3));
            }
            Console.WriteLine("********END********");
        }

        static void Main(string[] args)
        {
            Console.Write("請輸入兩個正整數(100~300): ");
            int[] N = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

            // 比輸入的兩個正整數的大小
            int num1 = N[0];
            int num2 = N[1];
            if(num1 > num2)
            {
                int temp = num1;
                num1 = num2;
                num2 = temp;
            }
            int total_num = num2 - num1 + 1;
            ThreeN[] data = new ThreeN[total_num];

            for(int i = num1; i <= num2; i++)
            {
                // 將num資料寫入
                data[i - num1].count = ThreeNPlusOne(i);
                data[i - num1].number = i;
            }

            // 印出
            ShowContent(data);

            // 排序data裡的資料
            BubbleSort(data);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
