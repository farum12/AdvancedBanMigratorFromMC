using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedBanConverter
{
    public class Punishment
    {
        public String name;
        String uuid;
        String reason;
        String oper;
        String punishmentType;
        Int64 start;
        int end;
        String calculation = "";

        public Punishment(String name, String uuid, String reason, String oper, String punishmentType, Int64 start, int end)
        {
            this.name = name;
            this.uuid = uuid;
            this.reason = reason;
            this.oper = oper;
            this.punishmentType = punishmentType;
            this.start = start;
            this.end = end;
        }

        public void ToStr()
        {
            Console.Write("('" + name + "','" + uuid + "','" + reason + "','" + oper + "','" + punishmentType + "'," + start + "," + end + ",'')");
        }
    }
}
