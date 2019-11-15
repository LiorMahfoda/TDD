using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Final
/// </summary>

namespace Ex2 
{
    public class Employee
    {
        // Properties
        private String[] Id;
        private String[] First;
        private String[] Last;
        private String[] Email;
        private String[] Tele;
        private String[] Addr;
        private double Sal;

        //Initialize variabels
        private string[] nums = { "0", "1", "2", "3", "4", "", "6", "7", "8", "9" };
        private string[] phone = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private string[] smallLetter = { "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r",
            "s","t","u","v","w","q","y","z" };
        private string[] capitalLetter = { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R",
            "S","T","U","V","W","X","Y","Z" };

        // Random generated number
        private static Random r;

        private static void Instance()
        {
            if (r == null)
                r = new Random(); // if instance doesn't exist
        }
       
        // C'tor for class Employee
        public Employee()
        {
            RanId();
            RanFirst();
            RanLast();
            RanEmail();
            RanTele();
            RanAddr();
            RanSal();
        }

        // Make a random string
        private string[] RandomString(String[] str, int length)
        {
            String[] temp = new String[length];
            Instance();
            for (int i = 0; i < length; i++)
                temp[i] = str[r.Next(str.Length)];
            return temp;
        }

        //Random id 
        public void RanId()
        {
            this.Id = RandomString(nums, 9);
        }

        //Random first name
        public void RanFirst()
        {
            this.First = RandomString(nums, 9);
        }

        //Random last name
        public void RanLast()
        {
            String[] str1 = RandomString(capitalLetter, 1);
            String[] str2 = RandomString(smallLetter, RandomNumber(10) + 2);
            String[] x = new string[10];
            for (int i = 0; i < 10; i++)
                x[i] = str1[i] + str2[i];
            this.Last = x;
        }

        //Random email
        public void RanEmail()
        {
            int i;
            String[] x = new string[20];
            String[] str1 = RandomString(smallLetter, r.Next(10) + 2) ;
            String[] str2 = { "@" };
            String[] str3 = RandomString(smallLetter, +2);
            String[] str4 = { "." };
            String[] str5 = RandomString(smallLetter, r.Next(10));
            for (i = 0; i < str1.Length; i++)
                x[i] = str1[i];
            x[i] = str2[0];
            for (; i < str3.Length; i++)
                x[i] = str3[i];
            x[i] = str4[0];
            for (; i < str5.Length; i++)
                x[i] = str5[i];
            this.Last = x;
        }

        //Random telephone
        public void RanTele()
        {
            int i = 0;
            String[] x = new string[10];
            String[] str1 = { "05" };
            String[] str2 = RandomString(phone, 1);
            String[] str3 = { "-" };
            String[] str4 = RandomString(nums, 7);
            x[0] = str1[0]; i++;
            x[1] = str2[0]; i++;
            x[2] = str3[0]; i++;
            for (i = 0; i < str4.Length; i++)
                x[i] = str3[i];
            this.Tele = x;
        }

        //Random address
        public void RanAddr()
        {
            int i = 0;
            String[] x = new string[20];
            String[] str1 = RandomString(capitalLetter, 1);
            String[] str2 = { " " };
            String[] str3 = RandomString(nums, RandomNumber(3) + 2);
            for (; i < str1.Length; i++)
                x[i] = str1[i];
            x[i] = str2[0];
            for (; i < str3.Length; i++)
                x[i] = str3[i];
            this.Addr = x;
        }

        //Random salary      
        public void RanSal()
        {
            this.Sal = r.Next(20000) + 1000;
        }

        // Get functions for all attributes
        public String[] GetId()
        {
            return this.Id;
        }

        public String[] GetName()
        {
            return this.First;
        }

        public String[] GetLastName()
        {
            return this.Last;
        }

        public String[] GetEmail()
        {
            return this.Email;
        }

        public String[] GetTele()
        {
            return this.Tele;
        }

        public String[] GetAddr()
        {
            return this.Addr;
        }

        public double GetSal()
        {
            return this.Sal;
        }

        // Get an employee from database
        public String[] get()
        {
            String[] oved = { "this.Id", "this.First", "this.Last", "this.Email", "this.Tele", "this.Addr" };

            return oved;
        }

        // Makes a random name
        private string RndStr(String str, int length)
        {
            char[] buffer = new char[length];
            Instance();
            for (int i = 0; i < length; i++)
            {
                buffer[i] = str[r.Next(str.Length)];
            }
            return new string(buffer);

        }

        // Makes a random number for salary
        private int RandomNumber(int index)
        {
            Instance();
            return r.Next(index);
        }
    }
}

//