using System;
using System.Management;
using System.Net;

namespace RVBConsulting.Library.Common
{
    /// <summary>
	/// TODO: Update summary.
	/// </summary>
	public static class DetailsNetworkExtender
    {
        /// <summary>
        /// Informações do MacAddress
        /// </summary>
        /// <param name="detailsNetwork"></param>
        /// <returns></returns>
        public static string MacAddress(this DetailsNetwork detailsNetwork)
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (mo["MacAddress"] != null) // only return MAC Address from first card
                {
                    if (Convert.ToBoolean(mo["IPEnabled"]))
                    {
                        MACAddress += mo["MacAddress"].ToString();
                        break;
                    }
                }
                mo.Dispose();
            }

            return MACAddress;
        }

        /// <summary>
        /// Número do IP Local
        /// </summary>
        /// <param name="detailsNetwork"></param>
        /// <returns></returns>
        public static string IpLocal(this DetailsNetwork detailsNetwork)
        {
            string results = string.Empty;
            string strHostName = string.Empty;
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            string[] arr;

            foreach (IPAddress item in addr)
            {
                arr = item.ToString().Split('.');
                if (arr.Length == 4)
                {
                    results = item.ToString();
                    break;
                }
            }

            return results;
        }
    }
}
