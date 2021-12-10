using System;
using System.Collections.Generic;
using System.Linq;

namespace Tugas_week_13_lanjutan_scroll_list
{
    class Program
    {
        static void Print(int Urutan, int hitung, List<string> scrolls, List<string> newScrolls)
        {
            foreach (var scroll in newScrolls)
            {
                scrolls.Insert(Urutan + hitung, scroll);
                hitung++;
            }
        }
        static void Main(string[] args)
        {
            var scrolls = new List<string>() { "Book of Peace", "Scroll of Swords", "Silence Guide Book" };
            var newScrolls = new List<string>();
            var hitung = 0;
            while (true)
            {
                var itungan = 0;
                Console.Write("1. My scroll list: \n2. Add scroll\n3. Search scroll\n4. Remove scroll\nChoose what to do:");
                int Nomor = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();
                Console.Clear();
                if (Nomor == 1)
                {
                    Console.WriteLine("Scroll to learn list: \n");

                    foreach (var Daftar in scrolls)
                    {

                        Console.WriteLine($"Scroll {itungan + 1}: {Daftar}");
                        itungan += 1;
                    }
                }
                else if (Nomor == 2)
                {
                    Console.Clear();
                    Console.Write("How many scroll to add: ");
                    int scrollTambah = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\nIn what number of queue?");
                    int Urutan = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < scrollTambah; i++)
                    {
                        Console.Write($"Scroll {i + 1}: ");
                        newScrolls.Add(Console.ReadLine());
                    }
                    if (Urutan < 1)
                    {
                        Urutan = 0;
                        foreach (var scrollkecil in newScrolls)
                        {
                            scrolls.Insert(Urutan, scrollkecil);
                            Urutan++;
                        }
                    }
                    else if (Urutan > scrolls.Count)
                    {
                        Urutan = scrolls.Count;
                        Print(Urutan, hitung, scrolls, newScrolls);
                    }
                    else if (Urutan >= 1 && Urutan <= scrolls.Count)
                    {
                        hitung = -1;
                        Print(Urutan, hitung, scrolls, newScrolls);
                    }
                    newScrolls.Clear();
                }
                else if (Nomor == 3)
                {
                    Console.WriteLine("Insert scroll name: ");
                    var Tambahan = Console.ReadLine();
                    if (scrolls.Contains(Tambahan, StringComparer.CurrentCultureIgnoreCase))
                    {
                        for (int m = 0; m <= scrolls.Count; m++)
                        {
                            var Ketemu = scrolls.Find(v => v.Equals(Tambahan, StringComparison.CurrentCultureIgnoreCase)); 
                            if (scrolls.IndexOf(Ketemu) == m)
                            {
                                Console.WriteLine($"Book found. Queue number: {m + 1}");
                            }   
                        }
                    }
                    else
                    {
                        Console.WriteLine("Book not found");
                    }
                }
                else if (Nomor == 4)
                {
                    Console.WriteLine("Remove from list by scroll name? y/n: ");
                    var YesORNo = Console.ReadLine();
                    while (YesORNo != "y" && YesORNo != "n")
                    {
                        Console.WriteLine("Wrong selection. Choose again: \nRemove from list by scroll name? y/n:");
                        YesORNo = Console.ReadLine();
                    }
                    if (YesORNo == "y")
                    {
                        Console.WriteLine("Input scroll name: ");
                        var NamaDihapus = Console.ReadLine();
                        if (scrolls.Contains(NamaDihapus, StringComparer.CurrentCultureIgnoreCase))
                        {
                            scrolls.RemoveAll(v => v.Equals(NamaDihapus, StringComparison.InvariantCultureIgnoreCase));
                            Console.WriteLine("Book Removed!");
                        }
                        else
                        {
                            Console.WriteLine("Book not found");
                        }
                    }
                    else if (YesORNo == "n")
                    {
                        Console.WriteLine("Input scroll queue: ");
                        var AngkaDihapus = Convert.ToInt32(Console.ReadLine());
                        while (AngkaDihapus <= 0 || AngkaDihapus >= scrolls.Count)
                        {
                            Console.WriteLine("Queue not found. Insert scroll queue: ");
                            AngkaDihapus = Convert.ToInt32(Console.ReadLine());
                        }
                        if (scrolls.Contains(scrolls[AngkaDihapus - 1]))
                        {
                            scrolls.RemoveAt(AngkaDihapus - 1);
                            Console.WriteLine("Book Removed!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Number not found. Please input another number that's written above.");
                }
            }

        }
    }
}



