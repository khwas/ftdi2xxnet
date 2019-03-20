using FTD2XX_NET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftd2xxnet
{
    class Program
    {
        static void Main(string[] args)
        {
            FTDI ftdi = new FTDI();
            FTDI.FT_DEVICE_INFO_NODE[] devicelist = new FTDI.FT_DEVICE_INFO_NODE[2];
            FTDI.FT_STATUS ftStatus = ftdi.GetDeviceList(devicelist);
            Debug.Assert(ftStatus == FTDI.FT_STATUS.FT_OK);
            ftStatus = ftdi.OpenByIndex(1);
            Debug.Assert(ftStatus == FTDI.FT_STATUS.FT_OK);
            if (ftdi.IsOpen)
            {
                FTDI.FT_DEVICE type = FTDI.FT_DEVICE.FT_DEVICE_UNKNOWN;
                ftStatus = ftdi.GetDeviceType(ref type);
                Debug.Assert(ftStatus == FTDI.FT_STATUS.FT_OK);
                Debug.Assert(type == FTDI.FT_DEVICE.FT_DEVICE_2232H);
                //ftdi.
                FTD2XX_NET.FTDI.FT2232H_EEPROM_STRUCTURE ee2232h = new FTDI.FT2232H_EEPROM_STRUCTURE();
                ftStatus = ftdi.ReadFT2232HEEPROM(ee2232h);
                Debug.Assert(ftStatus == FTDI.FT_STATUS.FT_OK);

            }
            else
            {
                throw new Exception();
            }
            ftStatus = ftdi.Close();
            Debug.Assert(ftStatus == FTDI.FT_STATUS.FT_OK);
        }
    }
}
