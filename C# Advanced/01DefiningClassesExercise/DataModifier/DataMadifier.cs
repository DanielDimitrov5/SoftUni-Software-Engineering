using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModifier
{
    public class DataMadifier
    {
        public static int DiffCalcularor(string startData, string endData)
        {
            int[] dataASplited = startData.Split().Select(int.Parse).ToArray();

            int yearA = dataASplited[0];
            int monthA = dataASplited[1];
            int dayA = dataASplited[2];

            DateTime A = new DateTime(yearA, monthA, dayA);

            int[] dataBSplited = endData.Split().Select(int.Parse).ToArray();

            int yearB = dataBSplited[0];
            int monthB = dataBSplited[1];
            int dayB = dataBSplited[2];

            DateTime B = new DateTime(yearB, monthB, dayB);

            int dayDiff = Math.Abs((A - B).Days);

            return dayDiff;
        }
    }
}
