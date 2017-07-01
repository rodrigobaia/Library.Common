using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RVBConsulting.Library.Common
{
    /// <summary>
	/// TODO: Update summary.
	/// </summary>
	public class HardDisk
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool GetVolumeInformation(string Volume, StringBuilder VolumeName, uint VolumeNameSize, out uint SerialNumber, out uint SerialNumberLength, out uint flags, StringBuilder fs, uint fs_size);

        public HardDisk()
        {
            GetInforDrive();
        }

        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public string Serial { get; set; }
        public string Volume { get; set; }
        public string Drive { get; set; }

        /// <summary>
        /// Busca informações do Drive
        /// </summary>
        /// <param name="drive">informe a unidade. ex: C:\</param>
        /// <returns>Objeto HardDrive</returns>
        private void GetInforDrive()
        {

            try
            {
                string drive = DetailsTerminal.DriveRoot;

                uint serialNum, serialNumLength, flags;
                StringBuilder volumename = new StringBuilder(256);
                StringBuilder fstype = new StringBuilder(256);
                bool ok = false;

                ok = GetVolumeInformation(drive, volumename, (uint)volumename.Capacity - 1, out serialNum,
                                                                         out serialNumLength, out flags, fstype, (uint)fstype.Capacity - 1);
                if (ok)
                {
                    Drive = drive;
                    Serial = serialNum.ToString();
                    if (volumename != null)
                        Volume = volumename.ToString();

                    if (fstype != null)
                        Tipo = fstype.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
