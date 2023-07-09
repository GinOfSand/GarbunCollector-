using System;
using System.Text;
using Microsoft.Win32;
class ShowRegistry
{
    public static void WriteInfo()
    {
        // запись информации о запуске в реестр
        RegistryKey currentUser = Registry.CurrentUser;
        using (RegistryKey info = currentUser.CreateSubKey("INFO"))
        {
            info.SetValue("RUN", 1);
            if (info.GetValue("Count") == null)
                info.SetValue("Count", 0);
            else
            {
                int count = (int)info.GetValue("Count");
                count++;
                info.SetValue("Count", count);
            }
        }
    }

    public static bool CheckInfo()
    {
        // проверить, установлен ли параметр User/INFO/RUN
        RegistryKey currentUser = Registry.CurrentUser;
        using (RegistryKey info = currentUser.OpenSubKey("INFO"))
        {
            if (info == null)
            {
                return false;
            }
            object value = info.GetValue("RUN");
            return value != null;
        }
    }

    public static void Main()
    {
        // Задача: написать программу, которая должна знать, запускалась
        // ли она ранее на этом компьютере
        // Использовать реестр
        if (CheckInfo())
        {
            WriteInfo();
            RegistryKey cur = Registry.CurrentUser;
            using (RegistryKey info = cur.OpenSubKey("INFO"))
            {
               
                Console.WriteLine($"Программа запускалась ранее на этом устройстве {info.GetValue("Count")}");
            }
            

        }
        else
        {
            WriteInfo();
            Console.WriteLine("Программа запущена первый раз");
        }
        Console.ReadLine();
    }
}
