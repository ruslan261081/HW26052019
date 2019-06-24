using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW26052019_EnumFlags
{
    class Program
    {
        static void Main(string[] args)
        {
            EnumFlag days = new EnumFlag();
            days = EnumFlag.Sunday | EnumFlag.Wednesday;
            Console.WriteLine(days);

            ThisDayExist(days, EnumFlag.Wednesday);
            ThisDayExist(days, EnumFlag.Friday);
            PrintAllMissesDay(days);
            days = AddDay(days, EnumFlag.Monday);
            days = RemoveDay(days, EnumFlag.Wednesday);
            PrintAllMissesDay(days);
        }
        static bool ThisDayExist(EnumFlag myEnum, EnumFlag day)
        {
            if(myEnum.HasFlag(day))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static EnumFlag AddDay(EnumFlag myEnum, EnumFlag day)
        {
            return myEnum | day;
        }
        static EnumFlag RemoveDay(EnumFlag myEnum, EnumFlag day)
        {
            return myEnum &= ~day;
        }
        static void PrintAllMissesDay(EnumFlag e)
        {
            foreach(var v in Enum.GetNames(typeof(EnumFlag)))
            {
                if(Enum.TryParse<EnumFlag>(v, out EnumFlag result) != e.HasFlag(result))
                {
                    Console.WriteLine(result);
                }

            }
        }
    }
}
