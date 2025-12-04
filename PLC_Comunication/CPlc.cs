using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class CPlc
{
    private static ActUtlTypeLib.ActUtlType mPlc = new ActUtlTypeLib.ActUtlType();
    private static ASCIIEncoding aSCII = new ASCIIEncoding();
    public static bool IsOpen;
    public static int ReturnCode;
    public struct PLCInformation
    {
        public string CpuType;
        public DateTime PlcTime;
    }
    public static void SetConfig(int iLogicalNumber, string szPassword = "")
    {
        Close();
        mPlc.ActLogicalStationNumber = iLogicalNumber;
        mPlc.ActPassword = szPassword;
    }
    public static bool Open()
    {
        int iRet = mPlc.Open();
        IsOpen = iRet == 0;
        ReturnCode = iRet;
        return IsOpen;
    }
    public static void Close()
    {
        ReturnCode = mPlc.Close();
        IsOpen = false;
    }
    public static PLCInformation GetPlcInformation()
    {
        PLCInformation info = new PLCInformation();
        info.CpuType = CpuType;

        short[] sPlcTime = new short[7];
        int iRet = mPlc.GetClockData(out sPlcTime[0], out sPlcTime[1], out sPlcTime[2], out sPlcTime[3], out sPlcTime[4], out sPlcTime[5], out sPlcTime[6]);

        if (iRet == 0)
        {
            info.PlcTime = new DateTime(sPlcTime[0], sPlcTime[1], sPlcTime[2], sPlcTime[4], sPlcTime[5], sPlcTime[6]);
        }
        else info.PlcTime = DateTime.MinValue;
        ReturnCode = iRet;
        return info;
    }
    public static string CpuType
    {
        get
        {
            string sCpuType = string.Empty;
            string sCpuName;
            int iCpuCode;
            int iRet = mPlc.GetCpuType(out sCpuName, out iCpuCode);
            if (iRet == 0) sCpuType = sCpuName + "_" + iCpuCode.ToString();
            else sCpuType = "Error 0x" + iRet.ToString("X8");
            ReturnCode = iRet;
            return sCpuType;
        }
    }
    public static int GetValue16(string szDeviceName, out short sValue)
    {
        int iRet = -1;
        sValue = 0;
        char contanceType = szDeviceName.Trim()[0];
        if (contanceType == 'K')
        {
            string strValue = szDeviceName.Substring(1, szDeviceName.Length - 1);
            if (short.TryParse(strValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out sValue)) iRet = 0;
            else return -1;
        }
        else if (contanceType == 'H')
        {
            string strValue = szDeviceName.Substring(1, szDeviceName.Length - 1);
            if (short.TryParse(strValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out sValue)) iRet = 0;
            else return -1;
        }
        else iRet = mPlc.GetDevice2(szDeviceName, out sValue);
        return iRet;
    }
    public static int GetValue32(string szDeviceName, out int sValue)
    {
        sValue = 0;
        int iRet = 0;
        short[] shorts = new short[2];

        char contanceType = szDeviceName.Trim()[0];
        if (contanceType == 'K')
        {
            string strValue = szDeviceName.Substring(1, szDeviceName.Length - 1);
            if (int.TryParse(strValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out sValue)) iRet = 0;
            else return -1;
        }
        else if (contanceType == 'H')
        {
            string strValue = szDeviceName.Substring(1, szDeviceName.Length - 1);
            if (int.TryParse(strValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out sValue)) iRet = 0;
            else return -1;
        }
        else
        {
            iRet = mPlc.ReadDeviceBlock2(szDeviceName, 2, out shorts[0]);
            sValue = (shorts[0] & 0xffff) | ((shorts[1] << 16) & 0xffff);
        }
        return iRet;
    }
    public static int SetValue16(string szValueName, string szDeviceName)
    {
        short sValue = 0;
        ReturnCode = GetValue16(szValueName, out sValue);
        if (sValue != 0) return ReturnCode;
        ReturnCode = mPlc.SetDevice2(szDeviceName, sValue);
        return ReturnCode;
    }
    public static int SetValue32(string szValueName, string szDeviceName)
    {
        int sValue = 0;
        ReturnCode = GetValue32(szValueName, out sValue);
        short[] shorts = new short[2];
        shorts[0] = (short)(sValue & 0xffff);
        shorts[1] = (short)(sValue >> 16);
        int iRet = mPlc.WriteDeviceBlock2(szDeviceName, 2, ref shorts[0]);
        return iRet;
    }
    public static int GetString(string szDeviceName, string szSizeName, out string strValue)
    {
        char[] sep = new char[] { ' ', '\0' };
        strValue = string.Empty;
        short sLength = 0;
        ReturnCode = GetValue16(szSizeName, out sLength);
        if(ReturnCode != 0) return ReturnCode;
        short[] sValue = new short[sLength];
        ReturnCode = mPlc.ReadDeviceBlock2(szDeviceName, sLength, out sValue[0]);
        byte[] bytes = new byte[sLength * 2];
        for(int i = 0; i < sValue.Length; i++)
        {
            bytes[i * 2] = (byte)(sValue[i] & 0xff);
            bytes[i * 2 + 1] = (byte)(sValue[i] >> 8);
        }
        strValue = aSCII.GetString(bytes, 0, bytes.Length);
        strValue = strValue.Trim(sep);
        return ReturnCode;
    }
    public static int SET(string szDeviceName)
    {
        ReturnCode = mPlc.SetDevice2(szDeviceName, 1);
        return ReturnCode;
    }
    public static int RST(string szDeviceName)
    {
        ReturnCode = mPlc.SetDevice2(szDeviceName, 0);
        return ReturnCode;
    }
    public static int FF(string szDeviceName)
    {
        short iValue;
        ReturnCode = GetValue16(szDeviceName, out iValue);
        if (ReturnCode != 0) return ReturnCode;
        iValue = (short)(iValue == 0 ? 1 : 0);
        ReturnCode = mPlc.SetDevice2(szDeviceName, iValue);
        return ReturnCode;
    }
    public static int BSET(string szDeviceName, string szBitPosName)
    {
        short iValue;
        ReturnCode = GetValue16(szDeviceName, out iValue);
        if (ReturnCode != 0) return ReturnCode;
        short bitPos;
        ReturnCode = GetValue16(szBitPosName, out bitPos);
        if (ReturnCode != 0) return ReturnCode;
        iValue = (short)(iValue | (short)(1 << bitPos));
        ReturnCode = mPlc.SetDevice2(szDeviceName, iValue);
        return ReturnCode;
    }
    public static int BRST(string szDeviceName, string szBitPosName)
    {
        short iValue;
        ReturnCode = GetValue16(szDeviceName, out iValue);
        if (ReturnCode != 0) return ReturnCode;
        short bitPos;
        ReturnCode = GetValue16(szBitPosName, out bitPos);
        if (ReturnCode != 0) return ReturnCode;
        iValue = (short)(iValue & (short)~(1 << bitPos));
        ReturnCode = mPlc.SetDevice2(szDeviceName, iValue);
        return ReturnCode;
    }
    public static int MOV(string szValueName, string szDeviceName)
    {
        return SetValue16(szValueName, szDeviceName);
    }
    public static int DMOV(string szValueName, string szDeviceName)
    {
        return SetValue32(szValueName, szDeviceName);
    }
    public static int BMOV(string szSourceDeviceName, string szDestDeviceName, string szLengthName)
    {
        short length;
        ReturnCode = GetValue16(szLengthName, out length);
        if (ReturnCode != 0) return ReturnCode;
        short[] sValues = new short[length];
        ReturnCode = mPlc.ReadDeviceBlock2(szSourceDeviceName, length, out sValues[0]);
        if (ReturnCode != 0) return ReturnCode;
        ReturnCode = mPlc.WriteDeviceBlock2(szDestDeviceName, length, ref sValues[0]);
        return ReturnCode;
    }
    public static int FMOV(string szSourceDeviceName, string szDestDeviceName, string szLengthName)
    {
        short iValue;
        ReturnCode = GetValue16(szSourceDeviceName, out iValue);
        if (ReturnCode != 0) return ReturnCode;
        short iLength;
        ReturnCode = GetValue16(szLengthName, out iLength);
        if (ReturnCode != 0) return ReturnCode;
        short[] sValues = new short[iLength];
        for (int i = 0; i < iLength; i++)
        {
            sValues[i] = iValue;
        }
        ReturnCode = mPlc.WriteDeviceBlock2(szDestDeviceName, iLength, ref sValues[0]);
        return ReturnCode;
    }
    public static int DBL(string szSourceDeviceName, string szDestDeviceName)
    {
        short iValue;
        ReturnCode = GetValue16(szSourceDeviceName, out iValue);
        if (ReturnCode != 0) return ReturnCode;
        short[] sValues = new short[2];
        sValues[0] = iValue;
        sValues[1] = 0;
        ReturnCode = mPlc.WriteDeviceBlock2(szDestDeviceName, 2, ref sValues[0]);
        return ReturnCode;
    }
    public static int SFL(string szDestinationName, string szNumberName)
    {
        short iNumber;
        ReturnCode = GetValue16(szNumberName, out iNumber);
        if (ReturnCode != 0) return ReturnCode;
        short iValue;
        ReturnCode = GetValue16(szDestinationName, out iValue);
        if (ReturnCode != 0) return ReturnCode;
        iValue = (short)(iValue << iNumber);
        ReturnCode = mPlc.SetDevice2(szDestinationName, iValue);
        return ReturnCode;
    }
    public static int SFR(string szDestinationName, string szNumberName)
    {
        short iNumber;
        ReturnCode = GetValue16(szNumberName, out iNumber);
        if (ReturnCode != 0) return ReturnCode;
        short iValue;
        ReturnCode = GetValue16(szDestinationName, out iValue);
        if (ReturnCode != 0) return ReturnCode;
        iValue = (short)(iValue >> iNumber);
        ReturnCode = mPlc.SetDevice2(szDestinationName, iValue);
        return ReturnCode;
    }
    public static int INC(string szDeviceName)
    {
        short iValue;
        ReturnCode = GetValue16(szDeviceName, out iValue);
        if (ReturnCode != 0) return ReturnCode;
        iValue++;
        ReturnCode = mPlc.SetDevice2(szDeviceName, iValue);
        return ReturnCode;
    }
    public static int DEC(string szDeviceName)
    {
        short iValue;
        ReturnCode = GetValue16(szDeviceName, out iValue);
        if (ReturnCode != 0) return ReturnCode;
        iValue--;
        ReturnCode = mPlc.SetDevice2(szDeviceName, iValue);
        return ReturnCode;
    }
    public static int ADD(string szAddend1, string szAddend2, string szSum)
    {
        short iValue1;
        ReturnCode = GetValue16(szAddend1, out iValue1);
        if (ReturnCode != 0) return ReturnCode;
        short iValue2;
        ReturnCode = GetValue16(szAddend2, out iValue2);
        if (ReturnCode != 0) return ReturnCode;
        short iSum = (short)(iValue1 + iValue2);
        ReturnCode = mPlc.SetDevice2(szSum, iSum);
        return ReturnCode;
    }
    public static int SUB(string szMinuend, string szSubtrahend, string szDifference)
    {
        short iValue1;
        ReturnCode = GetValue16(szMinuend, out iValue1);
        if (ReturnCode != 0) return ReturnCode;
        short iValue2;
        ReturnCode = GetValue16(szSubtrahend, out iValue2);
        if (ReturnCode != 0) return ReturnCode;
        short iDifference = (short)(iValue1 - iValue2);
        ReturnCode = mPlc.SetDevice2(szDifference, iDifference);
        return ReturnCode;
    }
    public static int MUL(string szMultiplier, string szMultiplicand, string szProduct)
    {
        short iValue1;
        ReturnCode = GetValue16(szMultiplier, out iValue1);
        if (ReturnCode != 0) return ReturnCode;
        short iValue2;
        ReturnCode = GetValue16(szMultiplicand, out iValue2);
        if (ReturnCode != 0) return ReturnCode;
        int iProduct = iValue1 * iValue2;
        ReturnCode = SetValue32("K" + iProduct.ToString(), szProduct);
        return ReturnCode;
    }
    public static int DIV(string szDividend, string szDivisor, string szQuotient)
    {
        short iValue1;
        ReturnCode = GetValue16(szDividend, out iValue1);
        if (ReturnCode != 0) return ReturnCode;
        short iValue2;
        ReturnCode = GetValue16(szDivisor, out iValue2);
        if (ReturnCode != 0) return ReturnCode;
        if (iValue2 == 0)
        {
            ReturnCode = -1; // Division by zero error
            return ReturnCode;
        }
        short[] iQuotient = new short[2];
        iQuotient[0] = (short)(iValue1 / iValue2);
        iQuotient[1] = (short)(iValue1 % iValue2);
        ReturnCode = mPlc.WriteDeviceBlock2(szQuotient, 2, ref iQuotient[0]);
        return ReturnCode;
    }
    public static int sMOV(string sValue, string szDeviceName)
    {
        if (sValue.Length <= 0)
        {
            ReturnCode = -1;
            return ReturnCode;
        }
        byte[] bytes = Encoding.ASCII.GetBytes(sValue);
        int length = bytes.Length / 2;
        length += bytes.Length % 2;
        short[] iValue = new short[length];
        for (int i = 0; i < length; i++)
        {
            iValue[i] = (short)(bytes[i * 2]);
            if (i * 2 + 1 < bytes.Length) iValue[i] |= (short)(bytes[i * 2 + 1] << 8);
        }
        ReturnCode = mPlc.WriteDeviceBlock2(szDeviceName, iValue.Length, ref iValue[0]);
        return ReturnCode;
    }
}