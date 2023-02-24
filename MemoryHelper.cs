using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PlantsVsZombiesPlugin
{
    class MemoryHelper
    {
        #region 引入内存操作的DLL方法
        /// <summary>
        /// 从内存中读取数据(整数型)
        /// </summary>
        /// <param name="hProcess">进程句柄</param>
        /// <param name="lpBaseAddress">内存基质</param>
        /// <param name="lpBuffer">读取到缓存区的指针</param>
        /// <param name="nSize">缓存区大小</param>
        /// <param name="lpNumberOfBytesRead">读取长度</param>
        /// <returns></returns>
        [DllImportAttribute("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessInt32Memory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, IntPtr lpNumberOfBytesRead);

        /// <summary>
        /// 从内存中读取数据(字节集)
        /// </summary>
        /// <param name="hProcess">进程句柄</param>
        /// <param name="lpBaseAddress">内存基质</param>
        /// <param name="lpBuffer">读取到缓存区的指针</param>
        /// <param name="nSize">缓存区大小</param>
        /// <param name="lpNumberOfBytesRead">读取长度</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessByteSetMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, IntPtr lpNumberOfBytesRead);

        /// <summary>
        /// 从内存中写入数据(整数型)
        /// </summary>
        /// <param name="hProcess">进程句柄</param>
        /// <param name="lpBaseAddress">内存地址</param>
        /// <param name="lpBuffer">需要写入的数据</param>
        /// <param name="nSize">写入字节大小,比如int32是4个字节</param>
        /// <param name="lpNumberOfBytesWritten">写入长度</param>
        /// <returns></returns>
        [DllImportAttribute("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessInt32Memory(IntPtr hProcess, IntPtr lpBaseAddress, int[] lpBuffer, int nSize, IntPtr lpNumberOfBytesWritten);

        /// <summary>
        /// 从内存中写入数据(字节集)
        /// </summary>
        /// <param name="hProcess">进程句柄</param>
        /// <param name="lpBaseAddress">内存地址</param>
        /// <param name="lpBuffer">需要写入的数据</param>
        /// <param name="nSize">写入字节大小,比如int32是4个字节</param>
        /// <param name="lpNumberOfBytesWritten">写入长度</param>
        /// <returns></returns>
        [DllImportAttribute("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessByteSetMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, IntPtr lpNumberOfBytesWritten);

        /// <summary>
        /// 打开进程获取句柄
        /// </summary>
        /// <param name="dwDesiredAccess">权限类型，0x1F0FFF表示最高权限</param>
        /// <param name="bInheritHandle">是否继承父类句柄</param>
        /// <param name="dwProcessId">进程PID</param>
        /// <returns></returns>
        [DllImportAttribute("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        /// <summary>
        /// 关闭进程句柄
        /// </summary>
        /// <param name="hObject">进程句柄</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern void CloseHandle(IntPtr hObject);
        #endregion

        /// <summary>
        /// 取模块基址
        /// </summary>
        /// <param name="processId">进程ID</param>
        /// <param name="DllName">动态链接库名</param>
        /// <returns></returns>
        public static IntPtr GetModuleAddress(int processId, string DllName)
        {
            try
            {
                Process PID = Process.GetProcessById(processId);
                foreach (ProcessModule processModule in PID.Modules)
                {
                    if (processModule.ModuleName == DllName)
                    {
                        return processModule.BaseAddress;
                    }
                }
            }
            catch
            {

            }
            return (IntPtr)0;
        }

        /// <summary>
        /// 进程名取PID
        /// </summary>
        /// <param name="processName">进程名</param>
        /// <returns></returns>
        public static int GetPidByProcessName(string processName)
        {
            try
            {
                Process[] arrayProcess = Process.GetProcessesByName(processName);
                return arrayProcess[0].Id;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 读取内存内容(整数型)
        /// </summary>
        /// <param name="processId">进程ID</param>
        /// <param name="baseAddress">内存地址</param>
        /// <returns>内存值</returns>
        public static int ReadMemoryInt32Value(int processId, int baseAddress)
        {
            try
            {
                byte[] buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, processId);
                ReadProcessInt32Memory(hProcess, (IntPtr)baseAddress, byteAddress, 4, IntPtr.Zero);
                CloseHandle(hProcess);
                return Marshal.ReadInt32(byteAddress);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 读取内存内容(浮点型)
        /// </summary>
        /// <param name="processId">进程ID</param>
        /// <param name="baseAddress">内存地址</param>
        /// <returns>内存值</returns>
        public static float ReadMemoryFloatValue(int processId, int baseAddress)
        {
            try
            {
                byte[] buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, processId);
                ReadProcessInt32Memory(hProcess, (IntPtr)baseAddress, byteAddress, 4, IntPtr.Zero);
                CloseHandle(hProcess);
                byte[] byteStr = new byte[4];
                Marshal.Copy(byteAddress, byteStr, 0, 4);
                return BitConverter.ToSingle(byteStr, 0);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 将数值写入内存地址(整数型)
        /// </summary>
        /// <param name="processId">进程ID</param>
        /// <param name="baseAddress">内存地址</param>
        /// <param name="value">待写入的数值</param>
        /// <returns></returns>
        public static void WriteMemoryInt32Value(int processId, int baseAddress, int value)
        {
            try
            {
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, processId);
                WriteProcessInt32Memory(hProcess, (IntPtr)baseAddress, new int[] { value }, 4, IntPtr.Zero);
                CloseHandle(hProcess);
            }
            catch { }
        }

        /// <summary>
        /// 将数值写入内存地址(浮点型)
        /// </summary>
        /// <param name="processId">进程ID</param>
        /// <param name="baseAddress">内存地址</param>
        /// <param name="value">待写入的数值</param>
        /// <returns></returns>
        public static void WriteMemoryFloatValue(int processId, int baseAddress, float value)
        {
            byte[] byteSet = BitConverter.GetBytes(value);
            WriteMemoryByteSetValue(processId, baseAddress, byteSet, 0);
        }

        /// <summary>
        /// 将字节集写入内存地址
        /// </summary>
        /// <param name="processId">进程ID</param>
        /// <param name="bAddress">0x地址</param>
        /// <param name="value">字节数据</param>
        /// <param name="length">写入长度 0代表字节数据的长度</param>
        /// <returns></returns>
        private static void WriteMemoryByteSetValue(int processId, int baseAddress, byte[] value, int length = 0)
        {
            try
            {
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, processId);
                int nSize = (length == 0) ? value.Length : length;
                WriteProcessByteSetMemory(hProcess, (IntPtr)baseAddress, value, nSize, IntPtr.Zero);
                CloseHandle(hProcess);
            }
            catch { }
        }
    }
}
