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
    public enum ErrorType
    {
        Normal,
        Warning,
        Error
    }
    public static void SetConfig(int iLogicalNumber, string szPassword = "")
    {
        Close();
        mPlc.ActLogicalStationNumber = iLogicalNumber;
        mPlc.ActPassword = szPassword;
    }
    public static bool Open()
    {
        ReturnCode = mPlc.Open();
        IsOpen = ReturnCode == 0;
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
        ReturnCode = mPlc.GetClockData(out sPlcTime[0], out sPlcTime[1], out sPlcTime[2], out sPlcTime[3], out sPlcTime[4], out sPlcTime[5], out sPlcTime[6]);

        if (ReturnCode == 0)
        {
            info.PlcTime = new DateTime(sPlcTime[0], sPlcTime[1], sPlcTime[2], sPlcTime[4], sPlcTime[5], sPlcTime[6]);
        }
        else info.PlcTime = DateTime.MinValue;
        return info;
    }
    public static string CpuType
    {
        get
        {
            string sCpuType = string.Empty;
            string sCpuName;
            int iCpuCode;
            ReturnCode = mPlc.GetCpuType(out sCpuName, out iCpuCode);
            if (ReturnCode == 0) sCpuType = sCpuName + "_" + iCpuCode.ToString();
            else sCpuType = "Error 0x" + ReturnCode.ToString("X8");
            return sCpuType;
        }
    }
    public static string LastErrorMessage
    {
        get
        {
            string errorMessage;
            ErrorType errorType;
            CheckReturnCode(ReturnCode, out errorMessage, out errorType);
            return errorMessage;
        }
    }
    public static ErrorType LastErrorType
    {
        get
        {
            string errorMessage;
            ErrorType errorType;
            CheckReturnCode(ReturnCode, out errorMessage, out errorType);
            return errorType;
        }
    }
    public static bool IsValidDevice(string szDeviceName)
    {
        short sValue;
        ReturnCode = mPlc.GetDevice2(szDeviceName, out sValue);
        if (ReturnCode == 0x01802001 || ReturnCode == 0x01802002 || LastErrorType == ErrorType.Error) return false;
        return true;
    }
    private static void CheckReturnCode(int returnCode, out string errorMessage, out ErrorType errorType)
    {
        errorMessage = string.Empty;
        errorType = ErrorType.Normal;
        uint uReturnCode = (uint)returnCode;
        switch (uReturnCode)
        {
            case 0:
                errorMessage = "Normal completion";
                errorType = ErrorType.Normal;
                break;
            case 0x01010002:
                errorMessage = "Time-out error";
                errorType = ErrorType.Warning;
                break;
            case 0x01010005:
                errorMessage = "Message error";
                errorType = ErrorType.Warning;
                break;
            case 0x01010010:
                errorMessage = "Check the station number set to ActStationNumber";
                errorType = ErrorType.Error;
                break;
            case 0x01010011:
                errorMessage = "Command not supported";
                errorType = ErrorType.Warning;
                break;
            case 0x0180100F:
                errorMessage = "Method cannot be executed because of exclusive control in progress";
                errorType = ErrorType.Warning;
                break;
            case 0x01802001:
                errorMessage = "The device character string number specified in the method is an unauthorized device number";
                errorType = ErrorType.Warning;
                break;
            case 0x01802002:
                errorMessage = "The device character string number specified in the method is an unauthorized device number";
                errorType = ErrorType.Warning;
                break;
            case 0x01802003:
                errorMessage = "Program Type error";
                errorType = ErrorType.Error;
                break;
            case 0x01802007:
                errorMessage = "The data received is abnormal";
                errorType = ErrorType.Error;
                break;
            case 0x01802008:
                errorMessage = "Write Protect error";
                errorType = ErrorType.Error;
                break;
            case 0x01802009:
                errorMessage = "Reading Parameters error";
                errorType = ErrorType.Error;
                break;
            case 0x0180200A:
                errorMessage = "Writing Parameters error";
                errorType = ErrorType.Error;
                break;
            case 0x01802074:
                errorMessage = "Redundant system other system connection diagnostics error";
                errorType = ErrorType.Error;
                break;
            case 0x01808001:
                errorMessage = "Multiple Open error open method was executed while it was open";
                errorType = ErrorType.Warning;
                break;
            case 0x01808003:
                errorMessage = "Driver not yet started the network board driver is not started";
                errorType = ErrorType.Warning;
                break;
            case 0x01808004:
                errorMessage = "Error in overlap event generation";
                errorType = ErrorType.Error;
                break;
            case 0x0180840A:
                errorMessage = "Communication control setting error\r\nThe control value of the property is unauthorized";
                errorType = ErrorType.Error;
                break;
            case 0x0180840B:
                errorMessage = "Time-out error\r\nThough the time-out period had elapsed, data could not be\r\nreceived.";
                errorType = ErrorType.Error;
                break;
            case 0x01809002:
                errorMessage = "GX Simulator2 start error";
                errorType = ErrorType.Error;
                break;
            case 0x01809003:
                errorMessage = "GX Simulator2 start time-out error";
                errorType = ErrorType.Error;
                break;
            case 0x01809004:
                errorMessage = "GX Simulator2 stop error";
                errorType = ErrorType.Error;
                break;
            case 0x01809005:
                errorMessage = "GX Simulator2 start error";
                errorType = ErrorType.Error;
                break;
            case 0x01809007:
                errorMessage = "GX Simulator2 stop error";
                errorType = ErrorType.Error;
                break;
            case 0x01809008:
                errorMessage = "GX Simulator2 start error\r\nBecause it had reached upper bounds of the number of\r\nsimulations that was able to be started at the same time, it\r\nwas not possible to start.";
                errorType = ErrorType.Error;
                break;
            case 0x01809009:
                errorMessage = "GX Simulator2 start error\r\nThe simulation of only one project that can be started has\r\nstarted.";
                errorType = ErrorType.Error;
                break;
            case 0x01809010:
                errorMessage = "GX Simulator2 start information illegal error\r\nThe error occurred because it was not able to secure the\r\nmemory area to allocate GX Simulator2 start information.";
                errorType = ErrorType.Error;
                break;
            case 0x01809021:
                errorMessage = "GX Simulator2 start error\r\nBecause it had reached upper bounds of the number of\r\nsimulations that was able to be started at the same time, it\r\nwas not possible to start.";
                errorType = ErrorType.Error;
                break;
            case 0x01809022:
                errorMessage = "GX Simulator2 start error\r\nThe simulation of other CPU was not able to begin because\r\nthe simulation of the project of FXCPU had already been\r\nbegun.";
                errorType = ErrorType.Error;
                break;
            case 0x02000001:
                errorMessage = "Points Exceeded error\r\nThe number of points registered in the monitoring server is\r\nvery high.";
                errorType = ErrorType.Error;
                break;
            case 0x04052001:
                errorMessage = "Abnormal Character String Specified error\r\nDevice character string specified is incorrect.";
                errorType = ErrorType.Warning;
                break;
            case 0x04052002:
                errorMessage = "Device Points error\r\nDevice points are out of range.";
                errorType = ErrorType.Warning;
                break;
            default:
                errorMessage = "Other error code: 0x" + returnCode.ToString("X8");
                errorType = ErrorType.Error;
                break;
        }
    }
    public static int GetValue16(string szDeviceName, out short sValue)
    {
        sValue = 0;
        char contanceType = szDeviceName.Trim()[0];
        ReturnCode = mPlc.GetDevice2(szDeviceName, out sValue);
        if (ReturnCode != 0)
        {
            if (contanceType == 'K')
            {
                string strValue = szDeviceName.Substring(1, szDeviceName.Length - 1);
                if (short.TryParse(strValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out sValue)) ReturnCode = 0;
                else return -1;
            }
            else if (contanceType == 'H')
            {
                string strValue = szDeviceName.Substring(1, szDeviceName.Length - 1);
                if (short.TryParse(strValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out sValue)) ReturnCode = 0;
                else return -1;
            }
        }
        if (LastErrorType == ErrorType.Error) IsOpen = false;
        return ReturnCode;
    }
    public static int GetValue32(string szDeviceName, out int sValue)
    {
        sValue = 0;
        short[] shorts = new short[2];
        char contanceType = szDeviceName.Trim()[0];
        ReturnCode = mPlc.ReadDeviceBlock2(szDeviceName, 2, out shorts[0]);
        if (ReturnCode == 0) sValue = (shorts[0] & 0xffff) | (shorts[1] << 16);
        else
        {
            if (contanceType == 'K')
            {
                string strValue = szDeviceName.Substring(1, szDeviceName.Length - 1);
                if (int.TryParse(strValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out sValue)) ReturnCode = 0;
                else return -1;
            }
            else if (contanceType == 'H')
            {
                string strValue = szDeviceName.Substring(1, szDeviceName.Length - 1);
                if (int.TryParse(strValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out sValue)) ReturnCode = 0;
                else return -1;
            }
        }
        if (LastErrorType == ErrorType.Error) IsOpen = false;
        return ReturnCode;
    }
    public static int SetValue16(string szValueName, string szDeviceName)
    {
        short sValue = 0;
        ReturnCode = GetValue16(szValueName, out sValue);
        if (ReturnCode != 0) return ReturnCode;
        ReturnCode = mPlc.SetDevice2(szDeviceName, sValue);
        if (LastErrorType == ErrorType.Error) IsOpen = false;
        return ReturnCode;
    }
    public static int SetValue16(short sValue, string szDeviceName)
    {
        ReturnCode = mPlc.SetDevice2(szDeviceName, sValue);
        if (LastErrorType == ErrorType.Error) IsOpen = false;
        return ReturnCode;
    }
    public static int SetValue32(string szValueName, string szDeviceName)
    {
        int sValue = 0;
        ReturnCode = GetValue32(szValueName, out sValue);
        if (ReturnCode != 0) return ReturnCode;
        short[] shorts = new short[2];
        shorts[0] = (short)(sValue & 0xffff);
        shorts[1] = (short)(sValue >> 16);
        ReturnCode = mPlc.WriteDeviceBlock2(szDeviceName, 2, ref shorts[0]);
        if (LastErrorType == ErrorType.Error) IsOpen = false;
        return ReturnCode;
    }
    public static int SetValue32(int iValueName, string szDeviceName)
    {
        short[] shorts = new short[2];
        shorts[0] = (short)(iValueName & 0xffff);
        shorts[1] = (short)(iValueName >> 16);
        ReturnCode = mPlc.WriteDeviceBlock2(szDeviceName, 2, ref shorts[0]);
        if (LastErrorType == ErrorType.Error) IsOpen = false;
        return ReturnCode;
    }
    public static int GetString(string szDeviceName, string szSizeName, out string strValue)
    {
        char[] sep = new char[] { ' ', '\0' };
        strValue = string.Empty;
        short sLength = 0;
        ReturnCode = GetValue16(szSizeName, out sLength);
        if (ReturnCode != 0) return ReturnCode;
        short[] sValue = new short[sLength];
        ReturnCode = mPlc.ReadDeviceBlock2(szDeviceName, sLength, out sValue[0]);
        byte[] bytes = new byte[sLength * 2];
        for (int i = 0; i < sValue.Length; i++)
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
        ReturnCode = SetValue16("K1", szDeviceName);
        return ReturnCode;
    }
    public static int RST(string szDeviceName)
    {
        ReturnCode = SetValue16("K0", szDeviceName);
        return ReturnCode;
    }
    public static int FF(string szDeviceName)
    {
        short iValue;
        ReturnCode = GetValue16(szDeviceName, out iValue);
        if (ReturnCode != 0) return ReturnCode;
        iValue = (short)(iValue == 0 ? 1 : 0);
        ReturnCode = SetValue16(iValue, szDeviceName);
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
        ReturnCode = SetValue16(iValue, szDeviceName);
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
        ReturnCode = SetValue16(iValue, szDeviceName);
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
        if (ReturnCode != 0)
        {
            if (LastErrorType == ErrorType.Error) IsOpen = false;
            return ReturnCode;
        }
        ReturnCode = mPlc.WriteDeviceBlock2(szDestDeviceName, length, ref sValues[0]);
        if (LastErrorType == ErrorType.Error) IsOpen = false;
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
        if (LastErrorType == ErrorType.Error) IsOpen = false;
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
        if (LastErrorType == ErrorType.Error) IsOpen = false;
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
        ReturnCode = SetValue16(iValue, szDestinationName);
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
        ReturnCode = SetValue16(iValue, szDestinationName);
        return ReturnCode;
    }
    public static int INC(string szDeviceName)
    {
        short iValue;
        ReturnCode = GetValue16(szDeviceName, out iValue);
        if (ReturnCode != 0) return ReturnCode;
        iValue++;
        ReturnCode = SetValue16(iValue, szDeviceName);
        return ReturnCode;
    }
    public static int DEC(string szDeviceName)
    {
        short iValue;
        ReturnCode = GetValue16(szDeviceName, out iValue);
        if (ReturnCode != 0) return ReturnCode;
        iValue--;
        ReturnCode = SetValue16(iValue, szDeviceName);
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
        ReturnCode = SetValue16(iSum, szSum);
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
        ReturnCode = SetValue16(iDifference, szDifference);
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
        if (LastErrorType == ErrorType.Error) IsOpen = false;
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
        if (LastErrorType == ErrorType.Error) IsOpen = false;
        return ReturnCode;
    }
}