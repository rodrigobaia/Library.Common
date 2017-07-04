using System;

namespace RVBConsulting.Library.Common
{
    /// <summary>
	/// Classe que recuperar informações do sistema operacional
	/// </summary>
	public static class DetailsTerminal
    {
        /// <summary>
        /// Versão do sistema operacional
        /// </summary>
        private static OperatingSystem SisOp = Environment.OSVersion;

        /// <summary>
        /// Nome do sistema operacional
        /// </summary>
        public static string OperationalSystem
        {
            get
            {
                return SisOp.Platform.ToString();
            }

        }

        /// <summary>
        /// Service Pack do sistema operacional
        /// </summary>
        public static string ServicePack
        {
            get
            {
                return SisOp.ServicePack.ToString();
            }

        }

        /// <summary>
        /// Versão do windows
        /// </summary>
        public static string Version
        {
            get
            {
                return SisOp.Version.ToString();
            }

        }

        /// <summary>
        /// Versão extendida
        /// </summary>
        public static string VersionEx
        {
            get
            {
                return SisOp.VersionString.ToString();
            }

        }

        /// <summary>
        /// Local de instalação do windows
        /// </summary>
        public static string PathInstall
        {
            get
            {
                string path = Environment.GetEnvironmentVariable("SystemRoot");

                return path;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string DriveRoot
        {
            get
            {
                string path = Environment.GetEnvironmentVariable("SystemRoot").Left(3);

                return path;
            }
        }

        private static HardDisk hardDisk;

        /// <summary>
        /// Informações do HD
        /// </summary>
        public static HardDisk HardDisk
        {
            get
            {
                if (hardDisk == null) hardDisk = new HardDisk();

                return hardDisk;
            }
        }

        private static DetailsNetwork detailsNetwork;

        /// <summary>
        /// Detalhes sobre a Network
        /// </summary>
        public static DetailsNetwork Network
        {
            get
            {
                if (detailsNetwork == null) detailsNetwork = new DetailsNetwork();

                return detailsNetwork;
            }
        }
    }
}
